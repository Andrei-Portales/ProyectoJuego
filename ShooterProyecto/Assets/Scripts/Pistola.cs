using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistola : MonoBehaviour
{
    public Animator animator;
    public GameObject scopeOverlay;
    public Camera mainCamera;

    public float scopedFOV = 15f;
    private float normalFOV;

    private bool isScoped = false;

    public float damage = 50f;
    public float range = 100f;
    public float impactForce = 30f;
    public float fireRate = 15f;

    public int maxAmmo;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public GameObject bottomSettings;
    public GameObject middleSettings;


    public Camera fpsCam;
    //public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    private float nextTimeToFire = 0f;

    //public Animator animator;

    public Text balas;

    private int enemigosMuertos = 0;

    public Text muertos;

    public Text txtReloading;

    private AudioSource mAudioSrc;

    //Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
        balas.text = currentAmmo + " / " + maxAmmo;
        muertos.text = enemigosMuertos + " / 3";

        mAudioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuPausa.gameIsPause)
        {

            if (isReloading)
            {
                return;
            }

            if (currentAmmo <= 0)
            {
                StartCoroutine(Reload());
                return;
            }

            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {

                mAudioSrc.Play();

                nextTimeToFire = Time.time + 1f / fireRate;
                Disparar();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                isScoped = !isScoped;
                animator.SetBool("Scoped", isScoped);

                if (isScoped)
                {
                    StartCoroutine(OnScoped());
                }
                else
                {
                    OnUnScoped();
                }
            }
        }

    }

    void Disparar()
    {
        //muzzleFlash.Play();

        balas.text = currentAmmo + " / " + maxAmmo;
  

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            // Se accede a la clase Target asignado a los ojetos que queremos destruir
            Target target = hit.transform.GetComponent<Target>();

            // Verifica que el objeto impactado no sea null
            if (target)
            {
                // Se manda ca cantidad de daño
                target.TakeDamage(damage);
            }

            
            //  Si el objeto que impacta no es null, se aplica una fuerza para moverlo, 
            // dependiendo del eje donde viene la fuerza
           

            // Destruye las balas creadas en cada disparo cada 2 segundos
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

            
        }
    }

    IEnumerator Reload()
    {

        isReloading = true;

        // Se aplica una anumacion para cargar la pistola
        //animator.SetBool("Reloading", true);
        txtReloading.gameObject.SetActive(true);
        

        // Se usa concurrencia para recargar la pistola en el tiempo correcto
        yield return new WaitForSeconds(reloadTime - .25f);
        //animator.SetBool("Reloading", false);
        txtReloading.gameObject.SetActive(false);

        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;

        balas.text = currentAmmo + " / " + maxAmmo;

        isReloading = false;
    }


    void OnUnScoped()
    {
        scopeOverlay.SetActive(false);

        mainCamera.fieldOfView = normalFOV;

        bottomSettings.SetActive(true);
        middleSettings.SetActive(true);


    }

    IEnumerator OnScoped()
    {
        yield return new WaitForSeconds(.15f);
        scopeOverlay.SetActive(true);

        normalFOV = mainCamera.fieldOfView;
        mainCamera.fieldOfView = scopedFOV;

        bottomSettings.SetActive(false);
        middleSettings.SetActive(false);


    }
}
