using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player OtherPlayer;
    public PlayerAttributes PlayerAttributes;

    public float TimeUntilSwap {get; private set;}

    private Rigidbody2D rb;

    //reference to the animator as I try to animate the character
    private Animator animator;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();

        //animation
        animator = GetComponent<Animator>();
    }

    private void OnEnable() 
    {
        TimeUntilSwap = PlayerAttributes.ControlDuration;
    }

    private void Update() 
    {
        // Movement
        var movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity =  movement * PlayerAttributes.MovementSpeed;

        //Animation
        //if the player is moving, get their direction and play the correct animation
        if (movement != Vector2.zero)
        {
            animator.SetBool("isMoving", true);
            animator.SetFloat("MoveX", movement.x);
            animator.SetFloat("MoveY", movement.y);
        }
        else
        {   
            //let the animator know to go into idle animation
            animator.SetBool("isMoving", false);
        }

        // Check for control swap
        TimeUntilSwap -= Time.deltaTime;
        if (TimeUntilSwap <= 0) 
        {
            //tell the animator this character is no longer moving
            animator.SetBool("isMoving", false);

            SwapControl();
        }
    }

    private void SwapControl()
    {
        OtherPlayer.enabled = true;
        enabled = false;
        rb.velocity = Vector2.zero;
    }
}
