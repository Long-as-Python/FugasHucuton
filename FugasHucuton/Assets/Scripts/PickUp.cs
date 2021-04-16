using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    public Transform dest;

    void OnMouseDown() {
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = dest.position;
        this.transform.parent = GameObject.Find("Dest").transform;
        Debug.Log("puk");
    }

    void OnMouseUp() {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
