using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrs : MonoBehaviour
{
    public float desiredSpeed;
    public float glitchySpeed;

    public Transform upPoint;
    public Transform downPoint;
    int pointCounter;
    [SerializeField]  public float speed = 1f;


    // Update is called once per frame
    void Update()
    {
        float moveSpeed;
        if (pointCounter == 0)
        {
            if (FindObjectOfType<GameManager>().board)
            {
                glitchySpeed = desiredSpeed;
            }
            else if (!FindObjectOfType<GameManager>().board)
            {
                glitchySpeed = 8;
            }
            Vector3 target = upPoint.position;
            
            if (FindObjectOfType<GameManager>().GetComponent<GameManager>().repairMode)
            {
                moveSpeed = glitchySpeed * Time.deltaTime;// modify to gliitch Speed
            }
            else
            {
                moveSpeed = desiredSpeed * Time.deltaTime;// modify to gliitch Speed
            }

            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
            if(transform.position== target)
            {
                pointCounter++;
            }
        }
        else if (pointCounter == 1)
        {
          
                Vector3 target = downPoint.position;
            if (FindObjectOfType<GameManager>().GetComponent<GameManager>().repairMode)
            {
                moveSpeed = glitchySpeed * Time.deltaTime;// modify to gliitch Speed
            }
            else
            {
                moveSpeed = desiredSpeed * Time.deltaTime;// modify to gliitch Speed
            }
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
                if (transform.position == target)
                {
                    pointCounter=0;
                }
           
        }





    }
}
