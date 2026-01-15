using System;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    [Serializable]
    public class Statistic
    {
        public delegate void OnStatChanged(Statistic stat);
        public event OnStatChanged onStatChanged;
        public delegate void OnStatModifiersChanged(Statistic stat);
        public event OnStatModifiersChanged onStatModifiersChanged;
        public delegate void OnStatReachedMax(Statistic stat);
        public event OnStatReachedMax onStatReachedMax;
        public delegate void OnStatReachedMin(Statistic stat);
        public event OnStatReachedMin onStatReachedMin;

        private const int MAXIMUM_ROUND_DIGITS = 8;

        private bool _isDirty;
        
        [SerializeField]
        private float _baseValue;
        public float BaseValue
        {
            get => _baseValue;
            set
            {
                _baseValue = value * StatGrowthMultiplier;
                _currentValue = CalculateModifiedValue(_digitalAccuracy);
                OnValueChanged();
            }
        }
        
        private float _currentValue;
        public float Value
        {
            get
            {
                if (IsDirty)
                {
                    _currentValue = CalculateModifiedValue(_digitalAccuracy);
                    OnValueChanged();
                }
                return _currentValue;
            }
        }

        public string DisplayName;
        private int _digitalAccuracy = 2;
        private List<Modifier> _modifiersList = new();
        private SortedList<ModifierType, IModifiersOperations>_modifiersOperations = new();
        
        private static ModifierOperationsCollection _modifierOperationsCollection = new();
        private static void Init() => _modifierOperationsCollection = new();
        
        public float StatGrowthMultiplier = 1;
        public float StatMin;
        public float StatMax;

        private bool IsDirty
        {
            get => _isDirty;
            set
            {
                _isDirty = value;
                if (_isDirty)
                    OnModifiersChanged();
            }
        }

        
        public Statistic(string displayname, float baseValue, float statmin, float statmax)
        {
            DisplayName = displayname;
            _baseValue = baseValue;
            StatMin = statmin;
            StatMax = statmax;

            IsDirty = true;
            InitializeModifierOperations();

            void InitializeModifierOperations()
            {
                var modifierOperations = _modifierOperationsCollection.GetModifierOperations();
                
                foreach (var operationType in modifierOperations.Keys)
                    _modifiersOperations[operationType] = modifierOperations[operationType]();
            }
        }
        
        
        
        
        public void AddModifier(Modifier modifier)
        {
            IsDirty =  true;
            _modifiersOperations[modifier.Type].AddModifiers(modifier);
        }


        public static ModifierType NewModifierType(int order, Func<IModifiersOperations> modifiersOperationsDelegate)
        {
            try
            {
                return _modifierOperationsCollection.AddModifierOperation(order, modifiersOperationsDelegate);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Add any modifier operations before any initialization of the Stat class!");
            }
        }
        
        
        public IReadOnlyList<Modifier> GetModifiers()
        {
            _modifiersList.Clear();
            
            foreach(var modifiersOperation in _modifiersOperations.Values)
                _modifiersList.AddRange(modifiersOperation.GetAllModifiers());
            
            return _modifiersList.AsReadOnly();
        }
        
        //if you want only the modifiers of a specific type
        public IReadOnlyList<Modifier> GetModifiers(ModifierType modifierType) => _modifiersOperations[modifierType].GetAllModifiers().AsReadOnly();
        
        
        public bool TryRemoveModifier(Modifier modifier)
        {
            bool isRemoved = false;

            if (_modifiersOperations[modifier.Type].TryRemoveModifier(modifier))
            {
                IsDirty = true;
                isRemoved = true;
            }

            return isRemoved;
        }


        public bool TryRemoveAllModifiersOf(object source)
        {
            bool isRemoved = false;

            for (int i = 0; i < _modifiersOperations.Count; i++)
            {
                if (TryRemoveAllModifiersOfSourceFromList(source, _modifiersOperations.Values[i].GetAllModifiers()))
                {
                    isRemoved = true;
                    IsDirty =  true;
                }
            }
            return isRemoved;
            
            //static local method wont get allocated to the heep
            static bool TryRemoveAllModifiersOfSourceFromList(object source, List<Modifier> listOfModifiers)
            {
                bool modifierHasBeenRemoved = false;
                
                for (int i = listOfModifiers.Count - 1; i >= 0; i--)
                {
                    if (ReferenceEquals(source, listOfModifiers[i].Source))
                    {
                        listOfModifiers.RemoveAt(i);
                        modifierHasBeenRemoved = true;
                    }
                }
                return modifierHasBeenRemoved;
            }
        }
        
        
        private float CalculateModifiedValue(int digitalAccuracy)
        {
            digitalAccuracy = Math.Clamp(digitalAccuracy, 0, MAXIMUM_ROUND_DIGITS);

            float finalValue = _baseValue;

            for (int i = 0; i < _modifiersOperations.Count; i++) 
                finalValue += _modifiersOperations.Values[i].CalculateModifiersValue(_baseValue, finalValue);

            IsDirty = false;

            float test = (float)Math.Round(finalValue, digitalAccuracy);
            
            return (float)Math.Round(finalValue, digitalAccuracy);
        }
        
        
        
        
        //Increase/Decrease the value of this stat
        public void IncreaseStat(float amount)
        {
            if (amount < 0) return;

            float mAmount = amount;
            
            if (BaseValue + mAmount >= StatMax)
            {
                BaseValue = StatMax;
                OnValueChanged();
                OnValueMax();
                return;
            }
            BaseValue += mAmount;
            OnValueChanged();
        }
        public void DecreaseStat(float amount)
        {
            if (amount < 0) return;
            
            float mAmount = amount;
            
            if (BaseValue - mAmount <= StatMin)
            {
                BaseValue = StatMin;
                OnValueChanged();
                OnValueMin();
                return;
            }
            BaseValue -= mAmount;
            OnValueChanged();
        }
        
        //Increase/Decrease the growth multiplier of this stat
        public void IncreaseStatGrowthMultiplier(float amount)
        {
            StatGrowthMultiplier += amount;
        }
        public void DecreaseStatGrowthMultiplier(float amount)
        {
            StatGrowthMultiplier -= amount;
        }
        
        //Stat +/- 1
        public void  IncrementStat()
        {
            if (BaseValue + 1 >= StatMax)
            {
                BaseValue = StatMax;
                OnValueChanged();
                OnValueMax();
                return;
            }
            
            BaseValue += 1;
            OnValueChanged();
        }
        public void DecrementStat()
        {
            if (BaseValue - 1 <= StatMin)
            {
                BaseValue = StatMin;
                OnValueChanged();
                OnValueMin();
                return;
            }
            
            BaseValue -= 1;
            OnValueChanged();
        }
        
        private void OnValueChanged() => onStatChanged?.Invoke(this);
        private void OnModifiersChanged() => onStatModifiersChanged?.Invoke(this);
        private void OnValueMax() => onStatReachedMax?.Invoke(this);
        private void OnValueMin() => onStatReachedMin?.Invoke(this);
    }
}