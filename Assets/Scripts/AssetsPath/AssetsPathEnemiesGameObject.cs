using System.Collections.Generic;

namespace ExampleTemplate
{
    public sealed class AssetsPathEnemiesGameObject
    {
        #region Fields

        public static readonly Dictionary<EnemyType, string> EnemyGameObject = new Dictionary<EnemyType, string>
        {
            {
                EnemyType.Kobayashi, "Prefabs/Enemies/unitychan"
            },
            
        };

        #endregion
    }
}