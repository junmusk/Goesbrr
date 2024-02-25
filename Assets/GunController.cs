using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [Range(0.1f, 2f)]
    [SerializeField] private float fireRate = 0.5f;


    private float mx;
    private float my;
    private Vector2 mousePos;

    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        mx = Input.GetAxisRaw("Horizontal");
        my = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButtonDown(0) && fireTimer <= 0f) {
            Tembak();
            fireTimer = fireRate;
        } else {
            fireTimer -= Time.deltaTime;
        }
    }

    private void Tembak() {
        Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
    }

}