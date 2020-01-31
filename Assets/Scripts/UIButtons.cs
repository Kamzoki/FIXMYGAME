using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    [SerializeField]
    Vector2 direction;

    bool isMoving = false;

    public void JumpBtn()
    {
        if (GetPlayer())
        {
            GetPlayer().GetComponent<PlayerMovement>().JumpPlayer();
        }
    }

    public void MoveBtn()
    {
        if (GetPlayer())
        {
            isMoving = true;
        }
    }

    public void MoveBtnExit()
    {
        isMoving = false;
    }


    private GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (isMoving)
        {
            GetPlayer().GetComponent<PlayerMovement>().MovePlayer(direction);
        }
    }
}
