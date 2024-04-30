using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Damage : MonoBehaviour
{
    public int damage = 10;
    public int fireDamage = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (fireDamage > 0)
            {
                StartCoroutine(ApplyFireDamage(collision));
            }
            else
            {
                HealthBar.Instance.TakeDamage(damage);
            }
        }
    }

    private IEnumerator ApplyFireDamage(Collider2D collision)
    {
        for (int i = 0; i < 5; i++)
        {
            HealthBar.Instance.TakeDamage(fireDamage);
            if (HealthBar.Instance.CurrentHealth <= 0)
            {
                break;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
