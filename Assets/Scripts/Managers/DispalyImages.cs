using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayImages : MonoBehaviour
{
    [SerializeField] private RawImage Image;
    [SerializeField] private List<Texture> Images = new List<Texture>();

    private int currentIndex = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DisplayNextText();
        }
    }
    private void DisplayNextText()
    {
        if (currentIndex < Images.Count)
        {
            Image.texture = Images[currentIndex];
            currentIndex++;
        }
        else gameObject.SetActive(false);
    }
}