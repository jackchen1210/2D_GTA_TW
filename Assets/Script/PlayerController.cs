using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField]private float moveSpeed=1;
    private PlayerControls playerControl;
    private Vector2 movement;

    private void Awake()
    {
        playerControl = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }
    private void PlayerInput()
    {
        movement = playerControl.Movement.Move.ReadValue<Vector2>();
        animator.SetFloat("MoveX",movement.x);
        animator.SetFloat("MoveY",movement.y);
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void Move()
    {
        rb.MovePosition(rb.position+movement*(moveSpeed*Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        var mousePos = Input.mousePosition;
        var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        spriteRenderer.flipX = mousePos.x < playerScreenPoint.x;
    }
}
