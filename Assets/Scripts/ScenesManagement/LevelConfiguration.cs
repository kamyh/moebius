﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.ScenesManagement
{
    [Serializable]
    public class LevelConfiguration
    {
        public string name = "default";
        public float spawnInterval = 2f;
        public float fallVelocity = -2f;
        public int nbRecyclable = 2;
        public float gaugeLevel = 1f;
    }
}
