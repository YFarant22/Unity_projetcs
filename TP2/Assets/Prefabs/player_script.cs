using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;

public class player_script : MonoBehaviour
{
    public Vector2 jumpForce = new Vector2(0, 10f);
    private Rigidbody2D rb;
    private State playerState;
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        playerState = State.onFloor;
    }

    private bool JumpOrder()
    {
        if (Input.GetKeyDown("w") || Input.GetKeyDown("z") || Input.GetKeyDown("space") || Input.GetKeyDown("up"))
            return (true);
        return (false);
    }
    private void Update()
    {
        if (JumpOrder() && playerState == State.onFloor)
        {
            rb.AddForce(jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            playerState = State.onFloor;
        }
        else
        {
            playerState = State.inAir;
        }
    }
}
public enum State
{
    onFloor,
    inAir
};