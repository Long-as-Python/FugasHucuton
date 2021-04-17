using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mix : MonoBehaviour
{
    public PickUp pickUp;

    public bool isFull = false;
    public ParticleSystem fluid;
    public bool isPicked = false;

    public PickUp pick;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Dest>().isDest && isFull)
        {
            isFull = false;
            pickUp.RotateMe();
            Debug.Log("wowMagic");
            StartCoroutine(CumTimer(5f));
            other.gameObject.GetComponent<Menzurka>().MixFluids();
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

    private void OnMouseDown()
    {
        pick.OnMouseDownMenzurka();
        isPicked = true;
        
    }

    private void OnMouseUp()
    {
        pick.OnMouseUpMenzurka();
        isPicked = false;
    }

    private void Update()
    {
        if (isPicked)
        {
            var mousePos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            float distance;
            int layer_mask = LayerMask.GetMask("Default");
            if (Physics.Raycast(ray, out RaycastHit hit, 100, layer_mask))
            {
                Vector3 newPos = hit.point;
                newPos = new Vector3(newPos.x, transform.position.y, newPos.z);
                transform.position = newPos;
            }
        }
    }
}
