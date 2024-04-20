using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevelOne()
    {
        SceneManager.LoadScene("Level-1");
    }

    public void LoadLevelTwo()
    {
        SceneManager.LoadScene("Level-2");
    }

    public void MainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
            // Insert your GitHub Project Link within the string
            Application.OpenURL("https://github.com/");
#else
            Application.Quit();
#endif
    }
}
