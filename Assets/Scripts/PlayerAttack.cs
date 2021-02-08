using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;

    public float attackDestroyCooldown;
    // Start is called before the first frame update
    void Start()
    {
        //if the last key player pressed was left or right, shoot the bullet in that direction out of the bullet spawner
        if (PhysicsMovement.keyPressedLast == "left")
        {
            rb.velocity = new Vector3(-1, 0, 0) * speed;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (PhysicsMovement.keyPressedLast == "right")
        {
            rb.velocity = new Vector3(1, 0, 0) * speed;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //destroys the object after a time set in the inspector
        attackDestroyCooldown -= Time.deltaTime;
        if (attackDestroyCooldown <= 0)
        {
            Destroy(gameObject);
        }
    }

    //different scenarios that the bullet will go bye bye
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Pickup")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Collider")
        {
            Destroy(gameObject);
        }
    }
}
