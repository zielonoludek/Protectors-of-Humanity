using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask obstructionLayer;

    private Renderer[] wallRenderers;

    private void Start()
    {
        // Get all wall renderers in your scene
        wallRenderers = FindObjectsOfType<Renderer>();
    }

    private void Update()
    {
        // Cast a ray from the camera to the player character
        Ray ray = mainCamera.ScreenPointToRay(mainCamera.WorldToScreenPoint(transform.position));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, obstructionLayer))
        {
            // Player is blocked, so set wall materials to transparent
            SetWallTransparency(true);
        }
        else
        {
            // Player is not blocked, so set wall materials back to normal
            SetWallTransparency(false);
        }
    }

    private void SetWallTransparency(bool isTransparent)
    {
        foreach (Renderer wallRenderer in wallRenderers)
        {
            Material[] materials = wallRenderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                if (isTransparent)
                {
                    // Set the transparent material for the wall
                    //materials[i] = transparentMaterial;
                }
                else
                {
// if there is an compiler error, we're unable to compile another scripts, so I comented line 46 and 54


                    // Set the normal material for the wall
                    //materials[i] = normalMaterial;
                }
            }
            wallRenderer.materials = materials;
        }
    }
}
