using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Animator anim;
    private Rigidbody2D phys;
    public Transform Player;
    public float agroDistance;
    private bool playerDeath;

    private void Start()
    {
        phys = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, Player.position);
        if (distToPlayer < agroDistance)
        {
            startHunting();
        }
        else
        {
            stopHunting();
        }
    }
    void startHunting()
    {
        if (Player.position.x < transform.position.x)
        {
            phys.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(1, 1);
        }
        else 
        {
            phys.velocity = new Vector2(speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
    }
    void stopHunting()
    {
        phys.velocity = new Vector2(0, 0);
    }

}
