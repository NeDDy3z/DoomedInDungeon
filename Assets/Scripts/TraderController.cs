using System;
using UnityEngine;

namespace Scripts
{
    public class TraderController : MonoBehaviour
    {
        public GameObject tradingUi;

        private GameManager _gameManager;
        private GameObject player;
        private PlayerController _playerController;

        private bool tradable = false;

        void Start()
        {
            player = GameObject.FindWithTag("Player");
            _playerController = player.GetComponent<PlayerController>();
            _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();


            tradingUi.SetActive(false);
        }

        private void Update()
        {

        }


        public void HealBought()
        {
            if (_playerController.coins >= 20)
            {
                if (_playerController.hp != _playerController.maxHp)
                {
                    _playerController.Heal(30);
                    _playerController.SubtractCoins(20);
                    Debug.Log("Player bought heal");
                }
                else
                {
                    Debug.Log("Player tried to buy heal - has max HP");
                }
            }
            else
            {
                Debug.Log("Player tried to buy heal - has no money");
            }

        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            tradingUi.SetActive(true);
            _gameManager.gameState = GameManager.GameState.Trading;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            tradingUi.SetActive(false);
            _gameManager.gameState = GameManager.GameState.Game;
        }
        
    }
}
