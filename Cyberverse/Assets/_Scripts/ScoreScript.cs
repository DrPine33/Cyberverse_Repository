using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{ 
    public static int levelOneScore = 0;
    public static int levelTwoScore = 0;
    Text LevelOneScore;
    Text LevelTwoScore;

    // Start is called before the first frame update
    void Start()
    {
        LevelOneScore = GetComponent<Text>();
        LevelTwoScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level-1")
        {
            LevelOneScore.text = "NPC's Talked To: " + levelOneScore + "/2";
        }

        if (levelOneScore >= 2)
        {
            LevelManager.LevelOneComplete();

            SceneManager.LoadScene("MainMenu");

            levelOneScore = 0;

            Cursor.lockState = CursorLockMode.None;
        }

        if (SceneManager.GetActiveScene().name == "Level-2")
        {
            LevelTwoScore.text = "NPC's Talked To: " + levelTwoScore + "/10";
        }
        if (levelTwoScore >= 10)
        {
            LevelManager.LevelTwoComplete();

            SceneManager.LoadScene("MainMenu");

            levelTwoScore = 0;

            Cursor.lockState = CursorLockMode.None;
        }
    }
}
