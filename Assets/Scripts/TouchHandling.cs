using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandling : MonoBehaviour
{
    [SerializeField]
    private TouchPhase _touchPhase = TouchPhase.Began;

    void Update()
    {
        if (Input.touchCount > 0)
        {

            if (Input.touchCount == 1)
            {
                GetTouchedShopOnSingleTouch();
            }
            else
            {
                GetTouchedShopOnMultipleTouchs();
            }
        }
    }

    void GetTouchedShopOnMultipleTouchs()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touches[i].phase == _touchPhase)
            {
                Vector3 touchPos = Input.touches[i].position;

                Vector3 currentObjectPos = Camera.main.ScreenToWorldPoint(touchPos);
                RaycastHit2D hit = Physics2D.Raycast(currentObjectPos, Vector3.zero);

                if (hit && hit.collider)
                {
                    if (hit.transform.CompareTag("Enemy"))
                    {
                        ChangeEnemyBehaviour(hit.transform.gameObject);
                    }
                }
            }
        }
    }

    void GetTouchedShopOnSingleTouch()
    {
        if (Input.touches[0].phase == _touchPhase)
        {
            Vector3 touchPos = Input.touches[0].position;

            Vector3 gameObjectPos = Camera.main.ScreenToWorldPoint(touchPos);
            RaycastHit2D hit = Physics2D.Raycast(gameObjectPos, Vector2.zero);

            if (hit && hit.collider)
            {
                if (hit.transform.CompareTag("Enemy"))
                {
                    ChangeEnemyBehaviour(hit.transform.gameObject);
                }
            }
        }
    }

    void ChangeEnemyBehaviour(GameObject g)
    {
        Enemy e = g.GetComponent<Enemy>();

        if (e)
        {
            e.ChangeBehaviour();
        }
    }

}
