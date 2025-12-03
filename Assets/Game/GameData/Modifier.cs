using System;
using System.Collections.Generic;


namespace Game
{
    [Serializable]
    public struct Modifier
    {
        public TargetTags TargetTag;
        public ConditionalTags ModifierCondition;
        public ModifierType Type;
        public float Value;
        public object Source;
        
        //Not yet implemented
        public bool ApplyAfterCalculations;
        
        public Modifier(TargetTags targetTargetTag, ConditionalTags modifierCondition, ModifierType type, float value, bool applyAfterCalculations,  object source = null)
        {
            TargetTag = targetTargetTag;
            ModifierCondition = modifierCondition;
            Type = type;
            Value = value;
            ApplyAfterCalculations = applyAfterCalculations;
            Source = source;
        }
    }
}
