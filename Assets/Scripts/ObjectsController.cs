using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ObjectsController : MonoBehaviour
{
    private GameObject player;
    private PlayerManager _playerManager;
    private PlayerController _playerController;
    
    public int amount;
    
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
        _playerManager = player.GetComponent<PlayerManager>();
        _playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Damage") _playerManager.Damage(amount);
            if (gameObject.tag == "Heal") _playerManager.Heal(amount);
            if (gameObject.tag == "Coin") _playerManager.AddCoins(amount);
            gameObject.SetActive(false);
        }
    }
    
}
