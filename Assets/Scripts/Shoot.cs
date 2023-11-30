using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    public static float bulletSpeed = 200f;
    public float fireRate;

    public float oneBulletReloadTime;

    public int maxAmmo;
    public int Ammo;
    private bool canReload = true;
    private bool shooting = false;

    public TextMeshProUGUI ammoText;
    AudioSource audioSource;

    void Start()
    {
        Ammo = maxAmmo;
        StartCoroutine(Reload());
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ammoText.text = Ammo.ToString();
        if (Input.GetKeyDown(KeyCode.Space) && Ammo > 0)
        {
            if (!shooting)
            {
                StartCoroutine(Shot());
                shooting = true;
            }
        }
        else
        {
            StopCoroutine(Shot());
            canReload = true;
        }
    }

    private IEnumerator Shot()
    {
        Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        audioSource.Play();
        canReload = false;
        Ammo--;
        yield return new WaitForSeconds(fireRate);
        shooting = false;
    }

    private IEnumerator Reload()
    {
        while(canReload)
        {
            yield return new WaitForSeconds(oneBulletReloadTime);
            Ammo = Mathf.Clamp(Ammo + 1, 0, maxAmmo);
        }
        if(Ammo >= maxAmmo)
        {
            yield return new WaitUntil(() => Ammo <= maxAmmo);
        }
    }
}
