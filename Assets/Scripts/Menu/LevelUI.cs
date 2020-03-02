using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] Text txtLives;
    [SerializeField] Text txtLevel;
    [SerializeField] Text txtMoves;
    void Start()
    {
        
    }

    public void UpdateLevel(int level)
    {
        txtLevel.text = "Level: " + level + "";
    }
    public void UpdateLives(int lives)
    {
        txtLives.text = "Lives: " + lives + "" ;
    }

    public void UpdateMoves(int moves)
    {
        txtMoves.text = "Moves: " + moves + "";
    }

    public void GameOver()
    {
        txtLevel.text = "Game Over!";
    }
}
