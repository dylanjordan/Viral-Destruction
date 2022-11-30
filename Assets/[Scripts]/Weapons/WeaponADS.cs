using UnityEngine;

public class WeaponADS : MonoBehaviour
{
    [Header("ADS Parameters")]
    public float _adsSpeed = 8f;
    public Vector3 aimPosition;
    public Vector3 aimRotation;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject crosshairText;
    public bool isAiming;

    //internal privates
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private InputManager input;

    private void Start()
    {
        input = InputManager.Instance;

        originalPosition = transform.localPosition;
        originalRotation = transform.localRotation;
    }

    private void Update()
    {
        AimingDownSights();
    }

    //aiming down sites by checking input from InputManager.cs
    private void AimingDownSights()
    {
        if (input.GetADSEnable())
        {
            crosshair.SetActive(false);
            crosshairText.SetActive(false);
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * _adsSpeed);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(aimRotation), Time.deltaTime * _adsSpeed);
        }
        else
        {
            crosshair.SetActive(true);
            crosshairText.SetActive(true);
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * _adsSpeed);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, originalRotation, Time.deltaTime * _adsSpeed);
        }
    }

    public float GetAdsSpeed()
    {
        return _adsSpeed;
    }
}