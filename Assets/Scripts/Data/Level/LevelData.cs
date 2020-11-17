using System;
using UnityEngine;

namespace ExampleTemplate.Level
{
    [Serializable]
    public sealed class LevelData
    {
        public LevelType LevelType;
        public GameObject LocationPrefab;
    }
}