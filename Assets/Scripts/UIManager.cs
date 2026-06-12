using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
public bool isGameOver { get; private set; } //ENCAPSULATION
public bool isGameActive => !isGameOver;

public int totalCarrots = 5;
private int carrotsRemaining;
public int totalLives = 3;
private int livesRemaining;
public GameObject VictoryUI;
public GameObject GameOverUI;
public TextMeshProUGUI livesText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carrotsRemaining = totalCarrots;
        livesRemaining = totalLives;
        VictoryUI.SetActive(false);
        GameOverUI.SetActive(false);
        UpdateLivesUI();

    }

public void CarrotCollected()
    {
        if(isGameOver) return;

        carrotsRemaining--;

        if(carrotsRemaining <= 0)
        {
            Victory();
        }
    }

public void LifeLost()
    {
        if (isGameOver) return;
        
        livesRemaining--;
        UpdateLivesUI();

        if(livesRemaining <= 0)
        {
            GameOver();
        }
    }

    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + livesRemaining;
    }
    void Victory()
    {
        if (isGameOver) return;
        VictoryUI.SetActive(true);
        Debug.Log("You Win!");
        EndGame();
    }
    void GameOver() //ABSTRACTION
    {
        if (isGameOver) return;
        GameOverUI.SetActive(true);
        Debug.Log("You Lose!");
        EndGame();
    }
 void EndGame() //ABSTRACTION
    {
        isGameOver = true;
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
