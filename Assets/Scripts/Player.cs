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

    private int health = 100;
    private bool slowDownOn = false;

    private Vector2 moveDirection;
    private InputAction move;
    private InputAction fire;
    private InputAction slowDown;
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

        slowDown = playerControls.Player.SlowDown;
        slowDown.Enable();
        slowDown.performed += SlowDownActive;
        slowDown.canceled += SlowDownCancel;
        slowDown.started += SlowDownStarted;
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
        if (slowDownOn)
        {
            moveDirection = (playerControls.Player.Move.ReadValue<Vector2>() * 0.5f);
            if (gameObject.transform.GetChild(1).transform.localScale.x < 1)
            {
                Transform purpleArea = gameObject.transform.GetChild(1);
                float purpleAreaX = purpleArea.transform.localScale.x;
                float purpleAreaY = purpleArea.transform.localScale.y;

                purpleArea.transform.localScale = new Vector3(purpleAreaX + 0.001f, purpleAreaY + 0.001f, 0);
            }
        } else moveDirection = playerControls.Player.Move.ReadValue<Vector2>();
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

    private void SlowDownStarted(InputAction.CallbackContext context)
    {
        slowDownOn = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void SlowDownActive(InputAction.CallbackContext context)
    {
        slowDownOn = true;
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }

    private void SlowDownCancel(InputAction.CallbackContext context)
    {
        slowDownOn = false;
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
        gameObject.transform.GetChild(1).transform.localScale = new Vector3(0, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {

        } 
        
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health -= collision.gameObject.GetComponent<Projectile>().projDamage;
        }
    }
}
