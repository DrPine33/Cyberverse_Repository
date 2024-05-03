using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class TestingScript
{
    [UnityTest]
    public IEnumerator _StartGameButtonClickToLoadGame()
    {
        SceneManager.LoadScene("MainMenu");
        yield return new WaitForSeconds(1);

        GameObject canvas = GameObject.Find("Canvas");
        Assert.IsNotNull(canvas, "Canvas not found");

        GameObject mainMenuPanel = canvas.transform.Find("MainMenuPanel").gameObject;
        Assert.IsNotNull(mainMenuPanel, "Could not find MainMenuPanel");
        mainMenuPanel.SetActive(false);
        yield return new WaitForSeconds(1);

        GameObject controlsPanel = canvas.transform.Find("ControlsPanel").gameObject;
        controlsPanel.SetActive(true);
        Assert.IsNotNull(controlsPanel, "ControlsPanel not found");

        // Find the StartGameButton
        GameObject startGameButton = GameObject.Find("StartGameButton");
        Assert.IsNotNull(startGameButton, "StartGameButton not found");

        // Get the button's component
        Button buttonComponent = startGameButton.GetComponent<Button>();
        Assert.IsNotNull(buttonComponent, "Button component not found on StartGameButton");

        // Create a pointer event
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);

        // Simulate a click on the button
        buttonComponent.OnPointerClick(pointerEventData);

        yield return new WaitForSeconds(1);

        Assert.AreEqual("GameScene", SceneManager.GetActiveScene().name);
    }
    //Player Spawn Testing
    [UnityTest]
    public IEnumerator PlayerSpawning()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject player = GameObject.Find("ThePlayer");

        Assert.IsNotNull(player);
    }

    //Starting NPC Spawn Testing
    [UnityTest]
    public IEnumerator SpawnNPC_1()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_1");
        Assert.IsNotNull(NPC);
    }
    [UnityTest]
    public IEnumerator SpawnNPC_2()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_2");
        Assert.IsNotNull(NPC);
    }
    [UnityTest]
    public IEnumerator SpawnNPC_3()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_3");
        Assert.IsNotNull(NPC);
    }
    [UnityTest]
    public IEnumerator SpawnNPC_4()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_4");
        Assert.IsNotNull(NPC);
    }
    [UnityTest]
    public IEnumerator SpawnNPC_5()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_5");
        Assert.IsNotNull(NPC);
    }
    [UnityTest]
    public IEnumerator SpawnNPC_6()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_6");
        Assert.IsNotNull(NPC);
    }
    [UnityTest]
    public IEnumerator SpawnNPC_7()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_7");
        Assert.IsNotNull(NPC);
    }
    [UnityTest]
    public IEnumerator SpawnNPC_8()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_8");
        Assert.IsNotNull(NPC);
    }
    [UnityTest]
    public IEnumerator SpawnNPC_9()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_9");
        Assert.IsNotNull(NPC);
    }
    [UnityTest]
    public IEnumerator SpawnNPC_10()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject NPC = GameObject.Find("NPC_10");
        Assert.IsNotNull(NPC);
    }
    //Ending NPC Spawning Test

    //Starting Enemy Spawning Test
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_1()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_1");
        Assert.IsNotNull(enemy);
    }
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_2()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_2");
        Assert.IsNotNull(enemy);
    }
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_3()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_3");
        Assert.IsNotNull(enemy);
    }
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_4()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_4");
        Assert.IsNotNull(enemy);
    }
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_5()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_5");
        Assert.IsNotNull(enemy);
    }
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_6()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_6");
        Assert.IsNotNull(enemy);
    }
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_7()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_7");
        Assert.IsNotNull(enemy);
    }
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_8()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_8");
        Assert.IsNotNull(enemy);
    }
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_9()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_9");
        Assert.IsNotNull(enemy);
    }
    [UnityTest]
    public IEnumerator SpawnEnemyAlien_10()
    {
        SceneManager.LoadScene("GameScene");
        yield return null;

        GameObject enemy = GameObject.Find("EnemyAlien_10");
        Assert.IsNotNull(enemy);
    }
    //Ending Enemy Spawn Testing
}
