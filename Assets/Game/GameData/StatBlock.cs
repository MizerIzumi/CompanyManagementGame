using System;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace Game
{
    public class StatBlock
    {
        public string Name;

        Dictionary<String, Stat> Stats = new Dictionary<String, Stat>();
    }
}
