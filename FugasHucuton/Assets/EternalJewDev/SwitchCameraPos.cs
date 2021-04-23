using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCameraPos : MonoBehaviour
{
public Transform cameraTarget1;
public Transform cameraTarget2;
public Transform cameraTarget3;
public float speed = 5f;
private Vector3 dist;
Vector3 dPos;
public Button PhysicsButton;
public Button ChemistryButton;
public Button BackToMenu;

public int currentTarget;
private Transform cameraTarget;

 public void Start()
 { 
    currentTarget = 1;
    
    BackToMenu.onClick.AddListener(() => SetFistTarget());
    PhysicsButton.onClick.AddListener(() => SetSecondTarget());
    ChemistryButton.onClick.AddListener(() => SetThirdTarget());
    
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
     Debug.Log("1");
   cameraTarget = cameraTarget2.transform;
   currentTarget = 2;
 }
   public void SetThirdTarget()
 {
   cameraTarget = cameraTarget3.transform;
   currentTarget = 3;
 }
}
