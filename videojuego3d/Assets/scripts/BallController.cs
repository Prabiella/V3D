using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{


    public Rigidbody rb;
    public float impulseForce = 3f;

    private bool ignoreNextCollition;

    private Vector3 startPosition;


    //sCRIPT PARA INCREMENTAR LA VELOCIDAD
    public int perfectPass;
    public float superSpeed = 15;
    private bool isSuperSpeedActive;
    private int perfectPassCount = 2;




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

        //Comprovación

        if (isSuperSpeedActive && !collision.transform.GetComponent<GoalController>())
        {
            Destroy(collision.transform.parent.gameObject,0.2f);
        }

        else
        {
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
            {
                GameManager.singleton.RestartLevel();
            }
        }

       


       // GameManager.singleton.AddScore(1);

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up* impulseForce, ForceMode.Impulse);
        Invoke("AllowNextCollition", 0.2f);

        ignoreNextCollition = true;

        perfectPass = 0;
        isSuperSpeedActive = false;
    }



    //Verifica si hay super speed

    private void Update()
    {
        if (perfectPass >= perfectPassCount &&! isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            rb.AddForce(Vector3.down * superSpeed, ForceMode.Impulse);
        }
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
