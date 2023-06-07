using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;



public class GameManagerTest
{

    private GameManager gameManager;

    [UnitySetUp]
    public IEnumerator SetUp()
    {
        SceneManager.LoadScene("Start");
        yield return null; // Wait for one frame to load the scene
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    [UnityTest]
    public IEnumerator Start_GameManager_InitializesCorrectly()
    {
        yield return new WaitForEndOfFrame();

        Assert.IsNotNull(gameManager);

        // Check if the mainMenu is active and other game objects are inactive
        Assert.IsTrue(gameManager.mainMenu.activeSelf);
        Assert.IsFalse(gameManager.pauseMenu.activeSelf);
        Assert.IsFalse(gameManager.levels.activeSelf);
        Assert.IsFalse(gameManager.options.activeSelf);
        Assert.IsFalse(gameManager.credits.activeSelf);
        Assert.IsFalse(gameManager.death.activeSelf);
        Assert.IsFalse(gameManager.wait.activeSelf);
        Assert.IsFalse(gameManager.gui.activeSelf);

        Assert.AreEqual(GameManager.GameState.Menu, gameManager.gameState);
    }

    [UnityTest]
    public IEnumerator StartGame_LoadsCorrectScene()
    {
        yield return new WaitForEndOfFrame();

        gameManager.StartGame();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(1, SceneManager.GetActiveScene().buildIndex);
    }

    [UnityTest]
    public IEnumerator Pause_PausesAndResumesGame()
    {
        yield return new WaitForEndOfFrame();

        gameManager.StartGame();

        yield return new WaitForSeconds(0.1f);

        Assert.AreEqual(GameManager.GameState.Game, gameManager.gameState);

        gameManager.Pause();

        Assert.AreEqual(GameManager.GameState.Pause, gameManager.gameState);
        Assert.IsTrue(gameManager.pauseMenu.activeSelf);
        Assert.AreEqual(0f, Time.timeScale);

        gameManager.Pause();

        Assert.AreEqual(GameManager.GameState.Game, gameManager.gameState);
        Assert.IsFalse(gameManager.pauseMenu.activeSelf);
        Assert.AreEqual(1f, Time.timeScale);
    }

    [UnityTest]
    public IEnumerator Death_SetsGameStateAndActivatesDeathObject()
    {
        yield return new WaitForEndOfFrame();

        gameManager.Death();

        Assert.AreEqual(GameManager.GameState.Death, gameManager.gameState);
        Assert.IsTrue(gameManager.death.activeSelf);
    }

    // Add more tests for other methods as needed

    [UnityTearDown]
    public IEnumerator TearDown()
    {
        GameObject.Destroy(gameManager.gameObject);
        yield return null;
    }
}
