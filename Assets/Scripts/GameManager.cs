using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int sceneIndex;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject loseMenu;
    public bool tree;
    public bool flippedGround;
    public bool flyingTile;
    public bool wood;
    public bool rock;
    public bool man;
    public bool board;
    public bool repairMode = true;
    

    // Start is called before the first frame update
    void Start()
    {
        repairMode = true;
         sceneIndex = SceneManager.GetActiveScene().buildIndex;
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        CheckWinStatus();


    }

    private void CheckWinStatus()
    {
        if (tree && flippedGround && rock && flyingTile && wood && man && board)
        {
            activateWinCondition();
        }
    }

    private void activateWinCondition()
    {
        repairMode = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void LoseMenu()
    {
        loseMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
