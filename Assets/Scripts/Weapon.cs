using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Attack attack;
    [SerializeField] private Transform fireTransfrom;
    [SerializeField] private float fireRate;
    [SerializeField] private int clipSize;
    [SerializeField] private AudioClip clip;
    private int currentAmmocount;

    public int GetCurrentWeaponAmmoCount
    {
        get
        {
            return currentAmmocount;
        }
        set
        {
            currentAmmocount = value;
        }
    }
    void Start()
    {
        currentAmmocount = clipSize;
    }


    private void OnEnable()
    {
        if(attack != null)
        {

            attack.GetFireTransform = fireTransfrom;
            attack.GetClipSize = clipSize;
            attack.GetFireRate = fireRate;
            attack.GetAmmo = currentAmmocount;
            attack.GetClipToPlay = clip;
        }
    }
}
