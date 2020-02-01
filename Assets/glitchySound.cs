using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glitchySound : MonoBehaviour
{
    float timer = 0;
    float lastTime;

    public float timeToCut = 0;


    private void Start()
    {
        lastTime = Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer >= lastTime + timeToCut)
        {
            timer = Time.deltaTime;
            lastTime = Time.deltaTime;
            StartMusic();
        }

        else
        {
            timer++;
        }
    }

    void StartMusic()
    {
        GetComponent<AudioSource>().enabled = true;
        Invoke("StopMusic", 3);
    }

    void StopMusic()
    {
        GetComponent<AudioSource>().enabled = false;
    }
}
