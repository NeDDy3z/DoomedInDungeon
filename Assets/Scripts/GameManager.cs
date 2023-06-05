using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private PlayerController _playerController;

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
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            UIToggle();
            mainMenu.gameObject.SetActive(true);
        }
        else
        {
            NextLevel();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Death();
        }
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

    public void StartGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1, LoadSceneMode.Single);
            Debug.Log("Game started");
        }
    }
    
    public void NextLevel()
    {
        gameState = GameState.Game;
        
        UIToggle();
        gui.gameObject.SetActive(true);
        
        _playerController = player.GetComponent<PlayerController>();

        _playerController.transform.position = new Vector3(0f, 0.075f, 0f);
        _playerController.SetMaxHP();
        
        Time.timeScale = 1;
        
        Debug.Log("Next level entered");
    }
    
    #region UI
    public void Menu()
    {
        gameState = GameState.Menu;
        
        UIToggle();
        mainMenu.SetActive(true);
    }

    public void Levels()
    {
        gameState = GameState.Levels;
        
        UIToggle();
        levels.gameObject.SetActive(true);
    }

    public void Options()
    {
        gameState = GameState.Options;
        
        UIToggle();
        options.gameObject.SetActive(true);
    }

    public void Credits()
    {
        gameState = GameState.Credits;
        
        UIToggle();
        credits.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void End()
    {
        
    }
    
    public void Pause()
    {
        switch (gameState)
        {
            case GameState.Game:
                gameState = GameState.Pause;
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;

            case GameState.Pause:
                gameState = GameState.Game;
                pauseMenu.gameObject.SetActive(false);
                Time.timeScale = 1;
                break;
            
            default:
                gameState = GameState.Pause;
                pauseMenu.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }
    }

    public void Death()
    {
        UIToggle();
        gameState = GameState.Death;
        death.gameObject.SetActive(true);
        
        Time.timeScale = 0;
    }

    public void Sound()
    {
        sound = !sound;

        string temp;
        if (sound)
        {
            temp = "On";
        }
        else
        {
            temp = "Off";
        }
        GameObject.Find("soundBtnText").GetComponent<TextMeshProUGUI>().text = temp;
    }

    public void Music()
    {
        music = !music;

        string temp;
        if (music)
        {
            temp = "On";
        }
        else
        {
            temp = "Off";
        }
        GameObject.Find("musicBtnText").GetComponent<TextMeshProUGUI>().text = temp;
    }

    #endregion
}
