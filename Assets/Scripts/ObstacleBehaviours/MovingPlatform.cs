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
        isMoving = true;
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        gm.IncreaseGlitchy();
    }

    private void Update()
    {
        if (isMoving)
        {
            if (platform.position != position)
            {
                platform.Translate(position * speed * Time.deltaTime, Space.World);
            }
            else
            {
                isMoving = false;
                
            }
        }
    }
}
