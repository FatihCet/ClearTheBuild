using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private AudioClip clipToPlay;

    [Header("Healts Settings")]
    public bool healtPowerUp = false;
    public int healtAmount = 1;

    [Header("Ammo Settings")]
    public bool ammoPowerUp = false;
    public int ammoAmount = 5;

    [Header("Transfrom Settings")]
    [SerializeField] private Vector3 turnVector = Vector3.zero;

    [Header("Scale Settings")]
    [SerializeField] private float period = 2f;
    [SerializeField] private Vector3 scaleVector;
    [SerializeField] private float scaleFactor;
    private Vector3 startScale;


    private void Awake()
    {
        startScale = transform.localScale;


    }
    void Start()
    {

        if(healtPowerUp==true && ammoPowerUp == true)
        {
            healtPowerUp = false;
            ammoPowerUp = false;

        }
        else if (healtPowerUp == true)
        {
            ammoPowerUp = false;
        }
        else if (ammoPowerUp == true)
        {
            healtPowerUp = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(turnVector);
        SinusWawe();

    }
    private void SinusWawe()
    {
        if (period <= 0)
        {
            period = 0.1f;
        }
        float cycles = Time.timeSinceLevelLoad / period;
        const float piX2 = Mathf.PI * 2;
        float sinuswawe = Mathf.Sin(cycles * piX2);
        scaleFactor = sinuswawe / 2 + 0.5f;
        Vector3 offset = scaleFactor * scaleVector;
        transform.localScale = startScale + offset;


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            return;
        }
        AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
        if (healtPowerUp==true)
        {

            other.gameObject.GetComponent<Target>().GetHealt += healtAmount;
            
        }else if (ammoPowerUp == true)
        {
            other.gameObject.GetComponent<Attack>().GetAmmo += ammoAmount;
        }
        Destroy(gameObject);

        if (healtPowerUp != default)
        {

        }
    }
}
