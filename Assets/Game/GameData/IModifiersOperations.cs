using System.Collections.Generic;
using Game;

public interface IModifiersOperations
{
    void AddModifiers(Modifier modifier);
    bool TryRemoveModifier(Modifier modifier);
    List<Modifier> GetAllModifiers();
    float CalculateModifiersValue(float baseValue, float currentValue);
}
