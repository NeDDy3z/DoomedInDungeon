using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject levels;
    public GameObject options;
    public GameObject credits;
    public GameObject death;
    public GameObject wait;
    public GameObject gui;

    public GameState gameState;
    
    public GameObject player;
    private PlayerController playerC;

    public int levelNumber = 0;
    
    private bool sound = true;
    private bool music = true;

    public enum GameState
    {
        Menu,
        Game,
        Pause,
        Levels,
        Options,
        Credits,
        Death
    }
    
    void Start()
    {
        UIToggle();
        mainMenu.gameObject.SetActive(true);
        
        playerC = player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Pause();
        if (Input.GetKeyDown(KeyCode.K)) Death();
    }

    void UIToggle()
    {   
        mainMenu.gameObject.SetActive(false);
        pauseMenu.gameObject.SetActive(false);
        levels.gameObject.SetActive(false);
        options.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        death.gameObject.SetActive(false);
        wait.gameObject.SetActive(false);
        gui.gameObject.SetActive(false);
    }

    public void BtnColor()
    {

    }

    public void NextLevel(int levelNumber)
    {
        
        Debug.Log("Level "+ levelNumber +" entered.");
    }

    #region UI
    public void StartGame()
    {
        UIToggle();
        gameState = GameState.Game;
        gui.gameObject.SetActive(true);

        playerC.transform.position = new Vector3(0f, 0f, 0f);
        playerC.Freeze(false);
        Debug.Log("Game started");
    }

    public void Menu()
    {
        UIToggle();
        gameState = GameState.Menu;
        mainMenu.SetActive(true);
    }
    
    public void Levels()
    {
        UIToggle();
        gameState = GameState.Levels;
        levels.gameObject.SetActive(true);
    }

    public void LevelChoice(int lvl)
    {
        levelNumber = lvl;
    }
    
    public void Options()
    {
        UIToggle();
        gameState = GameState.Options;
        options.gameObject.SetActive(true);
    }
    
    public void Credits()
    {
        UIToggle(); 
        gameState = GameState.Credits;
        credits.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void Pause()
    {
        switch (gameState)
        {
            case GameState.Game:
                gameState = GameState.Pause;
                pauseMenu.gameObject.SetActive(true);
                playerC.Freeze(true);
                break;

            case GameState.Pause:
                gameState = GameState.Game;
                pauseMenu.gameObject.SetActive(false);
                playerC.Freeze(false);
                break;
        }
    }
    
    public void Death()
    {
        UIToggle();
        gameState = GameState.Death;
        death.gameObject.SetActive(true);
        playerC.Freeze(true);
    }
    
    public void Sound()
    {
        sound = !sound;
        
        string temp = sound == true ? "On" : "Off";
        GameObject.Find("soundBtnText").GetComponent<TextMeshProUGUI>().text = temp;
    }

    public void Music()
    {
        music = !music;
        
        string temp = music == true ? "On" : "Off";
        GameObject.Find("musicBtnText").GetComponent<TextMeshProUGUI>().text = temp;
    }
    
    #endregion
    
    
}
