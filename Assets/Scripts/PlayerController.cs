
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;

    public SpriteRenderer _SpriteRenderer;
    public Animator _animator;
    
    private Rigidbody2D rb;
    
    private bool freeze = true;
    private float moveHorizontal;
    private float moveVertical;
    
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    { 
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 moveInput = new Vector3(
            moveHorizontal * Time.deltaTime * movementSpeed,
            moveVertical * Time.deltaTime * movementSpeed, 0);

        if (!freeze) rb.MovePosition(transform.position += moveInput);
        
        if (moveHorizontal < 0) _SpriteRenderer.flipX = true;
        if (moveHorizontal > 0) _SpriteRenderer.flipX = false;
    }

    public void Freeze(bool choice)
    {
        freeze = choice;
    }

    
    
    
}