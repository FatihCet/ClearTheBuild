using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpPower = 13f;
    [SerializeField] private float turnSpeed = 15f;
    [SerializeField] private Transform[] rayStartPoints;
    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();


    }
    

    
    void Update()
    {
        if (!gameManager.GetLevelFinished)
        {
            PlayerMove();

        }







    }

    void PlayerMove()
    {

        if (Input.GetKeyDown(KeyCode.Space)&& OnGroundCheck())
        {

            rb.velocity = new Vector3(rb.velocity.x,Mathf.Clamp((jumpPower * 100) * Time.deltaTime,0f,15f), 0f);
            

        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(Mathf.Clamp((speed * 100) * Time.deltaTime,0f,15f), rb.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 90f, 0f), turnSpeed * Time.deltaTime);

        }
        else if (Input.GetKey("d"))
        {

            rb.velocity = new Vector3(Mathf.Clamp((-speed * 100) * Time.deltaTime, -15f, 0f), rb.velocity.y, 0f);
            //transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, -90f, 0f), turnSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        }


    }
    private bool OnGroundCheck()
    {

        bool hit = false;
        for (int i = 0; i <rayStartPoints.Length; i++)
        {
            hit = Physics.Raycast(rayStartPoints[i].position, -rayStartPoints[i].transform.up, 0.25f);
            Debug.DrawRay(rayStartPoints[i].position, -rayStartPoints[i].transform.up * 0.25f, Color.red);


        }
        if (hit)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
   
 
}
