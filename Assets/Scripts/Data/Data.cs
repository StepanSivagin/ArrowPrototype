using System;
using System.IO;
using ExampleTemplate.Level;
// using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;


namespace ExampleTemplate
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        #region Fields
        
        [SerializeField] private string _shakeDataPath;
        [SerializeField] private string _characterDataPath;
        [SerializeField] private string _levelsDataPath;
        [SerializeField] private string _enemiesDataPath;
        private static ShakesData _shake;
        private static CharacterData _characterData;
        private static LevelsData _levelsData;
        private static EnemiesData _enemiesData;
        private static readonly Lazy<Data> _instance = new Lazy<Data>(() => Load<Data>("Data/" + typeof(Data).Name));
        
        #endregion
        

        #region Properties

        public static Data Instance => _instance.Value;

        public ShakesData Shakes
        {
            get
            {
                if (_shake == null)
                {
                    _shake = Load<ShakesData>("Data/" + Instance._shakeDataPath);
                }

                return _shake;
            }
        }

        public CharacterData Character
        {
            get
            {
                if (_characterData == null)
                {
                    _characterData = Load<CharacterData>("Data/" + Instance._characterDataPath);
                }

                return _characterData;
            }
        }

        public LevelsData LevelsData
        {
            get
            {
                if (_levelsData == null)
                {
                    _levelsData = Load<LevelsData>("Data/" + Instance._levelsDataPath);
                }

                return _levelsData;
            }
        }

        public EnemiesData EnemiesData
        {
            get
            {
                if (_enemiesData == null)
                {
                    _enemiesData = Load<EnemiesData>("Data/" + Instance._enemiesDataPath);
                }

                return _enemiesData;
            }
        }
        #endregion


        #region Methods

        private static T Load<T>(string resourcesPath) where T : Object =>
            CustomResources.Load<T>(Path.ChangeExtension(resourcesPath, null));
    
        #endregion
    }
}
