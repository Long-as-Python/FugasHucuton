using System.Security.AccessControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManger : MonoBehaviour
{
    private static InputManger _instance;

    public static InputManger Instance
    {
        get
        {
            return _instance;
        }
    }

    private PlayerControls controls;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        controls = new PlayerControls();
    }

    private void OnEnable()
    {
        controls.Enable();

    }

    private void OnDisable()
    {
        controls.Disable();
    }

    public Vector2 GetMouseDelta()
    {
        return controls.Player.Look.ReadValue<Vector2>();
    }

    public bool GetMouseClick(){
        return controls.Player.Tap.ReadValue<bool>();
    }

}
