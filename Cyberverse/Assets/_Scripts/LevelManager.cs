using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class LevelManager : MonoBehaviour
{
    static bool isLevelOneComplete = false;
    static bool isLevelTwoComplete = false;

    public GameObject levelOneCompleteText;
    public GameObject levelTwoCompleteText;

    private string saveFilePath;

    // Start is called before the first frame update
    void Start()
    {
        saveFilePath = Application.dataPath + "/CompletedLevels.txt"; // Path to the save file
        LoadCompletedLevels();
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevelOneComplete == true)
        {
            levelOneCompleteText.gameObject.SetActive(true);
            SaveCompletedLevels(); // Save completed levels when level one is complete
        }

        if(isLevelTwoComplete == true)
        {
            levelTwoCompleteText.gameObject.SetActive(true);
            SaveCompletedLevels();
        }
    }

    // Function to be called when the level is complete
    public static void LevelOneComplete()
    {
        isLevelOneComplete = true;
        
        //Debug.Log("Level one complete");
    }

    public static void LevelTwoComplete()
    {
        isLevelTwoComplete = true;
    }

    // Save completed levels to a text file
    private void SaveCompletedLevels()
    {
        using (StreamWriter sw = new StreamWriter(saveFilePath))
        {
            sw.WriteLine(isLevelOneComplete ? "Level 1: Completed" : "Level 1: Incomplete");
            sw.WriteLine(isLevelTwoComplete ? "Level 2: Completed" : "Level 2: Incomplete");
            // Add more lines for additional levels if needed
        }
    }

    // Load completed levels from the text file
    private void LoadCompletedLevels()
    {
        if (File.Exists(saveFilePath))
        {
            using (StreamReader sr = new StreamReader(saveFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Parse the line to determine completed levels and set the corresponding flags
                    if (line.Contains("Level 1: Completed"))
                    {
                        isLevelOneComplete = true;
                    }
                    else if (line.Contains("Level 2: Completed"))
                    {
                        isLevelTwoComplete = true;
                    }
                    // Add more parsing logic for additional levels if needed
                }
            }
        }
    }
}
