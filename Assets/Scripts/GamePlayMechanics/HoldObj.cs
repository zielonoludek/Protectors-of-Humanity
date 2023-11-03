using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HoldObj : MonoBehaviour
{
    //What layer we are able to pickup 
    [SerializeField] private LayerMask PickupMask;
    //Does so we can use raycast
    [SerializeField] private Camera PlayerCamera;
   
    [SerializeField] private Transform PickupTarget;
    [SerializeField] private float PickupRange;

    private Rigidbody CurrentObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit HitInfo, PickupRange, PickupMask))
            {
                CurrentObject = HitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;
            CurrentObject.velocity = DirectionToPoint * 10 * DistanceToPoint;
        }
    }
}
