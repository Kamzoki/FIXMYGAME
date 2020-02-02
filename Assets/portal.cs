using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    public GameObject WIN;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm.playMode)
        {
            if (collision.transform.CompareTag("Player"))
            {
                WIN.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
