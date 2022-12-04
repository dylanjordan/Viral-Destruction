using UnityEngine;

public class Recoil : MonoBehaviour
{
    // Rotations
    private Vector3 currentRotation;
    private Vector3 targetRotation;

    private Gun gun_script;
    private InputManager input;

    void Start()
    {
        gun_script = transform.GetComponentInChildren<Gun>();
        input = InputManager.Instance;
    }

    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, gun_script.returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, gun_script.snappiness * Time.fixedDeltaTime);

        transform.localRotation = Quaternion.Euler(currentRotation);
    }

    public void RecoilFire()
    {
        if (CheckADS())
            targetRotation += new Vector3(gun_script.aimRecoilX, Random.Range(-gun_script.aimRecoilY, gun_script.aimRecoilY), Random.Range(-gun_script.aimRecoilZ, gun_script.aimRecoilZ));
        else
            targetRotation += new Vector3(gun_script.recoilX, Random.Range(-gun_script.recoilY, gun_script.recoilY), Random.Range(-gun_script.recoilZ, gun_script.recoilZ));
    }

    private bool CheckADS()
    {
        if (input.GetADSEnable())
            return true;
        else
            return false;
    }
}