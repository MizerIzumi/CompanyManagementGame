using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StatBlock : MonoBehaviour
    {
        [SerializeField]
        protected string _name;
        
        public Dictionary<int, float> Stats = new Dictionary<int, float>();

        public virtual void IncreaseStat(int statIndex, float increaseAmount)
        {
            Stats[statIndex] += increaseAmount;
        }

        public virtual void DecreaseStat(int statIndex, float increaseAmount)
        {
            Stats[statIndex] -= increaseAmount;
        }
    }
}