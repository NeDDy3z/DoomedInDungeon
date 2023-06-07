using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

namespace Scripts
{
    public class ObjectsController : MonoBehaviour
    {
        public int amount;

        private GameObject player;
        private PlayerController _playerController;


        void Awake()
        {
            player = GameObject.FindWithTag("Player");
            _playerController = player.GetComponent<PlayerController>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                if (gameObject.tag == "Damage")
                {
                    _playerController.Damage(amount);
                    Debug.Log("Player picked up damage");
                }

                if (gameObject.tag == "Heal")
                {
                    _playerController.Heal(amount);
                    Debug.Log("Player picked up heal");
                }

                if (gameObject.tag == "Coin")
                {
                    _playerController.AddCoins(amount);
                    Debug.Log("Player picked up coins");
                }

                gameObject.SetActive(false);
            }
        }
    }
}
