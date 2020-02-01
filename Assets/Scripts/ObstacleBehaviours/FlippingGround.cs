using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippingGround : MonoBehaviour, IBehaviour
{
    bool isFlipped = true;

    public void ImplementBehaviour()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if (isFlipped && gm.repairMode)
        {
            isFlipped = false;
            Vector3 scaler = transform.localScale;

            scaler.y *= -1;
            GetComponent<BoxCollider2D>().isTrigger = false;
            transform.localScale = scaler;
            gm.flippedGround = true;
            gm.ReduceGlitchy();
        }

    }
}
