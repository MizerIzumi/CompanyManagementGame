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
    }
}