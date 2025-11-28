using System;
using UnityEngine.Serialization;


namespace Game
{
    [Serializable]
    public struct Modifier
    {
        public TagsEnum TargetTag;
        public ModifierType Type;
        public float Value;
        public object Source;
        public bool ApplyAfterCalculations;
        
        public Modifier(TagsEnum targetTag, ModifierType type, float value, bool applyAfterCalculations,  object source = null)
        {
            TargetTag = targetTag;
            Type = type;
            Value = value;
            ApplyAfterCalculations = applyAfterCalculations;
            Source = source;
        }
    }
}
