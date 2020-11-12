using UnityEngine;

namespace ExampleTemplate.LevelService
{
    public class LevelLoadService : Service
    {
        private GameObject _currentLevel;
        private GameObject _characterPosition;
        private GameObject _enemyPosition;

        public void LoadLevel(LevelType levelType)
        {
            if (_currentLevel != null)
            {
                GameObject.Destroy(_currentLevel);
            }
            _currentLevel = GameObject.Instantiate(Data.Instance.LevelsData.GetPrefabLevel(levelType));
            _characterPosition = GameObject.FindWithTag(TagManager.GetTag(TagType.CharacterPosition));
            _enemyPosition = GameObject.FindWithTag(TagManager.GetTag(TagType.EnemyPosition));
            
            Time.timeScale = 1;
        }
    }
}