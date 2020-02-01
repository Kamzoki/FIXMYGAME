using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    int HP = 3;

    [SerializeField]
    GameObject[] _VisualHealthPoints;

    void Start()
    {
        if (_VisualHealthPoints.Length <= 3)
        {
            Debug.LogWarning("PlayerHealth: Missing visual representation of health points");
        }  
    }

    void ApplyDamage()
    {
        if (_VisualHealthPoints.Length == 3)
        {
            _VisualHealthPoints[HP].SetActive(false);
        }
        HP--;
    }

    bool isLost()
    {
        if (HP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            if (isLost())
            {
                //TODO: Call lose game in gamemanager
            }
            else ApplyDamage();
        }
    }
}
