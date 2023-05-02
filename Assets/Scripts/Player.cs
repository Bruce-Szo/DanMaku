using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerControls playerControls;
    public Rigidbody2D rb;
    public Sprite projectileSprite;
    public ProjectileSystem projSystem;

    public float moveSpeed = 5f;

    private Vector2 moveDirection;
    private InputAction move;
    private InputAction fire;
    private Animator anim;

    private void Awake()
    {
        playerControls = new PlayerControls();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);

        // For character animation
        if (moveDirection.x < 0)
        {
            anim.SetBool("isLeft", true);
            anim.SetBool("isRight", false);
        }
        else if (moveDirection.x > 0)
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", true);
        } else
        {
            anim.SetBool("isLeft", false);
            anim.SetBool("isRight", false);
        }
    }

    private void Fire(InputAction.CallbackContext context)
    {
        projSystem.PlayerBaseShot(projectileSprite, 8f);
    }
}
