using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HeroMovement : MonoBehaviour
{
 public float moveSpeed = 5f;
 public Rigidbody2D rb;
 public Animator animator;
 public VectorValue startingPosition;
    int currentIdle = 0;

Vector2 movement;

    void Start()
    {
        if (startingPosition.initialValue != null) { 
        transform.position = startingPosition.initialValue;
        }
    }
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            transform.position = Vector3.MoveTowards(transform.position, touchPosition, 5 * moveSpeed * Time.deltaTime);
        }

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if(Input.GetAxisRaw("Horizontal") > 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                animator.SetInteger("CurrentIdle", 3);
            }
            else if(Input.GetAxisRaw("Horizontal") < 0 && Input.GetAxisRaw("Vertical") == 0)
            {
                animator.SetInteger("CurrentIdle", 2);
            }
            else if(Input.GetAxisRaw("Vertical") > 0)
            {
                animator.SetInteger("CurrentIdle", 1);
            }
            else
            {
                animator.SetInteger("CurrentIdle", 0);
            }
        }

        animator.SetFloat("Horizontal", movement.x);
       animator.SetFloat("Vertical", movement.y);
       animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
}
