using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int bestScore;
    public int currentScore;
    public int currentLevel = 0;

    public static GameManager singleton;

    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        }

        bestScore = PlayerPrefs.GetInt("BestScore");
    }

   public void NextLevel()
    {

    }

    public void RestartLevel()
    {
        Debug.Log("Restar level");
        singleton.currentScore = 0;
        FindObjectOfType<BallController>().ResetBall();
        
    }

    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;

        if (currentScore>bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("BestScore", currentScore); // Guardar la mejor puntuación
        }
        //Debug.Log("Current Score: " + currentScore); // Mensaje de depuración
        //Debug.Log("Best Score: " + bestScore); // Mensaje de depuración
    }
}
