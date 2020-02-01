using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour, IBehaviour
{
    public Vector2 pos;

    public void ImplementBehaviour()
    {
        GameManager gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (gm.repairMode)
        {
            transform.position = pos;
            gm.wood = true;
            gm.ReduceGlitchy();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
