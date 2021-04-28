using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SwitchCameraPos : MonoBehaviour
{
public Transform cameraTarget1;
public Transform cameraTarget2;
public Transform cameraTarget3;
public float speed = 5f;
private Vector3 dist;
Vector3 dPos;
public Button BackToMenu;

public int currentTarget;
private Transform cameraTarget;
//Raycast For Button
public float rayLength;
public LayerMask layerMask;

 public void Start()
 { 
    currentTarget = 1;
    BackToMenu.onClick.AddListener(() => SetFistTarget());
 }
 private void Update()
 {
   if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
   {
     RaycastHit hit;
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     if(Physics.Raycast(ray, out hit, rayLength, layerMask))
     {
       if(hit.collider.name == "ChangeToPhysics")
       {
        SetThirdTarget();
       }
       else if(hit.collider.name == "ChangeToChemistry")
       {
         SetSecondTarget();
       }
     }
   }
 }
  public void FixedUpdate()
 {
     if(cameraTarget)
     {
        dPos = cameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, speed * Time.deltaTime);  
        transform.position = sPos;
     }
 }
    
  public void SetFistTarget()
 {
   cameraTarget = cameraTarget1.transform;
   currentTarget = 1;
 }
  public void SetSecondTarget()
 {
   cameraTarget = cameraTarget2.transform;
   currentTarget = 2;
 }
   public void SetThirdTarget()
 {
   cameraTarget = cameraTarget3.transform;
   currentTarget = 3;
 }
}
