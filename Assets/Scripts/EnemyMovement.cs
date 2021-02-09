using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Animator Anim;
    public GameObject alertSprite;
    public bool playerInRange = false;
    public Vector3 target;
    public Vector3 position;
    public GameObject PlayerPosition;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        playerInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange == true)
        {
            Anim.SetBool("EnemySpotted", true);
            float step = speed * Time.deltaTime;
            target = new Vector3(PlayerPosition.transform.position.x, PlayerPosition.transform.position.y, PlayerPosition.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else 
        {
            Anim.SetBool("EnemySpotted", false);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alertSprite.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alertSprite.SetActive(false);
            playerInRange = false;
            
        }
    }
}
