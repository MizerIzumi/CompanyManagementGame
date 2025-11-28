using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    public abstract class ModifierOperationsBase : IModifiersOperations
    {
        protected readonly List<Modifier> Modifiers;
        
        
        protected ModifierOperationsBase() => Modifiers = new List<Modifier>();
        
        public virtual void AddModifiers(Modifier modifier)
        {
            Modifiers.Add(modifier);
        }

        public virtual bool TryRemoveModifier(Modifier modifier) => Modifiers.Remove(modifier);

        public virtual List<Modifier> GetAllModifiers()  => Modifiers;

        public abstract float CalculateModifiersValue(float baseValue, float currentValue);
    }
}

