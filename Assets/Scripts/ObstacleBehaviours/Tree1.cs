using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree1 : MonoBehaviour, IBehaviour
{
    public Quaternion rotation;
    public bool isRightRotation = false;
    public void ImplementBehaviour()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gm.repairMode)
        {
            transform.rotation = rotation;
            gm.tree = isRightRotation;

            if (isRightRotation)
            {
                gm.ReduceGlitchy();
            }
            else
            {
                gm.IncreaseGlitchy();
            }
        }

    }
}
