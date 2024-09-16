using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goldText;

    private int score = 0;
    private int gold = 300;

    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void AddGold(int coins)
    {
        gold += coins;
        UpdateGoldText();
    }

    public bool CanAfford(int cost)
    {
        return gold >= cost;
    }

    public void SpendGold(int cost)
    {
        if (CanAfford(cost))
        {
            gold -= cost;
            UpdateGoldText();
        }
        else
        {
            Debug.LogWarning("Not enough gold to buy the tower.");
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateGoldText()
    {
        goldText.text = "Gold: " + gold.ToString();
    }

public void Reset()
{
    score = 0;
    gold = 200; // Reset to initial gold value
    UpdateScoreText();
    UpdateGoldText();
}


    // This is the new method to get the current score
    public int GetScore()
    {
        return score;
    }
}
