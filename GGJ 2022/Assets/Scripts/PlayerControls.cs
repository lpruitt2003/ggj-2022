using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

/**=====================================
Class PlayerControls
-------------------------
Description:

Manages and defines the behavior of the player's character.
Can go left and right, and jump once

--------------------------
Author(s):
Bryan Curchod
Selin Kaya
Edin Karakurt
=====================================*/
public class PlayerControls : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float jumpHeight = 8f;
    public float gravityScale = 1.5f;
    public Camera mainCamera; // camera that will follow the player

    bool facingRight = true;
    public float moveDirection = 0;
    public bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    // Start is called before the first frame update. Set the base value before starting up the game
    void Start()
    {
        
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }

        // Camera follow
        if (mainCamera)
        {
            // keep the Y and Z pos but set the X pos of the player
            mainCamera.transform.position = new Vector3(t.position.x, t.position.y, cameraPos.z);
        }

        
    }

    /** */
    void FixedUpdate()
        {
            // Debug.Log("in fixed update");
            Bounds colliderBounds = mainCollider.bounds;
            float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
            Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
            // Check if player is grounded
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
            //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
            isGrounded = false;
            if (colliders.Length > 0)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i] != mainCollider)
                    {
                        isGrounded = true;
                        break;
                    }
                }
            }

            // Apply movement velocity
            r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);

            // Simple debug
            Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
            Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);
        }
}
