using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPart : MonoBehaviour
{
    public string hexColor = "#E1523D"; // Color rojo como ejemplo

    private void OnEnable()
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hexColor, out color))
        {
            GetComponent<Renderer>().material.color = color;
        }
        else
        {
            Debug.LogError("Error al convertir el color hexadecimal");
        }
    }
}
