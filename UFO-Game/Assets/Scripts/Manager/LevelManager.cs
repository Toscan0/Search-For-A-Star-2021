using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blackHole;
    [SerializeField]
    private GameObject victoryText;
    [SerializeField]
    private GameObject defeatText;

    [SerializeField]
    private GameObject fadeIn;

    void Awake()
    {
        PlayerManager.OnPlayerDeath += PlayerLost;
        EnemysManager.OnPlayerWin += PlayerWin;
    }

    private void PlayerLost()
    {
        defeatText.SetActive(true);

        fadeIn.SetActive(true);
    }

    private void PlayerWin()
    {
        if(blackHole != null)
        {
            blackHole.SetActive(true);
        }

        if (victoryText != null)
        {
            victoryText.SetActive(true);
        }
    }

    void OnDestroy()
    {
        PlayerManager.OnPlayerDeath -= PlayerLost;
        EnemysManager.OnPlayerWin += PlayerWin;
    }
}
