using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the aiming direction and rotation of an enemy weapon based on the position of the player.
/// </summary>
namespace Scripts
{
    /// <summary>
    /// Class responsible for aiming the enemy weapon.
    /// </summary>
    public class WeaponAimEnemy : MonoBehaviour
    {
        public EnemyController _enemyController;

        private GameManager _gameManager;
        private GameObject player;

        private EnemyController.EnemyType _enemyType;

        void Start()
        {
            _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
            player = GameObject.FindWithTag("Player");

            _enemyType = _enemyController._enemyType;
        }

        void Update()
        {
            if (_gameManager.gameState == GameManager.GameState.Game)
            {
                if (_enemyType == EnemyController.EnemyType.Minion_Medium)
                {
                    Vector3 direction = player.transform.position - transform.position;
                    var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                    if (direction.x < 0)
                    {
                        transform.localScale = new Vector3(1, -1, 1);
                    }

                    if (direction.x > 0)
                    {
                        transform.localScale = new Vector3(1, 1, 1);
                    }
                }
            }
        }
    }
}