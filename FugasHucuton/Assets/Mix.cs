using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mix : MonoBehaviour
{
    public PickUp pickUp;
    
    public bool isFull = false;
    public ParticleSystem fluid;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Dest>().isDest && isFull)
        {
            isFull = false;
            pickUp.RotateMe();
            Debug.Log("wowMagic");
            StartCoroutine(CumTimer(5f));
        }
    }

    IEnumerator CumTimer(float time)
    {
        fluid.Play();
        for (var i = 0f; i <= time; i += Time.deltaTime)
        {
            yield return null;
            Debug.Log("rotating");
        }
        fluid.Stop();
        pickUp.RotateMe(false);
    }
}
