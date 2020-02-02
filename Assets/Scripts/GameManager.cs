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
    [SerializeField] GameObject winMenu;
    [SerializeField] SpriteRenderer glitchyBackGround;
    [SerializeField] SpriteRenderer clearBackGround;
    Color glitchyColor;
    Color clearBackGroundColor;
    public bool tree;
    public bool flippedGround;
    public bool flyingTile;
    public bool wood;
    public bool rock;
    public bool board;
    public bool repairMode = true;
    public bool playMode = false;


    public bool isDragging = false;

    public Transform startPos;

    // Start is called before the first frame update
    void Start()
    {
        repairMode = true;
        playMode = false;
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        winMenu.SetActive(false);
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

        if (isDragging)
        {
            FindObjectOfType<PlayerMovement>().gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            FindObjectOfType<PlayerMovement>().gameObject.transform.position = Vector2.Lerp(FindObjectOfType<PlayerMovement>().gameObject.transform.position, startPos.position, 6 * Time.deltaTime);
        }
        else
        {
            FindObjectOfType<PlayerMovement>().gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        

    }

    private void CheckWinStatus()
    {
        if (tree && flippedGround && rock && flyingTile && board)
        {
            activateWinCondition();
        }
    }

    private void activateWinCondition()
    {
        repairMode = false;
        playMode = true;

        isDragging = true;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        loseMenu.SetActive(false);
        SceneManager.LoadScene(sceneIndex);
    }
    public void StartNormalPlay()
    {
        winMenu.SetActive(true);
    }


    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void HomePage()
    {
        SceneManager.LoadScene("Home");
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void LoseMenu()
    {
        loseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
