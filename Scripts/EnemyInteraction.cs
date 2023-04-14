using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    public float hp;
    public float maxHP;
    public float damage;
    public Player player;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Player>().TakeDamage(damage);
    }
    public void TakeDamage(float amout)
    {
        hp -= player.damage;
        if (hp <= 0)
        {
            anim.SetBool("Death", true);
            Destroy(gameObject, 1f);
        }
    }
}