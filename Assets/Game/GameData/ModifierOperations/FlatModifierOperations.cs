

namespace Game
{
    public sealed class FlatModifierOperations : ModifierOperationsBase
    {
        internal FlatModifierOperations() : base() {}
        public override float CalculateModifiersValue(float baseValue, float currentValue)
        {
            float modifiersSum = 0f;
            
            for (int i = 0; i < Modifiers.Count; i++)
                modifiersSum += Modifiers[i].Value;
            
            return modifiersSum;
        }
    }
}