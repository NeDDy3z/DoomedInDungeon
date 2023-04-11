using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;

    public GameObject character;
    public GameObject weapon;
    public Animator _animator;
    
    private Rigidbody2D rb;

    private bool freeze;
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 mousePos;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        var dir = Camera.main.WorldToScreenPoint(transform.position);
        mousePos = Input.mousePosition - dir;
    }

    void FixedUpdate()
    {
        Vector3 moveInput = new Vector3(
            moveHorizontal * Time.deltaTime * movementSpeed,
            moveVertical * Time.deltaTime * movementSpeed, 0);

        if (!freeze) rb.MovePosition(transform.position += moveInput);

        if (mousePos.x < 0) character.transform.localRotation = Quaternion.Euler(0, 180f, 0);
        if (mousePos.x > 0) character.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void Freeze(bool choice)
    {
        freeze = choice;
    }
}