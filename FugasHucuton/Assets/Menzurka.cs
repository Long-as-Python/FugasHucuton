using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menzurka : MonoBehaviour
{
    public GameObject fluidParticle;
    public Transform baka;
    public ParticleSystem fluid;
    public ParticleSystem fluid2;
    public AudioSource source;
    public bool FirstTime;


    public void MixFluids()
    {
        StartCoroutine(Spawn(20f));
        if (FirstTime)
        {
            FirstTime=false;
            fluid.Play();
            fluid2.Stop();
        }
        else
        {
            FirstTime=true;
            fluid.Stop();
            fluid2.Play();
        }
    }

    IEnumerator Spawn(float inTime)
    {
        var t = 0f;
        source.Play();
        while (t < 1)
        {
            t += Time.deltaTime / inTime;

            yield return null;
        }
        source.Pause();
    }

}
