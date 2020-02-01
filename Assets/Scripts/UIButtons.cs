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

    public void JumpBtnExit()
    {
        
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
        GetPlayer().GetComponent<Animator>().SetFloat("speed", 0);
    }


    private GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            GetPlayer().GetComponent<PlayerMovement>().MovePlayer(direction);
        }
    }
}
