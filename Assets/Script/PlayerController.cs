using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    public Vector3 jump;
    public bool isGrounded;

    private float jumpForce = 2f;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private int collected;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        isGrounded = true;
        collected = 0;
        speed = 5;
    }

    void OnMove(InputValue movementValue)  
    { 
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

    void FixedUpdate() 
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    void OnCollisionStay(){
        isGrounded = true;
    }

    void OnJump()
    {
        if(isGrounded){
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("Ankh")) {
            other.gameObject.SetActive(false);
            collected++;
        }
    }
}
