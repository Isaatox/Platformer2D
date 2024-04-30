using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;
    public Animator animator;
    private Image healthBarImage;
    public float maxHealth = 100f;
    private float currentHealth;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        if (healthBarImage == null)
        {
            healthBarImage = GetComponent<Image>();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBarImage.fillAmount = currentHealth / maxHealth;
        if (currentHealth <= 0)
        {
            animator.SetTrigger("Die");
            animator.SetBool("isNotDie", true);
        }
    }

    public void Heal(float heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBarImage.fillAmount = currentHealth / maxHealth;
    }

    public float CurrentHealth // Changed to a property for better usage
    {
        get { return currentHealth; }
    }
}
