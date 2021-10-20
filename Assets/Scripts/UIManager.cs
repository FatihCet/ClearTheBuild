using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image healtFill;
    public Image ammoFill;
    private Attack playerAmmo;
    private Target playerHealt;


    private void Awake()
    {
        playerAmmo = GameObject.FindGameObjectWithTag("Player").GetComponent<Attack>();
        playerHealt = playerAmmo.GetComponent<Target>();


    }
    // Update is called once per frame
    void Update()
    {


        UpdateHealtFill();
        UpdateAmmoFill();
    }

    private void UpdateHealtFill()
    {
        //int olursa direkt 0-1 arası döner
        healtFill.fillAmount = (float)playerHealt.GetHealt / playerHealt.GetMaxHealt;


    }
    private void UpdateAmmoFill()
    {

        //yukarıda ki bilgi geçerli
        ammoFill.fillAmount = (float)playerAmmo.GetAmmo / playerAmmo.GetClipSize;

    }
    


    
}
