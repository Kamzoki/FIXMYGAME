using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTile : MonoBehaviour
{
    public Vector3 desiredPos;
    public GameObject glitchySprite;

    GameManager gm;

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        if (gm.repairMode)
        {
            if (transform.position == desiredPos && glitchySprite.activeSelf == true)
            {
                glitchySprite.SetActive(false);
                gm.flyingTile = true;
                gm.ReduceGlitchy();
            }
            else
            {
                glitchySprite.SetActive(true);
                gm.flyingTile = false;
            }
        }
    }
}
