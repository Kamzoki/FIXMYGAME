using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1 : MonoBehaviour, IBehaviour
{
    public Transform[] newTrans;
    int index = 0;
    public int rightIndex = 0;
    public bool isRightRotation = false;
    public void ImplementBehaviour()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gm.repairMode)
        {
            if (index == rightIndex)
            {
                Debug.LogError("here");
                gm.ReduceGlitchy();
                GetComponent<BoxCollider2D>().isTrigger = true;
                gm.tree = true;
            }
            else
            {
                gm.IncreaseGlitchy();
                GetComponent<BoxCollider2D>().isTrigger = false;
            }

            transform.position = newTrans[index].position;
            transform.rotation = newTrans[index].rotation;

            if (index == newTrans.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }

    }
}
