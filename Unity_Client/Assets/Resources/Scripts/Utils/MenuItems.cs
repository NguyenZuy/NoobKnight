using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace NoobKnight.Utils
{
    public class MenuItems : EditorWindow
    {
        [MenuItem("Zuy Custom/Open Scene")]
        static void OpenCustomScene()
        {
            // Get the list of scene names in build settings
            string[] sceneNames = new string[EditorBuildSettings.scenes.Length];
            for (int i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                sceneNames[i] = System.IO.Path.GetFileNameWithoutExtension(EditorBuildSettings.scenes[i].path);
            }

            // Create a GenericMenu
            GenericMenu menu = new GenericMenu();

            // Add menu items for each scene
            for (int i = 0; i < sceneNames.Length; i++)
            {
                string sceneName = sceneNames[i];
                menu.AddItem(new GUIContent("Open Scene/" + sceneName), false, () => OpenScene(sceneName));
            }

            // Show the menu under the "Zuy Custom" menu
            menu.ShowAsContext();
        }

        static void OpenScene(string sceneName)
        {
            // Save the current scene
            EditorSceneManager.SaveOpenScenes();

            // Get the target scene path
            string targetScenePath = System.Array.Find(EditorBuildSettings.scenes, scene => scene.path.EndsWith(sceneName + ".unity")).path;

            // Open the target scene
            EditorSceneManager.OpenScene(targetScenePath);
        }
    }
}