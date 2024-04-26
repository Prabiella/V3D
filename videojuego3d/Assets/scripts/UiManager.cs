using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text currentScoreText;
    public Text bestScoreText;

    // Start is called before the first frame update
    void Update()
    {
        currentScoreText.text ="Puntos:" + GameManager.singleton.currentScore;
        bestScoreText.text ="Record:" + GameManager.singleton.bestScore;
    }

   
}
