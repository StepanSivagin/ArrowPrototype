using UnityEngine;

namespace ExampleTemplate.LevelService
{
    public class LevelLoadService : Service
    {
        private GameObject _currentLevel;
        

        public void LoadLevel(LevelType levelType, EnemyType enemyType)
        {
            if (_currentLevel != null)
            {
                GameObject.Destroy(_currentLevel);
            }
            _currentLevel = GameObject.Instantiate(Data.Instance.LevelsData.GetPrefabLevel(levelType));
            var characterPosition = GameObject.FindWithTag(TagManager.GetTag(TagType.CharacterPosition)).transform;
            var enemyPosition = GameObject.FindWithTag(TagManager.GetTag(TagType.EnemyPosition)).transform;
            
            Data.Instance.EnemiesData.Initialization(enemyType, enemyPosition);
            Time.timeScale = 1;
        }
    }
}