using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// Controls the aiming direction and rotation of a weapon based on the position of the mouse cursor.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for aiming the weapon.
    /// </summary>
    public class WeaponAim : MonoBehaviour
    {
        private GameManager _gameManager;

        void Start()
        {
            _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_gameManager.gameState == GameManager.GameState.Game)
            {
                Vector3 dir = Camera.main.WorldToScreenPoint(transform.position);
                Vector3 mousePos = Input.mousePosition - dir;
                var angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                if (mousePos.x < 0)
                {
                    transform.localScale = new Vector3(1, -1, 1);
                }

                if (mousePos.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}