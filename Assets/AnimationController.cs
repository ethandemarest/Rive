using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    public RiveController riveController;
    public CameraControls cameraControls;
    private InputAction move;
    private InputAction zoom;
    private InputAction press;

    private void Awake()
    {
        cameraControls = new CameraControls();
    }

    private void OnEnable()
    {
        cameraControls.Enable();
        move = cameraControls.Player.Move;
        zoom = cameraControls.Player.Look;
        press = cameraControls.Player.Jump;
    }
    private void OnDisable()
    {
        cameraControls.Disable();
    }

    private void Update()
    {
        if (press.WasPerformedThisFrame())
        {
            Debug.Log("press");
            riveController.Jump();
        }
    }
}
