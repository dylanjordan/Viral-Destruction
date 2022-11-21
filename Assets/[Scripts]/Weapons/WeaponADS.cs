using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponADS : MonoBehaviour
{
    [Header("ADS Values")]
    public float _adsSpeed = 8f;
    public Vector3 aimPosition;
    public Vector3 aimRotation;

    private static WeaponADS _instance;
    //internal privates
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public Camera weaponCam;

    private InputManager input;

    public static WeaponADS Instance
    {
        get
        {
            return _instance;
        }
    }

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
    }

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
            transform.localPosition = Vector3.Lerp(transform.localPosition, aimPosition, Time.deltaTime * _adsSpeed);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(aimRotation), Time.deltaTime * _adsSpeed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * _adsSpeed);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, originalRotation, Time.deltaTime * _adsSpeed);
        }
    }

    public float GetAdsSpeed()
    {
        return _adsSpeed;
    }
}