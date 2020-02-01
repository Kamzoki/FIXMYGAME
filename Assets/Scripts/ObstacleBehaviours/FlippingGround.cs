using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippingGround : MonoBehaviour, IBehaviour
{
    bool isFlipped = true;

    public void ImplementBehaviour()
    {
        if (isFlipped && GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().repairMode)
        {
            isFlipped = false;
            Vector3 scaler = transform.localScale;

            scaler.y *= -1;
            GetComponent<BoxCollider2D>().isTrigger = false;
            transform.localScale = scaler; 
        }
    }
}
