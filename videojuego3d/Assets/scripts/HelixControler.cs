using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixControler : MonoBehaviour
{
    private Vector2 lastTapPosition;//esta es la última position de la pantalla
    private Vector3 startPosition;//esta es la posicióndel Helix

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localEulerAngles;//Cual es la posición inical del HElix
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))//Si pulsamos el botón uzq del boton o presionamos con el dedo
        {
            Vector2 currentTapPosition = Input.mousePosition; //cual es la psoition actual de la pantalla y se iguala a pla psoition del mausae
            if (lastTapPosition==Vector2.zero) //O si no tocamos la pantalla
            {
                lastTapPosition = currentTapPosition; //Esta será la posición actual
            }
            float distance = lastTapPosition.x - currentTapPosition.x;
            lastTapPosition = currentTapPosition;

            transform.Rotate(Vector3.up * distance);
        }
        if (Input.GetMouseButtonUp(0)) //para indicar cuando movemos el dedo de la pantalla
        {
            lastTapPosition = Vector2.zero;
        }
    }
}
