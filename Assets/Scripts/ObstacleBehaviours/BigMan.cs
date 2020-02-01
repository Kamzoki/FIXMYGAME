using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMan : MonoBehaviour, IBehaviour
{
    bool isMoving = false;
    GameManager gm;
    public Vector2 position;

    public void ImplementBehaviour()
    {
        if (gm.tree)
        {
            isMoving = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(position, Space.World);
        }
    }
}
