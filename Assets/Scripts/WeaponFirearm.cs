using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFirearm : MonoBehaviour
{
    public float damage;
    public float bulletSpeed;
    public Animator _animator;

    private GameObject player;
    private PlayerController _playerController;
    private PlayerManager _playerManager;

    private EnemyController _enemyController;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        _playerController = player.GetComponent<PlayerController>();
        _playerManager = player.GetComponent<PlayerManager>();

        _enemyController = transform.gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - mousePos;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") _playerManager.Damage(damage);
        if (col.gameObject.tag == "Enemy") _enemyController.Damage(damage);
    }

    public void Hit()
    {
        if (_playerManager.hp > 0) _playerManager.Damage(damage);
    }
    
    public void Fire()
    {
        
    }
    
}
