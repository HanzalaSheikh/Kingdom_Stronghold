using UnityEngine;
using UnityEngine.UI;

// public class PlayerHealth : MonoBehaviour
// {
//     public int maxHealth = 100;
//     private int currentHealth;

//     public GameObject healthBarPrefab;
//     private GameObject healthBar;
//     private Slider healthBarSlider;
//     private bool isHealthBarVisible = false;

//     // Reference to the end point
//     public Transform endPoint;
//     public int goldReward = 10;
//     public int scoreReward = 100;

// void Start()
// {
//     currentHealth = maxHealth;

//     if (healthBar == null && healthBarPrefab != null)
//     {
//         // Instantiate the health bar if it's missing
//         healthBar = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity, transform);
//     }

//     healthBarSlider = healthBar.GetComponentInChildren<Slider>();
//     healthBarSlider.maxValue = maxHealth;
//     healthBarSlider.value = currentHealth;

//     healthBar.SetActive(false);
// }

//     void Update()
//     {
//         // Update the health bar's position to stay above the enemy
//         if (healthBar != null)
//         {
//             healthBar.transform.position = transform.position + new Vector3(0, 1, 0);
//         }

//         // Check if the enemy has reached the end point
//         if (Vector3.Distance(transform.position, endPoint.position) < 1f)
//         {
//             EndGame();
//         }
//     }

// public void TakeDamage(int damage)
// {
//     if (!isHealthBarVisible)
//     {
//         ShowHealthBar();
//     }

//     currentHealth -= damage;
//     UpdateHealthBar();

//     if (currentHealth <= 0)
//     {
//         if (gameObject != null)  // Check if the gameObject still exists
//         {
//             Die();
//         }
//     }
// }




//     void UpdateHealthBar()
//     {
//         // Update the value of the slider
//         healthBarSlider.value = currentHealth;

//         // Ensure the health bar is visible when taking damage
//         if (!isHealthBarVisible)
//         {
//             healthBar.SetActive(true);
//             isHealthBarVisible = true;
//         }
//     }

//     void ShowHealthBar()
//     {
//         healthBar.SetActive(true);
//         isHealthBarVisible = true;
//     }

// void Die()
// {
//     if (healthBar != null)
//     {
//         Destroy(healthBar); // Destroy health bar on death
//     }

//     Debug.Log("Player Died");

//     GameManager.instance.AddGold(goldReward);
//     GameManager.instance.AddScore(scoreReward);

//     // Destroy the enemy
//     Destroy(gameObject);

//     // Check if there are any enemies left
//     if (GameObject.FindGameObjectsWithTag("Enemy").Length == 1) // Since this enemy is about to be destroyed
//     {
//         // No more enemies, trigger game over
//         GameOverManager.instance.GameOver(GameManager.instance.GetScore());
//     }
// }



// void EndGame()
// {

//      if (GameOverManager.instance != null)
//     {
//         // Call Game Over method from GameOverManager and pass the current score
//         GameOverManager.instance.GameOver(GameManager.instance.GetScore());
//     }
//     else
//     {
//         Debug.LogError("GameOverManager instance is null! Make sure it's properly set in the scene.");
//     }

//     // Call GameOver method from GameOverManager and pass the final score from GameManager
//     int finalScore = GameManager.instance.GetScore();
//     GameOverManager.instance.GameOver(finalScore);

//     // Optionally, destroy the enemy if needed
//     Destroy(gameObject);
// }


//     void OnMouseDown()
//     {
//         ShowHealthBar();
//     }

//     void EnemyReachedEndPoint()
// {
//     // Call the GameOver method from the GameOverManager and pass the final score
//     GameOverManager.instance.GameOver(GameManager.instance.GetScore());
// }

    
// }

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject healthBarPrefab;
    private GameObject healthBar;
    private Slider healthBarSlider;
    private bool isHealthBarVisible = false;

    // Add a public variable for gold coins this enemy gives when killed
    public int goldReward = 10;
    public int scoreReward = 100;

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

        // Add gold and score when the enemy dies
        GameManager.instance.AddGold(goldReward);
        GameManager.instance.AddScore(scoreReward);

        Destroy(healthBar); // Destroy health bar on death
        Destroy(gameObject); // Destroy the enemy
    }

    void OnMouseDown()
    {
        ShowHealthBar();
    }
}
