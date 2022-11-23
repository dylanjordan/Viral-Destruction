using System.Collections;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [Header("Weapon Stats")]
    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public float impactForce = 30f;

    [Header("Ammo Parameters")]
    public int maxAmmo = 10;
    private int currentAmmo;
    private int stockAmmo = 0;
    public float reloadTime = 1f;
    private bool isReloading = false;

    [Header("Additional Variables")]
    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public Animator animator;
    public TextMeshProUGUI text;

    [SerializeField] private AudioSource gunfireAudioSource = default;
    [SerializeField] private AudioClip gunShoot = default;

    private float nextTimeToFire = 0f;

    private InputManager input;

    void Start()
    {
        input = InputManager.Instance;
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    void Update()
    {
        if (isReloading)
            return;

        if (stockAmmo > 0 && (currentAmmo <= 0 || input.GetReload()))
        {
            StartCoroutine(Reload());
            return;
        }

        if (input.GetShooting() && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        UpdateAmmoText();
    }

    void Shoot()
    {
        muzzleFlash.Play();

        gunfireAudioSource.PlayOneShot(gunShoot);

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
        }
    }

    public void AddAmmo(int ammoAmount)
    {
        stockAmmo += ammoAmount;
    }

    private void UpdateAmmoText()
    {
        text.text = $"{currentAmmo} / {stockAmmo}";
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);

        animator.SetBool("Reloading", false);

        yield return new WaitForSeconds(0.25f);

        int reloadAmount = maxAmmo - currentAmmo; // How mnay bullets to refill clip

        reloadAmount = (stockAmmo - reloadAmount) >= 0 ? reloadAmount : stockAmmo; // Check if enough bullets in stock
        currentAmmo += reloadAmount;
        stockAmmo -= reloadAmount;

        //currentAmmo = maxAmmo;
        isReloading = false;
    }
}