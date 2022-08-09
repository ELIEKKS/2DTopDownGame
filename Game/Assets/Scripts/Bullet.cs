using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform damagePopUpText;
    public GameObject damagePopUp;
    public int bulletDamage;

    private void Start() 
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "EnemyRed")
        {
            DamagePopUp damagePopUpScript = damagePopUp.GetComponent<DamagePopUp>();
            var healthComponent = other.GetComponent<EnemyHealth>();
            damagePopUpScript.Create(transform.position, bulletDamage, damagePopUpText);
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }else if (other.tag == "Boss")
        {
            DamagePopUp damagePopUpScript = damagePopUp.GetComponent<DamagePopUp>();
            var healthComponent = other.GetComponent<bossHealth>();
            damagePopUpScript.Create(transform.position, bulletDamage, damagePopUpText);
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(bulletDamage);
            }
            Destroy(gameObject);
        }
    }
}
