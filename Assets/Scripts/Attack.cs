using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private GameObject ammo;
    [SerializeField] private Transform fireTransform;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private GameObject[] weapons;
     private int ammoCount = 0;
    private int maxAmmoCount = 5;
   [SerializeField] private bool isPlayer = false;
    [SerializeField] private bool isEnemy;
    [SerializeField] private AudioClip clipToPlay;
    [SerializeField] private AudioSource audioSource;


    private float currentFireRate = 0f;
    private GameManager gameManager;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public AudioClip GetClipToPlay
    {
        get
        {
            return clipToPlay;
        }
        set
        {
            clipToPlay = value;
        }
    }

    public int GetAmmo
    {
        get
        {
            return ammoCount--;
        }
        set
        {
            ammoCount = value;
            if (ammoCount > maxAmmoCount)
            {
                ammoCount = maxAmmoCount;
            }
        }
    }
    public float GetCurrentFireRate
    {
        get
        {
            return currentFireRate;

        }
        set
        {
            currentFireRate = value;
        }
    }

    public int GetClipSize
    {
        get
        {
            return maxAmmoCount;
        }
        set
        {
            maxAmmoCount = value;
        }
    }

    public float GetFireRate
    {
        get
        {
            return fireRate;
        }
        set
        {
            fireRate = value;
        }
    }

    public Transform GetFireTransform
    {
        get
        {
            return fireTransform;
        }
        set
        {
            fireTransform = value;
        }
    }

    private void Start()
    {
        ammoCount = maxAmmoCount;
    }

    void Update()
    {
        if(currentFireRate > 0f)
        {
            currentFireRate -= Time.deltaTime;

        }
        PlayerInput();




    }
    private void PlayerInput()
    {
        if (isPlayer && !gameManager.GetLevelFinished)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentFireRate <= 0 && ammoCount > 0)
                {

                    Fire();

                }
            }
        }
        if (isEnemy == false)
        {
            switch (Input.inputString)
            {
                case "1":
                    weapons[1].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount = ammoCount;
                    weapons[0].gameObject.SetActive(true);
                    weapons[1].gameObject.SetActive(false);
                    break;
                case "2":
                    weapons[0].gameObject.GetComponent<Weapon>().GetCurrentWeaponAmmoCount = ammoCount;
                    weapons[1].gameObject.SetActive(true);
                    weapons[0].gameObject.SetActive(false);

                    break;

            }

        }
        



    }

    public void Fire()
    {

        float targetRotation = 90f;
        float diffirence = 180f - transform.eulerAngles.y;
        if (diffirence >= 90)
        {
            targetRotation = -90f;
        }
        currentFireRate = fireRate;
        audioSource.PlayOneShot(clipToPlay);
        GameObject bulletClone= Instantiate(ammo, fireTransform.position, Quaternion.Euler(0f, 0f, targetRotation));
        bulletClone.GetComponent<Bullet>().owner = gameObject;
        ammoCount--;
        

    }
}
