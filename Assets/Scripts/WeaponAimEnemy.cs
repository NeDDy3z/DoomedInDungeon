using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAimEnemy : MonoBehaviour
{
    public EnemyController _enemyController;
    public GameObject weapon;
    
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
                weapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
                if (direction.x < 0)
                {
                    weapon.transform.localScale = new Vector3(1, -1, 1);
                }

                if (direction.x > 0)
                {
                    weapon.transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }
    }
}
