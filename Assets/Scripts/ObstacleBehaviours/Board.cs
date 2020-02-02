using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour, IBehaviour
{
    [SerializeField]
    Sprite[] boards;

    int currentIndex = 0;
    public void ImplementBehaviour()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (boards.Length > 0 && gm.repairMode)
        {
            if (currentIndex >= boards.Length - 1)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }

            gameObject.GetComponent<SpriteRenderer>().sprite = boards[currentIndex];

            if (currentIndex == 2)
            {
                gm.board = true;
                gm.ReduceGlitchy();
            }
            else
            {
                gm.IncreaseGlitchy();
                gm.board = false;
            }
        }
    }
}
