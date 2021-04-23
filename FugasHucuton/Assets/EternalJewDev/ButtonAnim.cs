using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    public float height = 0.1f;
     private void OnMouseDown()
    {
        StartCoroutine(PushingButt(transform, transform.position + new Vector3(0, -height, 0), 0.1f));
    }
   IEnumerator PushingButt(Transform transform, Vector3 position, float inTime)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / inTime;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
        StartCoroutine(NotButt(transform, transform.position + new Vector3(0, height, 0), 0.1f));
    }
    IEnumerator NotButt(Transform transform, Vector3 position, float inTime)
    {
        var currentPos = transform.position;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / inTime;
            transform.position = Vector3.Lerp(currentPos, position, t);
            yield return null;
        }
    }
}
