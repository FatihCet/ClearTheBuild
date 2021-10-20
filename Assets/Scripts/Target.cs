using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private int maxHealt = 2;
    private int currentHealt;

    [SerializeField] private GameObject hitFx;
    [SerializeField] private GameObject deadFx;
    [SerializeField] private AudioClip clipToPlay;

    public int GetMaxHealt
    {
        get
        {
            return maxHealt;

        }
        set
        {
            maxHealt = value;
        }
    }
    public int GetHealt
    {
        get
        {
            return currentHealt;
        }
        set
        {
            currentHealt = value;
            if (currentHealt > maxHealt)
            {
                currentHealt = maxHealt;
            }

        }
    }
    private void Awake()
    {
        currentHealt = maxHealt;


    }


    private void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.gameObject.GetComponent<Bullet>();

        if (bullet)
        {
            if(bullet && bullet.owner != gameObject)
            {
                AudioSource.PlayClipAtPoint(clipToPlay, transform.position);
                currentHealt--;

                if (hitFx != null)
                {
                    Instantiate(hitFx, transform.position, Quaternion.identity);
                }


                if (currentHealt <= 0)
                {

                    Die();
                }
                Destroy(other.gameObject);


            }




        }

    }
    private void Die()
    {
        if (deadFx != null)
        {

            Instantiate(deadFx, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);

    }

}
