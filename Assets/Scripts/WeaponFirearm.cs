using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponFirearm : MonoBehaviour
{
    public float damage;
    public float bulletSpeed;

    public GameObject bulletPrefab;
    public EntityType _EntityType;

    private GameManager _gameManager;
    private GameObject weapon;
    private Transform shootingPoint;
    private Animator _animator;
    
    public enum EntityType
    {
        Player,
        Enemy
    }

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        weapon = gameObject.transform.GetChild(0).gameObject;
        shootingPoint = weapon.transform.GetChild(1).gameObject.transform;
        _animator = weapon.transform.GetChild(0).gameObject.GetComponent<Animator>();
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

            if (mousePos.x < 0) transform.localScale = new Vector3(1, -1, 1);
            if (mousePos.x > 0) transform.localScale = new Vector3(1, 1, 1);

            //Firing on Leftmouse
            if (Input.GetMouseButtonDown(0)) Fire();
        }
    }


    public void Fire()
    {
        GameObject projectile = Instantiate(bulletPrefab, shootingPoint.position,
            shootingPoint.rotation);
        projectile.GetComponent<Rigidbody2D>()
            .AddForce(shootingPoint.right * 2, ForceMode2D.Impulse);
    }
}