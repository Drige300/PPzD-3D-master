using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAudioController : MonoBehaviour
{
    public AudioSource Rat;
    public AudioClip[] RatNoise;

    float timePassed = 0f;

    void Awake()
    {
        Rat = GetComponent<AudioSource>();
    }

    

    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed > 3f)
        {
            timePassed = 0f;
            Rat.clip = RatNoise[Random.Range(0, RatNoise.Length)];
            Rat.PlayOneShot(Rat.clip);
        }
    }


}
