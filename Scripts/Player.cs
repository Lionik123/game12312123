using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float hp;
    public float maxHP;
    public float damage = 1f;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public float speed;
    public float jumpForce;
    private float moveInput;
    public Animator anim;

    public float AttackRange;
    public LayerMask enemy;
    public Transform attackPos;

    private bool isGrounded;
    private bool onGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask WhatIsGround;

    private Rigidbody2D rb;
    private bool faceRight = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (faceRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (faceRight == true && moveInput < 0)
        {
            Flip();
        }

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
    }
    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, WhatIsGround);
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
            anim.SetTrigger("Takeoff");
        }
        if (isGrounded == true)
        {
            anim.SetBool("isJumping", false);
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
        if (timeBtwAttack <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                anim.SetTrigger("Attack");
                timeBtwAttack = startTimeBtwAttack;
            }       
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        if (transform.position.y < -8)
        {
            Die();
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            anim.SetBool("Death", true);
            Invoke("Die", 1.3f);
        }
    }

    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, AttackRange, enemy);
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyInteraction>().TakeDamage(damage);
        }
    }
}