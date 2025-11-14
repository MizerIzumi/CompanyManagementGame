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
            // Modifier modie =  new Modifier(TagsEnum.Health, 100, (int)Operators.addition);
            //Mods.Add(mod);
        }
        
    }

    //Fix so that it can take in an enum on construction I dont trust the Eum with Capital E, but maybe it works?
    public struct Modifier<T> where T : Enum
     {
        public T TargetTag;
        public float Value;
        public int Operator;

        public Modifier(T targetTag, float value, int operator_)
        {
            TargetTag = targetTag;
            Value = value;
            Operator = operator_;
        }
    }
}

