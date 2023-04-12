using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapSwitcher : MonoBehaviour
{
    private GameManager _gameManager;
    private PlayerController _playerController;
    public bool Demo;

    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        _playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "HitboxPlayer")
        {
            if (Demo) _gameManager.Menu();
            else _gameManager.NextLevel(_gameManager.levelNumber + 1);
            
            Debug.Log("Level switch from: "+ _gameManager.levelNumber +" - to: "+ _gameManager.levelNumber + 1);
        }
       
    }
}
