using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlippingGround : MonoBehaviour, IBehaviour
{
    bool isFlipped = true;

    public void ImplementBehaviour()
    {
        if (isFlipped)
        {
            isFlipped = false;
            Vector3 scaler = transform.localScale;

            scaler.y *= -1;
            GetComponent<BoxCollider>().isTrigger = false;
            transform.localScale = scaler; 
        }
    }
}
