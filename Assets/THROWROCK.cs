using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class THROWROCK : MonoBehaviour
{
    public Transform Rock;
    public float speed;

    bool isThrowing = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            isThrowing = true;
        }
    }

    private void Update()
    {
        if (isThrowing && FindObjectOfType<GameManager>().playMode)
        {
            Vector3 dir = new Vector3(-1, Rock.position.y, 0);
            Rock.Translate(Vector3.right*  speed * Time.deltaTime);
        }
    }
}
