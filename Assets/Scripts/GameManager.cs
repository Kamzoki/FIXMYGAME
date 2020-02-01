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
    [SerializeField] SpriteRenderer glitchyBackGround;
    [SerializeField] SpriteRenderer clearBackGround;
    Color glitchyColor;
    Color clearBackGroundColor;
    public bool tree;
    public bool flippedGround;
    public bool flyingTile;
    public bool wood;
    public bool rock;
    public bool man;
    public bool board;
    public bool repairMode = true;
    public bool playMode = false;


    

    // Start is called before the first frame update
    void Start()
    {
        repairMode = true;
        playMode = false;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);

        glitchyColor = glitchyBackGround.color;
        clearBackGroundColor = clearBackGround.color;

        glitchyColor.a = 1f;
        clearBackGroundColor.a = 0f;

        glitchyBackGround.color = glitchyColor;
        clearBackGround.color = clearBackGroundColor;

        
    }

    public void ReduceGlitchy()
    {


        glitchyColor.a -= 0.14f;
        clearBackGroundColor.a += 0.14f;
        UpdateAllBackGroundColors();

    }

    private void UpdateAllBackGroundColors()
    {
        glitchyBackGround.color = glitchyColor;
        clearBackGround.color = clearBackGroundColor;
    }

    public void IncreaseGlitchy()
    {
        glitchyColor.a += 0.14f;
        clearBackGroundColor.a -= 0.14f;
        UpdateAllBackGroundColors();
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
        playMode = true;
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
