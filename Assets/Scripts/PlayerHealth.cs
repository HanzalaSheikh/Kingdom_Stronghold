using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject healthBarPrefab;
    private GameObject healthBar;
    private Slider healthBarSlider;
    private bool isHealthBarVisible = false;

    void Start()
    {
        currentHealth = maxHealth;

        // Instantiate the health bar and set it as a child of the enemy
        healthBar = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity, transform);

        // Find the Slider component
        healthBarSlider = healthBar.GetComponentInChildren<Slider>();

        // Initialize the slider's max value
        healthBarSlider.maxValue = maxHealth;
        healthBarSlider.value = currentHealth;

        // Start with the health bar hidden
        healthBar.SetActive(false);
    }

    void Update()
    {
        // Update the health bar's position to stay above the enemy
        if (healthBar != null)
        {
            healthBar.transform.position = transform.position + new Vector3(0, 1, 0);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isHealthBarVisible)
        {
            ShowHealthBar();
        }

        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        // Update the value of the slider
        healthBarSlider.value = currentHealth;

        // Ensure the health bar is visible when taking damage
        if (!isHealthBarVisible)
        {
            healthBar.SetActive(true);
            isHealthBarVisible = true;
        }
    }

    void ShowHealthBar()
    {
        healthBar.SetActive(true);
        isHealthBarVisible = true;
    }

    void Die()
    {
        // Handle player death
        Debug.Log("Player Died");
        Destroy(healthBar); // Destroy health bar on death
        Destroy(gameObject); // Destroy the enemy
    }

    void OnMouseDown()
    {
        ShowHealthBar();
    }
}
