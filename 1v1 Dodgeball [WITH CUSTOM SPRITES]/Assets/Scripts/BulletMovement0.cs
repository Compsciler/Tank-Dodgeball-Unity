using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement0 : MonoBehaviour {

    public float speed;
    bool collided = false;
    public Rigidbody2D rb;

    public float despawnTime;
    float despawnTimer;

	// Use this for initialization
	void Start () {
        rb.AddForce(-(transform.right) * speed);
        despawnTimer = despawnTime;
    }


    // Update is called once per frame
    void Update()
    {
        /*
        while (collided == false)
        {
            transform.Translate(transform.up * speed);
        }
        */

        if (despawnTimer < 0)
        {
            Destroy(gameObject);
        }

        despawnTimer -= Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            collided = true;
        }

    }
}
