using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Player OtherPlayer;
    public PlayerAttributes PlayerAttributes;

    public float TimeUntilSwap {get; private set;}

    private Rigidbody2D rb;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
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

        // Check for control swap
        TimeUntilSwap -= Time.deltaTime;
        if (TimeUntilSwap <= 0) 
        {
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
