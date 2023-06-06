using System;
using UnityEngine;

public class TraderController : MonoBehaviour
{
    public GameObject tradingUi;

    private GameManager _gameManager;
    
    private bool tradable;
    
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        tradingUi.SetActive(false);
    }

    private void Update()
    {
        if (tradable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                tradingUi.SetActive(true);
                _gameManager.gameState = GameManager.GameState.Trading;
            }
        }
        
        if (_gameManager.gameState == GameManager.GameState.Trading && Input.GetKeyDown(KeyCode.E))
        {
            tradingUi.SetActive(false);
            _gameManager.gameState = GameManager.GameState.Game;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        tradable = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        tradable = false;
    }
}
