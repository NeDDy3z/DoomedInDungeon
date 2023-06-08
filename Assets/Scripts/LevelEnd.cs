using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



/// <summary>
/// Triggers the end of a level when the player enters a specified collider.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for triggering the end of a level.
    /// </summary>
    public class LevelEnd : MonoBehaviour
    {
        private GameManager _gameManager;
        private PlayerController _playerController;

        public int sceneBuildIndex;
        public bool Demo;

        void Start()
        {
            _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        }

        /// <summary>
        /// Called when the collider of the level end is triggered by the player.
        /// </summary>
        /// <param name="col">The collider that triggered the event.</param>
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player" || col.gameObject.tag == "HitboxPlayer")
            {
                if (sceneBuildIndex == 6)
                {
                    _gameManager.End();
                }
                else
                {
                    SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                }

                Debug.Log("Player entered end of level");
            }
        }
    }
}
