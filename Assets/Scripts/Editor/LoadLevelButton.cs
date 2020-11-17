using ExampleTemplate;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(LoadLevelFromEditor))]
    public class LoadLevelButton : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            if (GUILayout.Button("Загрузить лвл"))
                ((LoadLevelFromEditor)target).Load();
        }
    }
}