﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhysicsMovement : MonoBehaviour
{

    public PlayerMovement controller;
    public Animator animator;
    float horizontalMove = 0f;
    public  static float runSpeed = 10f;
    bool jump = false;

    public GameObject playerAttack, attackSpawner;
    public static string keyPressedLast = "right";
    public float playerAttackCooldown = 0.5f;

    public float stopMoveWhileShootTimer;
    public float jumpAgainTimer;

    public bool playerCanMove = true;

    public void Start()
    {
        runSpeed = 10;
    }

    void Update()
    {
        //counts down the timer that allows the player to move after shooting 
        //anything below 0 allows the player to move
        stopMoveWhileShootTimer -= Time.deltaTime;
        jumpAgainTimer -= Time.deltaTime;

        //if the timer is below 0, can move
        //otherwise no
        if (stopMoveWhileShootTimer <= 0)
        {
            playerCanMove = true;
        }
        else{
            playerCanMove = false;
        }

        //if the player is allowed to move, run everything in here
        if (playerCanMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
            animator.SetFloat("speed", Mathf.Abs(horizontalMove));
            if (jumpAgainTimer <= 0)
            {
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                {
                    jump = true;
                    animator.SetBool("IsJumping", true);
                }
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                keyPressedLast = "left";
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                keyPressedLast = "right";
            }
        }
        //if the player is not allowed to move, set it's movement vector to 0, which means no movement
        //I would suggest that you make it so that the shooting animation overrides the other animations and is forced to play through the full loop before allowing the other animations to play
        else
        {
            horizontalMove = 0;
        }

        Debug.Log(horizontalMove);


        //timer to see if player is allowed to attack again
        playerAttackCooldown -= Time.deltaTime;
        if (playerAttackCooldown <= 0 && jump == false && BatteryBarSliderController.batterySliderCurrent >= 1)
        {
            //made space shoot now
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("Shoot");
                animator.SetTrigger("Stop");
            }
        }
    }

    public void stopMovement() 
    {
        playerCanMove = false;
        //CHANGE THIS FLOAT HERE TO ADJUST HOW LONG BOI CAN'T MOVE FOR AFTER SHOOTING
        stopMoveWhileShootTimer = 1f;

    }

    public void Shoot()
    {
        //shoots the bullet, prevents shooting again for 1 second, removes one from battery amount and prevents player movement
        PlayerShootSound.PlayerShootBool = true;
        Instantiate(playerAttack, attackSpawner.transform.position, attackSpawner.transform.rotation);
        playerAttackCooldown = 1;
        BatteryBarSliderController.batterySliderCurrent--;
    }

    public void OnLanding()
    {
        jump = false;
        jumpAgainTimer = 0.1f;
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        //jump = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if the player collides with a pickup, restore battery to full (easy to make whatever you want) and destroy the battery
        if (other.gameObject.CompareTag("Pickup"))
        {
            BatteryBarSliderController.batterySliderCurrent = 5;
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            PlayerDeath.PlayerDeathBool = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
