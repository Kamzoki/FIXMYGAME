using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IBehaviour
{
    [SerializeField]
    Transform platform;
    [SerializeField]
    Vector3 position;
    [SerializeField]
    float speed;

    bool isMoving = false;
    public void ImplementBehaviour()
    {
        Vector2 newPos;
        if (position.x == 0)
        {
            newPos.x = platform.position.x;
            newPos.y = position.y;
        }
        else
        {
            newPos.x = position.x;
            newPos.y = platform.position.y;
        }
        
        platform.position = newPos;
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gm.IncreaseGlitchy();
    }
}
