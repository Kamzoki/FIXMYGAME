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
        if (pointCounter == 0)
        {
            Vector3 target = upPoint.position;
            float moveSpeed;
            if (GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().repairMode)
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
                var moveSpeed = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed);
                if (transform.position == target)
                {
                    pointCounter=0;
                }
           
        }





    }
}
