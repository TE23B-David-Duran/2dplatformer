using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    [SerializeField]
    float jumpforce = 10;

    bool mayJump = true;

    [SerializeField]
    Transform groundChecker;

    [SerializeField]
    LayerMask groundLayer;

    [SerializeField]
    float speed = 0.2f;

    void Update()
    {
        // Movement höger vänster
        float xInput = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(xInput,0) * speed * Time.deltaTime; // Movement
        
        transform.Translate(movement);

        // Movement upp/hoppa
        if (Input.GetAxisRaw("Jump") > 0 && mayJump == true && IsGrounded())
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * jumpforce);
            mayJump = false;

        }

        if (Input.GetAxisRaw("Jump") == 0)
        {
            mayJump = true;
            
        }

    }
    // För att kolla om du är på
    private bool IsGrounded()
    {
        if (Physics2D.OverlapCircle(groundChecker.position, .2f,groundLayer))
        {
            return true;
        }

        else
        {
            return false;
        }
    }

}
