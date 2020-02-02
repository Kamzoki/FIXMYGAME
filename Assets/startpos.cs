using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startpos : MonoBehaviour
{
    public GameObject text;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().isDragging = false;
            collision.transform.GetComponent<BoxCollider2D>().isTrigger = false;
            text.SetActive(true);
            Destroy(gameObject);
        }
    }
}
