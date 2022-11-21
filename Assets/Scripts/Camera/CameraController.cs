using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Look Parameters")]
    Camera mainCamera;
    [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
    [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
    [SerializeField, Range(1, 180)] private float upperLookLimit = 80.0f;
    [SerializeField, Range(1, 180)] private float lowerLookLimit = 80.0f;

    [Header("Zoom Parameters")]
    [SerializeField] private float timeToZoom = 0.3f;
    [SerializeField] private float zoomFOV = 30f;
    private float defaultFOV;
    private Coroutine zoomRoutine;
    private KeyCode zoomKey = KeyCode.Mouse1;

    private InputManager input;

    void Start()
    {
        mainCamera = Camera.main;
        input = InputManager.Instance;
        defaultFOV = mainCamera.fieldOfView;
    }

    void Update()
    {
        HandleMouseLook();
        HandleZoom();
    }

    private void HandleMouseLook()
    {
        float rotationX = 0;

        //Look up and down
        rotationX -= input.GetMouseMovement().y * lookSpeedY * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        mainCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        // Look left and right
        mainCamera.transform.rotation *= Quaternion.Euler(0, input.GetMouseMovement().x * lookSpeedX * Time.deltaTime, 0);
    }

    private void HandleZoom()
    {
        if (Input.GetKeyDown(zoomKey))
        {
            if (zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }
            zoomRoutine = StartCoroutine(ToggleZoom(true));
        }
        if (Input.GetKeyUp(zoomKey))
        {
            if (zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }
            zoomRoutine = StartCoroutine(ToggleZoom(false));
        }
    }

    private IEnumerator ToggleZoom(bool isEnter)
    {
        float targetFOV = isEnter ? zoomFOV : defaultFOV;
        float startingFOV = mainCamera.fieldOfView;
        float timeElapsed = 0;

        while (timeElapsed < timeToZoom)
        {
            mainCamera.fieldOfView = Mathf.Lerp(startingFOV, targetFOV, timeElapsed / timeToZoom);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        mainCamera.fieldOfView = targetFOV;
        zoomRoutine = null;
    }
}
