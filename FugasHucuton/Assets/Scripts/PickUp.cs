using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour
{
    public Transform dest;
    public float height = 1;
    public bool isPicked = false;
    public bool isDest = false;
    public Collider point;
    public bool FirstTime;


    private Touch touch;
    public float speedModifier;

    public void OnMouseDownMenzurka()
    {
        GetComponent<Rigidbody>().useGravity = false;
        StartCoroutine(PickMe(transform, transform.position + new Vector3(0, height, 0), 1f));

        isPicked = true;
    }

    public void OnMouseUpMenzurka()
    {
        GetComponent<Rigidbody>().useGravity = true;
        transform.rotation = Quaternion.identity;
        isPicked = false;
    }

    IEnumerator PickMe(Transform transform, Vector3 position, float inTime)
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

    IEnumerator RotateMe(Vector3 byAngles, float inTime, bool cum)
    {
        var fromAngle = transform.rotation;
        var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
        for (var t = 0f; t <= 1; t += Time.deltaTime / inTime)
        {
            transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
            yield return null;
        }

    }

    public void RotateMe(bool cum)
    {
        StartCoroutine(RotateMe(Vector3.forward * -90, 1f, cum));
    }

    public void RotateMe()
    {
        StartCoroutine(RotateMe(Vector3.forward * 90, 1f, true));
    }

    private void Start()
    {
        speedModifier = 0.01f;
    }

    float depth = 5;


    void Update()
    {
        // if (isPicked)
        // {

        //     //touch = Input.GetTouch(0);

        //     //if (touch.phase == TouchPhase.Moved)
        //     float planeY = 0;
        //     var mousePos = Input.mousePosition;
        //     Ray ray = Camera.main.ScreenPointToRay(mousePos);
        //     float distance;
        //     int layer_mask = LayerMask.GetMask("Default");
        //     if (Physics.Raycast(ray, out RaycastHit hit, 100, layer_mask))
        //     {
        //         Vector3 newPos = hit.point;
        //         //newPos = new Vector3(newPos.x, transform.position.y, newPos.z);
        //         transform.position = newPos;
        //     }
        //     // var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));
        //     // transform.position = wantedPos;


        // }



        if (Input.GetKeyDown("e"))
        {
            StartCoroutine(PickMe(transform, transform.position + new Vector3(0, 2, 0), 1f));
        }
        if (Input.GetKeyDown("q") && isPicked)
        {
            StartCoroutine(RotateMe(Vector3.forward * -90, 1f, false));
        }
    }
}

