using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FruitBehaviour : MonoBehaviour
{
    public GameObject CollectedPrefab;
    public int healthEffect = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.AddFruit();
            HealthBar.Instance.Heal(healthEffect);
            Destroy(gameObject);
            Instantiate(CollectedPrefab, transform.position, Quaternion.identity);
        }
    }
}
