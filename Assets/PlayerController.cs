using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    // [SerializeField] private GameObject bulletPrefab;
    // [SerializeField] private Transform firingPoint;

    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public int  DEFAULT_HEALTH = 5;

    // private float mx;
    // private float my;
    // private Vector2 mousePos;

    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    int isAlive;
    int health;


    // Start is called before the first frame update
    void Start()
    {   
        health = DEFAULT_HEALTH;
        PlayerPrefs.SetInt("playerHealth", health);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        isAlive = 1;
        PlayerPrefs.SetInt("isPlayerAlive", isAlive);
    }

    // Update is called once per frame
    void Update()
    {

        // mx = Input.GetAxisRaw("Horizontal");
        // my = Input.GetAxisRaw("Vertical");

        // mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        // if (Input.GetMouseButtonDown(0)) {
        //     Tembak();
        // }
    }

    // private void Tembak() {
    //     Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    // }

    void FixedUpdate() {
        health = PlayerPrefs.GetInt("playerHealth");
        if (PlayerPrefs.GetInt("isPlayerAlive") == 0) {
            animator.SetBool("isDeath", true);
            return;
        } else {

            if (movementInput != Vector2.zero) {
                bool sukses = TryMove(movementInput);

                if (!sukses && movementInput.x > 0) {
                    sukses = TryMove(new Vector2(movementInput.x, 0));

                }

                if (!sukses && movementInput.y > 0) {
                    sukses = TryMove(new Vector2(0, movementInput.y));
                }

                if (!sukses && movementInput.x < 0) {
                    sukses = TryMove(new Vector2(movementInput.x, 0));

                }

                if (!sukses && movementInput.y < 0) {
                    sukses = TryMove(new Vector2(0, movementInput.y));
                }

                animator.SetBool("isMoving", sukses);

            } else {
                animator.SetBool("isMoving", false);
            }

            if (movementInput.x < 0) {
                sr.flipX = true;
            } else if (movementInput.x > 0) {
                sr.flipX = false;
            }
        }
    }

    private bool TryMove(Vector2 direction) {
        int count = rb.Cast(
            direction,
            movementFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
        );

        if (count == 0) {
            rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
            return true;
        } else {
            return false;
        }
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();

    }

}
