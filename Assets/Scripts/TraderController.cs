using System;
using UnityEngine;

public class TraderController : MonoBehaviour
{
    public GameObject tradingUi;

    private GameManager _gameManager;
    
    private bool tradable = false;
    
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        tradingUi.SetActive(false);
    }

    private void Update()
    {

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
