using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardControl : MonoBehaviour
{
    public float verticalSpeed;
    public float rotationSpeed;

    public GameObject bullet;
    public float reloadTime;
    private float reloadTimeTimer;

    private AmmoCollection ammo_collection;
    private HealthDisplay health_display;
    public Text ammoDisplay;

    void Start()
    {
        ammo_collection = GetComponent<AmmoCollection>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Vertical1"))
        {
            transform.Translate(-Vector3.right * Input.GetAxisRaw("Vertical1") * verticalSpeed);  // maybe smooth out movement?
        }
        if (Input.GetButton("Rotate1"))
        {
            transform.Rotate(0, 0, Input.GetAxisRaw("Rotate1") * -rotationSpeed);
        }
        if (Input.GetButton("Fire1") && reloadTimeTimer <= 0 && ammo_collection.ammoCount > 0)
        {
            Instantiate(bullet, transform.position - transform.right, transform.rotation);
            ammo_collection.ammoCount -= 1;
            ammoDisplay.text = "AMMO: " + ammo_collection.ammoCount;
            reloadTimeTimer = reloadTime;
        }
        reloadTimeTimer -= Time.deltaTime;

        if (health_display.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}