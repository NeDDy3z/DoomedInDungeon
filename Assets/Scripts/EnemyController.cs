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
    public EnemyType _enemyType;

    public Animator _animator;

    public GameObject weapon;
    private Animator weaponAnim;

    private Rigidbody2D rb;
    private Vector3 oldPos;
    private GameObject player;
    private PlayerController _playerController;
    private PlayerManager _playerManager;

    private bool dealDmg = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

        player = GameObject.FindWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
        _playerManager = player.GetComponent<PlayerManager>();

        if (weapon != null) weaponAnim = weapon.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        oldPos = gameObject.transform.position;

        rb.MovePosition(player.transform.position);

        if (gameObject.transform.position != oldPos) _animator.SetBool("Moving", true);
        else _animator.SetBool("Moving", false);

        transform.position = Vector2.MoveTowards(gameObject.transform.position,
            player.transform.position, speed * Time.deltaTime);
        
        if (gameObject.transform.position.x < oldPos.x) transform.localRotation = Quaternion.Euler(0, 180, 0);
        else if (gameObject.transform.position.x > oldPos.x) transform.localRotation = Quaternion.Euler(0, 0, 0);
        
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
}