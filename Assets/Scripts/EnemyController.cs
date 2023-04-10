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
    private Animator weaponAnim;

    private Rigidbody2D rb;
    private Vector3 oldPos;
    private GameObject player;
    private PlayerController _playerController;
    private PlayerManager _playerManager;
    private PlayerDetection _playerDetection;

    private bool dealDmg = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
        _playerManager = player.GetComponent<PlayerManager>();
        _playerDetection = gameObject.GetComponent<PlayerDetection>();

        if (weapon != null) weaponAnim = weapon.GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        oldPos = transform.position;
        if (_playerDetection.playerVisible)
        {
            rb.MovePosition(player.transform.position);
            transform.position =
                Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            if (transform.position.x < oldPos.x) transform.localRotation = Quaternion.Euler(0, 180, 0);
            else if (transform.position.x > oldPos.x) transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        if (transform.position != oldPos) _animator.SetBool("Moving", true);
        else if (transform.position == oldPos) _animator.SetBool("Moving", false);

        /*
        if (Vector2.Distance(transform.position, player.transform.position) < minimumDistance)
        {
        }
        */
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        //melee
        if (col.gameObject.tag == "Player") weaponAnim.SetBool("Attack", true);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") weaponAnim.SetBool("Attack", false);
    }

    

    public void Damage(float amount)
    {
        hp -= amount;
        if (hp <= 0) Death();
    }

    private void Death()
    {
        Destroy(this);
    }
    
}