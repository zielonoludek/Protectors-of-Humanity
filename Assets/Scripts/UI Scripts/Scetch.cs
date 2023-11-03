using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scetch : MonoBehaviour
{
    public GameObject canvas;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player")) canvas.SetActive(true);
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player")) canvas.SetActive(false);
    }
}
