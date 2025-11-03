using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Game
{
    public class StatBlock : MonoBehaviour
    {
        public string Name;

        Dictionary<String, Stat> Stats = new Dictionary<String, Stat>();
    }
}