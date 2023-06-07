using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Scripts
{
    public class WeaponMelee : MonoBehaviour
    {
        public float damage;

        private BoxCollider2D meeleWeaponCollider;

        private GameObject player;
        private PlayerController _playerController;


        // Start is called before the first frame update
        void Awake()
        {
            meeleWeaponCollider = gameObject.GetComponent<BoxCollider2D>();

            player = GameObject.FindWithTag("Player");
            _playerController = player.GetComponent<PlayerController>();

        }

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
