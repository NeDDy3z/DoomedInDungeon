
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 2f;
    private bool freeze = true;

    private Rigidbody2D rb;

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
        Vector3 moveInput = new Vector3(moveHorizontal * Time.deltaTime * movementSpeed,
            moveVertical * Time.deltaTime * movementSpeed, 0);
        
        if (!freeze) rb.MovePosition(transform.position += moveInput);
    }

    public void Freeze(bool choice)
    {
        freeze = choice;
    }

    
    
    
}