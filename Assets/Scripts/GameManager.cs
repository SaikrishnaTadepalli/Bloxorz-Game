using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject winSpot;
    [SerializeField] private Vector3 spawnLocation;
    private GameObject currentPlayer;
    private bool checkDead = true;

    [SerializeField] private int lives = 3;
    [SerializeField] private int level;
    public static int moves;
    [SerializeField] public Canvas levelCanvas;
    void Start()
    {
        levelCanvas.GetComponent<LevelUI>().UpdateLives(lives);
        levelCanvas.GetComponent<LevelUI>().UpdateLevel(level);
        levelCanvas.GetComponent<LevelUI>().UpdateMoves(moves);

        winSpot.GetComponent<MeshRenderer>().enabled = false;
        currentPlayer = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (currentPlayer != null)
        {
            if ( (((Mathf.Abs(currentPlayer.transform.position.x - winSpot.transform.position.x)) < 0.1f) && 
                ((Mathf.Abs(currentPlayer.transform.position.z - winSpot.transform.position.z)) < 0.1f)) && 
                currentPlayer.GetComponent<PlayerMovement>().isRotating == false)
            {
                Debug.Log("WINNER");
                currentPlayer.GetComponent<PlayerMovement>().enabled = false;
                currentPlayer.GetComponent<Rigidbody>().freezeRotation = true;
                currentPlayer.GetComponent<BoxCollider>().isTrigger = true;
                checkDead = false;
                StartCoroutine(LoadNextScene());
            }
            else if ((currentPlayer.transform.position.y < -100) && checkDead)
            {
                Debug.Log(currentPlayer.transform.position.y);
                PlayerDead();
            }
            else if (currentPlayer.transform.position.y < -4)
            {
                currentPlayer.GetComponent<BoxCollider>().isTrigger = true;
            }
        }

        if (lives > 0)
            levelCanvas.GetComponent<LevelUI>().UpdateMoves(moves);
    }

    public void PlayerDead()
    {
        Debug.Log("DEAD");
        lives -= 1;
        levelCanvas.GetComponent<LevelUI>().UpdateLives(lives);
        Destroy(currentPlayer.gameObject);

        if (lives > 0)
            currentPlayer = Instantiate(playerPrefab, spawnLocation, Quaternion.identity);
        else
            StartCoroutine(GameOver());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("LoadNextScene");
        levelCanvas.GetComponent<LevelUI>().UpdateLevel(level);
        Destroy(currentPlayer.gameObject);
        int nextSceneNum = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneNum);
    }

    IEnumerator GameOver()
    {
        moves = 0;
        levelCanvas.GetComponent<LevelUI>().GameOver();

        yield return new WaitForSeconds(5);
        Debug.Log("GameOver.....loadMainLevel");
        SceneManager.LoadScene(0);
    }
}
