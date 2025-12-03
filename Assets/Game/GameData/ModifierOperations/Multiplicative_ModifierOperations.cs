

namespace Game
{
    public sealed class Multiplicative_ModifierOperations : ModifierOperationsBase
    {
        internal Multiplicative_ModifierOperations() : base() {}
        public override float CalculateModifiersValue(float baseValue, float currentValue)
        {
            float calculatedValue = currentValue;
            
            for (int i = 0; i < Modifiers.Count; i++)
                calculatedValue += calculatedValue * Modifiers[i].Value;
            return calculatedValue - currentValue;
        }
    }
}
