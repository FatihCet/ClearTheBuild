using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject levelFinishedParent;
    private bool levelFinished = false;

    private Target playerHealt;
    public bool GetLevelFinished
    {
        get
        {
            return levelFinished;
        }
        set
        {
            levelFinished = value;
        }
    }
    private void Awake()
    {

        playerHealt = GameObject.FindGameObjectWithTag("Player").GetComponent<Target>();

    }


    void Update()
    {
       


        int enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount <= 0 || playerHealt.GetHealt<=0)
        {
            levelFinishedParent.gameObject.SetActive(true);
            levelFinished = true;

        }
        else
        {
            levelFinishedParent.gameObject.SetActive(false);
            levelFinished = false;
        }
    }

    public void RestartLevel()
    {

        SceneManager.LoadScene(0);
    }
}
