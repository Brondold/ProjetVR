using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;
using System;

public class FiringBulletOnActive : MonoBehaviour
{

    [SerializeField] AudioSource shotSound;
    [SerializeField] AudioSource reloadSound;

    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20f;

    public int maxAmmo = 5;
    public int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading;

    public TMP_Text ammoScore;



    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);

        ammoScore.text = currentAmmo.ToString();

        if (currentAmmo == -1)
            currentAmmo = maxAmmo;


    }

    // Update is called once per frame
    void Update()
    {
        if (!isReloading)
        {
            ammoScore.text = currentAmmo.ToString();
        }

        else { return;}

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("RELOADING");

        reloadSound.Play();

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;

        isReloading = false;
    }
    public void FireBullet(ActivateEventArgs arg)
    {
        currentAmmo--;
        //ammoScore.text = currentAmmo.ToString();

        if (currentAmmo >= 0)
        {
            GameObject spawnedBullet = Instantiate(bullet);
            spawnedBullet.transform.position = spawnPoint.position;
            spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
            shotSound.Play();
            Destroy(spawnedBullet, 5);
        }
        
    }
}
