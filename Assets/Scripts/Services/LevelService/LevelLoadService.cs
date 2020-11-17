using UnityEngine;

namespace ExampleTemplate.LevelService
{
    public class LevelLoadService : Service
    {
        private GameObject _currentLevel;
        

        public void LoadLevel(LevelType levelType, EnemyType enemyType, CharacterType characterType)
        {
            if (_currentLevel != null)
            {
                DestroyLevel();
            }
            _currentLevel = GameObject.Instantiate(Data.Instance.LevelsData.GetPrefabLevel(levelType));
            var characterPosition = GameObject.FindWithTag(TagManager.GetTag(TagType.CharacterPosition)).transform;
            var enemyPosition = GameObject.FindWithTag(TagManager.GetTag(TagType.EnemyPosition)).transform;
            Data.Instance.Character.Initialization(characterType, characterPosition);
            Data.Instance.EnemiesData.Initialization(enemyType, enemyPosition);
            Time.timeScale = 1;
        }

        public void DestroyLevel()
        {
            GameObject.Destroy(_currentLevel);
            GameObject.Destroy(Data.Instance.Character.CharacterBehaviour.gameObject);
            GameObject.Destroy(Data.Instance.EnemiesData.EnemyBehaviour.gameObject);
        }
    }
}