using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using CMController;

public class EnemyController : MonoBehaviour
{
    Transform target;
    public float speed = 3f;
    public float rotationSpeed = 0.01f;

    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sr;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    
    
    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        try {
        if (!target) {
            GetTarget();
        } else {
            RotateTowardsTarget();
        } }
        catch {

        }
    }

    void FixedUpdate() {
        rb.velocity = transform.up * speed;
    }

    void GetTarget() {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void RotateTowardsTarget() {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 45f;

        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotationSpeed);

    }

    private void OnCollisionEnter2D(Collision2D other) {
     
        if (other.gameObject.tag == "Environment") {
            Physics2D.IgnoreCollision(other.collider, GetComponent<Collider2D>());
        }

        int playerHealth = PlayerPrefs.GetInt("playerHealth");
        bool isPlayer = other.gameObject.CompareTag("Player");

        if (isPlayer) {
            playerHealth--;
            Destroy(gameObject);
        }

        if (isPlayer && playerHealth == 0) {
            Destroy(other.gameObject, 0.4f);
            target = null;
            PlayerPrefs.SetInt("isPlayerAlive", 0);
        } else if (other.gameObject.CompareTag("Bullet")) { 
            Destroy(other.gameObject);
            Destroy(gameObject);
            int playerPoint = PlayerPrefs.GetInt("playerPoint");
            PlayerPrefs.SetInt("playerPoint", playerPoint + 1);

            if (playerPoint > PlayerPrefs.GetInt("playerBestPoint")) {
                PlayerPrefs.SetInt("playerBestPoint", playerPoint);
            }
        }

        PlayerPrefs.SetInt("playerHealth", playerHealth);
    }
}
