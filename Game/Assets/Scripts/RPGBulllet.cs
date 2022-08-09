using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGBulllet : MonoBehaviour
{
    
    public LayerMask enemyLayers;
    public float explosionRadius;
    public int explosionDamage;
    


    public float knockbackForce;



    public void Explode()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(base.transform.position, explosionRadius, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(explosionDamage);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            Vector2 difference = (transform.position - enemy.transform.position).normalized;
            Vector2 force = difference * knockbackForce;
            enemyScript.rb.AddForce(force, ForceMode2D.Impulse);
        }
    }

}
