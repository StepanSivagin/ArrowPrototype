using System;
using UnityEngine;

namespace ExampleTemplate.Level
{
    [Serializable]
    public class LevelData
    {
        public LevelType LevelType;
        public GameObject LocationPrefab;
    }
}