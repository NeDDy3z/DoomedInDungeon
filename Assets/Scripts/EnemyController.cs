using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.UIElements;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType
    {
        Minion_Small, //Meele - sword etc...
        Minion_Medium, //Basic weapon
        Minion_Large, //Strong weapon
        Boss //Hardcore mf
    }

    public float speed;
    public float minimumDistance;
    public float hp;
    public EnemyType _enemyType;

    public Animator _animator;

    public GameObject weapon;
    private WeaponController _weaponController;
    private Animator weaponAnim;

    private Rigidbody2D rb;
    private Vector3 oldPos;
    private GameObject player;
    private PlayerDetection _playerDetection;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player");
        _playerDetection = gameObject.GetComponent<PlayerDetection>();

        _weaponController = weapon.transform.transform.GetComponent<WeaponController>();

        if (weapon != null)
        {
            weaponAnim = weapon.GetComponent<Animator>();
        }
        
        if (_enemyType == EnemyType.Minion_Medium)
        {
            InvokeRepeating("EnemyFire", 2f, 2f);
        }

        if (_enemyType == EnemyType.Minion_Large)
        {
            InvokeRepeating("EnemyFire", 2f, 5f);
        }
    }

    private void FixedUpdate()
    {
        oldPos = transform.position;
        if (_playerDetection.playerVisible)
        {
            rb.MovePosition(player.transform.position);
            transform.position =
                Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            if (transform.position.x < oldPos.x)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if (transform.position.x > oldPos.x)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        
        if (transform.position != oldPos)
        {
            _animator.SetBool("Moving", true);
        }
        else if (transform.position == oldPos)
        {
            _animator.SetBool("Moving", false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        //melee
        if (col.gameObject.tag == "Player")
        {
            weaponAnim.SetBool("Attack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            weaponAnim.SetBool("Attack", false);
        }
    }


    private void EnemyFire()
    {
        if (_playerDetection.playerVisible)
        {
            _weaponController.Fire();
            Debug.Log("Enemy fired");
        }
    }

    public void Damage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        _animator.SetBool("Moving", false);
        Destroy(transform.gameObject);
    }
    
}
