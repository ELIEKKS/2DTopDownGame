using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stabbing : MonoBehaviour
{

    public Animator animator;
    public AudioClip stabbing;
    public Transform attackPoint;
    public float attackSpeed;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int swordDamage;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            AudioSource.PlayClipAtPoint(stabbing, transform.position);
            Attack();
        }  
    }

    public void Attack()
    {

        animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if(enemy.GetComponent<bossHealth>()!= null)
            {
                enemy.GetComponent<bossHealth>().TakeDamage(swordDamage);
            }

            if(enemy.GetComponent<EnemyHealth>() != null)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(swordDamage);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
