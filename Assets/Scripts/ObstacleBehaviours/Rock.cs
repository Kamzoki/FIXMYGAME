using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Vector2 aboveMan;
    public Transform man;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == man)
        {

            transform.position = aboveMan;

        }
    }
}
