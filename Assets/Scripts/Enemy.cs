using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public int currentBehaviourIndex = 0;

    private IBehaviour[] behaviours;

    void Start()
    {
        behaviours = GetComponents<IBehaviour>();

        if (behaviours.Length < 0)
        {
            Debug.LogWarning("Enemy " + gameObject.name + ": missing behaviours");
        }
    }

    public void ChangeBehaviour()
    {
        if (currentBehaviourIndex < behaviours.Length)
        {
            currentBehaviourIndex++;
        }
        else
        {
            currentBehaviourIndex = 0;
        }
    }

    private void Update()
    {
        if (behaviours.Length > 0 && currentBehaviourIndex < behaviours.Length)
        {
            behaviours[currentBehaviourIndex].ImplementBehaviour();
        }
    }
}
