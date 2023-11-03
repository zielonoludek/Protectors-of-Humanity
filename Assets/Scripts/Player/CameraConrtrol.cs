using UnityEngine;

public class CameraConrtrol : MonoBehaviour
{
    private Transform camTarget;
    public Transform FPtarget;
    public Transform THtarget;

    private float pLerp = 0.2f;
    private float rLerp = 0.1f;
    private Player player;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {
        if (player.firstPersonCamera) camTarget = FPtarget; 
        else camTarget = THtarget;

        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp); ; 
    }
}