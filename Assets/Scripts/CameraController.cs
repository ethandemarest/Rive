using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraController : MonoBehaviour
{
    public Camera cameranMain;
    public float currentRotationX;
    public float currentRotationY;

    public float rotationFactor;
    float vel = 0.0f;
    public float smoothTime = 0.2f;
    private float rotationVelX;
    private float rotationVelY;
    public float zoomFactor;

    public CameraControls cameraControls;
    private InputAction move;
    private InputAction zoom;

    Vector2 moveVector;

    private void Awake()
    {
        cameraControls = new CameraControls();
    }

    private void OnEnable()
    {
        move = cameraControls.Player.Move;
        zoom = cameraControls.Player.Look;
        move.Enable();
        zoom.Enable();
    } 
    private void OnDisable()
    {
        move.Disable();
        zoom.Disable();
    }

    void Update()
    {
        moveVector = move.ReadValue<Vector2>();
        float zoomInput = zoom.ReadValue<Vector2>().y;

        float currentZoom = Mathf.SmoothDamp(cameranMain.fieldOfView, 35 - (zoomInput * zoomFactor), ref vel, smoothTime);

        cameranMain.fieldOfView = currentZoom;

        float targetRotY = moveVector.x * rotationFactor;
        float targetRotX = moveVector.y * rotationFactor;

        currentRotationX = Mathf.SmoothDampAngle(transform.eulerAngles.x, targetRotX, ref rotationVelX, smoothTime);
        currentRotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotY, ref rotationVelY, smoothTime);

        transform.rotation = Quaternion.Euler(currentRotationX, currentRotationY, 0f);
    }
}