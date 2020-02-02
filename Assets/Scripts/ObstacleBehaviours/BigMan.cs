using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMan : MonoBehaviour, IBehaviour
{
    bool isMoving = false;
    GameManager gm;
    public Vector2 position;

    Animator anim;
    Vector2 ogPos;

    public void ImplementBehaviour()
    {
        if (gm.tree && gm.repairMode)
        {
            isMoving = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
        ogPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isMoving)
        {
            if (transform.position.x != position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, position, 0.1f);
            }
            else
            {
                isMoving = false;
                
            }
        }

        anim.SetBool("isRunning", isMoving);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.name == "ROCK")
        {
            collision.transform.SetParent(transform);
            Vector2 v = new Vector2(transform.position.x, transform.position.y + 1);
            collision.transform.position= v;
            collision.transform.tag = "DEATH";
            collision.transform.GetComponent<BoxCollider2D>().isTrigger = true;
            gm.rock = true;
        }
    }
}
