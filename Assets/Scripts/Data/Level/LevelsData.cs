using System;
using System.Linq;
using UnityEngine;

namespace ExampleTemplate.Level
{
    [CreateAssetMenu(fileName = "LevelsData", menuName = "Data/Levels/LevelsData")]
    public sealed class LevelsData : ScriptableObject
    {
        [SerializeField] private LevelData[] _levels;
        
        private LevelData GetLevelData(LevelType levelType)
        {
            var result = _levels.SingleOrDefault(x => x.LevelType == levelType);
            if (result == null)
                throw new ArgumentException("Нет данных для уровня " + levelType);
            return result;
        }

        public GameObject GetPrefabLevel(LevelType levelType) => GetLevelData(levelType).LocationPrefab;
       
    }
}