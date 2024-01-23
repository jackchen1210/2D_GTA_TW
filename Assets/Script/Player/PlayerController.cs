using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private WeaponController weaponController;
    [SerializeField] private PlayerDash playerDash;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float dashSpeed = 4;
    private PlayerControls playerControl;
    private int moveXAnimatorHash;
    private int moveYAnimatorHash;
    private Vector2 movement;
    private static PlayerController instance;

    public static PlayerController GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        playerControl = new PlayerControls();
        moveXAnimatorHash = Animator.StringToHash("MoveX");
        moveYAnimatorHash = Animator.StringToHash("MoveY");
        playerControl.Combat.Attack.started += Attack_started;
        playerControl.Movement.Dash.performed += Dash_performed;
    }

    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        StartCoroutine(PerformDash());
    }

    private IEnumerator PerformDash()
    {
        moveSpeed *= dashSpeed;
        playerDash.Show();
        yield return new WaitForSeconds(0.2f);
        moveSpeed /= dashSpeed;
        playerDash.Hide();
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
        PlayerMove();
    }
    private void PlayerMove()
    {
        var movement = playerControl.Movement.Move.ReadValue<Vector2>();
        if (movement == this.movement)
        {
            return;
        }
        this.movement = movement;
        animator.SetFloat(moveXAnimatorHash, movement.x);
        animator.SetFloat(moveYAnimatorHash, movement.y);
    }

    private void Attack_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        weaponController.Attack();
    }

    private void FixedUpdate()
    {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        var mousePos = Input.mousePosition;
        var playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        var isFlipX = mousePos.x < playerScreenPoint.x;
        spriteRenderer.flipX = isFlipX;

        var angle = MathF.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        weaponController.FlipXAndAngle(isFlipX, angle);
    }
}
