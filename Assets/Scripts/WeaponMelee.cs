using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Deals damage to the player when a hit occurs with the melee weapon.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for dealing damage to the player when a hit occurs with the melee weapon.
    /// </summary>
    public class WeaponMelee : MonoBehaviour
    {
        public float damage;

        private BoxCollider2D meleeWeaponCollider;

        private GameObject player;
        private PlayerController _playerController;


        // Start is called before the first frame update
        void Awake()
        {
            meleeWeaponCollider = gameObject.GetComponent<BoxCollider2D>();

            player = GameObject.FindWithTag("Player");
            _playerController = player.GetComponent<PlayerController>();
        }

        /// <summary>
        /// Inflicts damage to the player if the player's health is greater than 0.
        /// </summary>
        public void Hit()
        {
            if (_playerController.hp > 0)
            {
                _playerController.Damage(damage);
                Debug.Log("Player hit by enemy");
            }
        }
    }
}