using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class Flicker : MonoBehaviour
{
    public float flickerkRate = 5f;
    float nextFlickerTime = 0f;
    Light2D light;
    float duration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time >= nextFlickerTime)
        {
            flickerkRate = Random.Range(5f, 7f);
            light.intensity = Random.Range(0.6f, 1f);
            nextFlickerTime = Time.time + 0.5f / flickerkRate;
        }
    }
}
