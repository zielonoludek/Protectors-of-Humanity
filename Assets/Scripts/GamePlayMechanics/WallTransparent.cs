using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTransparent : MonoBehaviour
{
    private Transform playerObj;
    
    [Header("Settings")]
    public LayerMask WallMask;
    public float maxDist;

    //Store materials and renderer for later on
    private Material prevMat;
    private Renderer lastHit;
    private void Awake()
    {
        playerObj = FindObjectOfType<Player>().transform;
    }
    void Update()
    {
        //Get distance from camera to player
        Vector3 cameraPos = transform.position;
        Vector3 playerPos = playerObj.position;
        Vector3 rayDist = playerPos - cameraPos ;

        //if the ray hits wallLayer withing maxDist then call onHit(hit), else call noHit(hit)
        RaycastHit hit;
        if (Physics.Raycast(cameraPos, rayDist, out hit, maxDist, WallMask))
        {
            Debug.DrawRay(cameraPos, rayDist, Color.blue);
            onHit(hit);
        }
        else
        {
            Debug.DrawRay(cameraPos, rayDist, Color.red);
           noHit(hit);
        }
    }

    public void onHit(RaycastHit hit)
    {
        
        //Store our oginal material when we get the first hit
        Renderer wallRender = hit.collider.GetComponent<Renderer>();
        if (wallRender != null)
        {
            if (prevMat == null)
            {
                prevMat = wallRender.material;
            }
            //Set materials float("Alpha") to .5
            Material wallMat = wallRender.material;
            wallMat.SetFloat("_Alpha", 0.5f);
            lastHit = wallRender;
        }
    }

    public void noHit(RaycastHit hit)
    {
        //if lastHit !=  null then set lastHit to prevMat, then set to null;
        if (lastHit != null)
        {
            lastHit.material = prevMat;
            lastHit = null;
        }
        //if prevMat != null then set our materials alpha to 1.0f, set to nyll
        if (prevMat != null)
        {
            prevMat.SetFloat("_Alpha", 1.0f);
            prevMat = null;
        }
    }
}
