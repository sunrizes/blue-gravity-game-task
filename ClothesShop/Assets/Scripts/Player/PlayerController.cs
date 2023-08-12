using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;

    private Rigidbody2D rb;

    [Header("Clothing Points")]
    public SpriteRenderer Head;
    public SpriteRenderer Torso;
    public SpriteRenderer Legs;
    public SpriteRenderer Feet;

    [Header("Player Settings")]
    public float moveSpeed;

    private Orientation orientation;

    private Vector2 playerMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        playerControls = new PlayerControls();

        playerControls.Player.Movement.performed += ctx => playerMovement = ctx.ReadValue<Vector2>();

        playerControls.Enable();

        orientation = Orientation.South;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + playerMovement * moveSpeed * Time.fixedDeltaTime);
    }
}