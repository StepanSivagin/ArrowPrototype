using UnityEngine;

namespace ExampleTemplate.LevelService
{
    public sealed class LevelDataService : Service
    {
        public GameObject CharacterPrefab { get; private set; }
        public LevelType LevelType { get; set; }
        
    }
}