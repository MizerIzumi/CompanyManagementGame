using System;
using System.Collections.Generic;
using UnityEngine.InputSystem.Utilities;

namespace Game
{
    public class StatModifier
    {
        public enum Operators
        {
            addition,
            subtraction,
            division,
            multiplication
        }
        
        //private List<Modifier> Mods = new List<Modifier>();
        
        public string DisplayName;

        public StatModifier(string displayname)
        {
            DisplayName = displayname;
        }

        public void AddModifier(TagsEnum targetTag, float value, int operatorIndex)
        {
            //Modifier modie =  new Modifier(TagsEnum.Health, 100, (int)Operators.addition);
            //Mods.Add(mod);
        }
        
    }
    
    public struct Modifier
    {
        public TagsEnum TargetTag;
        public float Value;
        public Operators Operator;

        public Modifier(TagsEnum targetTag, float value, int operator_)
        {
            TargetTag = targetTag;
            Value = value;
            Operator = operator_;
        }
    }
}

