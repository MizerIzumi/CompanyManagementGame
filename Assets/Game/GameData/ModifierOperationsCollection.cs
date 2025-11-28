

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal sealed class ModifierOperationsCollection
    {
        private readonly Dictionary<ModifierType, Func<IModifiersOperations>> _modifierOperationsDict = new();
        private bool _modifiersCollectionHasBeenReturned;

        internal ModifierType AddModifierOperation(int order, Func<IModifiersOperations> modifierOperationsDelegate)
        {
            if (_modifiersCollectionHasBeenReturned)
                throw new InvalidOperationException("Cannot change collection after it has been returned.");
            
            ModifierType modifierType = (ModifierType)order;
            
            if (modifierType is ModifierType.Flat or ModifierType.Multiplication_Combined or ModifierType.Multiplication_Individual)
                Debug.LogWarning("modifier operations for types flat, additive and multiplicative cannot be changed! Default operations for these types will be used.");
            
            _modifierOperationsDict[modifierType] = modifierOperationsDelegate;
            
            return modifierType;
        }

        internal Dictionary<ModifierType, Func<IModifiersOperations>> GetModifierOperations()
        {
            _modifierOperationsDict[ModifierType.Flat] = () => new FlatModifierOperations();
            _modifierOperationsDict[ModifierType.Multiplication_Combined] = () => new Multi_C_ModifierOperations();
            _modifierOperationsDict[ModifierType.Multiplication_Individual] = () => new Multi_I_ModifierOperations();
            
            _modifiersCollectionHasBeenReturned = true;
            
            return _modifierOperationsDict;
        }
    }
}