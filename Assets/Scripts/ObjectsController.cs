using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


/// <summary>
/// Controls the behavior of objects that can be picked up by the player.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for controlling objects that can be picked up by the player.
    /// </summary>
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

        /// <summary>
        /// Called when a collider enters the trigger collider of the object.
        /// </summary>
        /// <param name="col">The collider that entered the trigger.</param>
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