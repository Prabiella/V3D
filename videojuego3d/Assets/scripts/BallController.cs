using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{


    public Rigidbody rb;
    public float impulseForce = 3f;

    private bool ignoreNextCollition;

    private Vector3 startPosition;


    private void Start()
    {
        startPosition = transform.position;    
    }



    private void OnCollisionEnter(Collision collision)
    {

     


        if (ignoreNextCollition)
        {
            return;
        }



        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if (deathPart)
        {
            GameManager.singleton.RestartLevel();
        }


       // GameManager.singleton.AddScore(1);

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up* impulseForce, ForceMode.Impulse);
        Invoke("AllowNextCollition", 0.2f);

        ignoreNextCollition = true;
    }


    private void AllowNextCollition()
    {
        ignoreNextCollition = false;
    }


    public void ResetBall()
    {
        transform.position = startPosition;     
    }

}
