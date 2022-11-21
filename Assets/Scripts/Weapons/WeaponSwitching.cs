using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;

    private InputManager input;

    void Start()
    {
        input = InputManager.Instance;
        SelectWeapon();
    }

    private void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        // Select weapon using scroll wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        // Select weapon using keys
        if (input.GetSwitchWeaponOne())
            selectedWeapon = 0;

        if (input.GetSwitchWeaponTwo() && transform.childCount >= 2)
            selectedWeapon = 1;

        // Switch weapon Gamepad
        if (input.GetSwitchGamepad())
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        // If selected weapon isnt active switch
        if (previousSelectedWeapon != selectedWeapon)
            SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;

        // Check what weapon (gameobject) is active
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);

            i++;
        }
    }
}