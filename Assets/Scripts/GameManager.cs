using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vector3 = UnityEngine.Vector3;

namespace Scripts
{
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
    public SoundEffects _soundEffects;
    
    public GameState gameState;

    public GameObject player;
    private PlayerController _playerController;

    private bool sound = true;
    private bool music = true;

    /// <summary>
    /// Possible game states.
    /// </summary>
    public enum GameState
    {
        Menu,
        Game,
        Pause,
        Levels,
        Options,
        Credits,
        Trading,
        Death
    }

    /// <summary>
    /// Called before the first frame update.
    /// </summary>
    void Start()
    {
        Debug.Log("ACTIVE SCENE: "+ SceneManager.GetActiveScene().buildIndex);
        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            UIOff();
            mainMenu.gameObject.SetActive(true);
        }
        else
        {
            gameState = GameState.Game;
        
            UIOff();
            gui.gameObject.SetActive(true);
        
            _playerController = player.GetComponent<PlayerController>();
            _playerController.transform.position = new Vector3(0f, 0.075f, 0f);
            _playerController.SetMaxHP();
        
            Time.timeScale = 1;
        
            Debug.Log("Next level entered");
        }
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
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

    /// <summary>
    /// Deactivates all UI elements.
    /// </summary>
    void UIOff()
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

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        Debug.Log("Game started");
        
        gameState = GameState.Game;
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
    

    #region UI
    /// <summary>
    /// Displays the main menu UI.
    /// </summary>
    public void Menu()
    {
        gameState = GameState.Menu;
        
        UIOff();
        mainMenu.gameObject.SetActive(true);
    }

    /// <summary>
    /// Displays the levels UI.
    /// </summary>
    public void Levels()
    {
        gameState = GameState.Levels;
        
        UIOff();
        levels.gameObject.SetActive(true);
    }

   /// <summary>
        /// Displays the options UI.
        /// </summary>
        public void Options()
        {
            gameState = GameState.Options;

            UIOff();
            options.gameObject.SetActive(true);
        }

        /// <summary>
        /// Displays the credits UI.
        /// </summary>
        public void Credits()
        {
            gameState = GameState.Credits;

            UIOff();
            credits.gameObject.SetActive(true);
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        public void ExitGame()
        {
            Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        public void End()
        {

        }

        /// <summary>
        /// Pauses or resumes the game.
        /// </summary>
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
            }
        }

        /// <summary>
        /// Handles player death.
        /// </summary>
        public void Death()
        {
            UIOff();
            gameState = GameState.Death;
            death.gameObject.SetActive(true);
        }

        /// <summary>
        /// Toggles sound on or off.
        /// </summary>
        public void Sound()
        {
            sound = !sound;

            string temp;
            if (sound)
            {
                temp = "On";
                PlayerPrefs.SetInt("sound", 1);
            }
            else
            {
                temp = "Off";
                PlayerPrefs.SetInt("sound", 0);
            }
            GameObject.Find("soundBtnText").GetComponent<TextMeshProUGUI>().text = temp;
        }

        /// <summary>
        /// Toggles music on or off.
        /// </summary>
        public void Music()
        {
            music = !music;

            string temp;
            if (music)
            {
                temp = "On";
                PlayerPrefs.SetInt("music", 1);
            }
            else
            {
                temp = "Off";
                PlayerPrefs.SetInt("music", 0);
            }
            GameObject.Find("musicBtnText").GetComponent<TextMeshProUGUI>().text = temp;
        }

        // End of UI region
        #endregion
    }
}

