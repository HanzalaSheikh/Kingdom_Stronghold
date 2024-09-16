using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over! You lost!");
        Time.timeScale = 0; // Stop the game
    }
}
