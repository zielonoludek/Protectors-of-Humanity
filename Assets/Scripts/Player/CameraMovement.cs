using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Player player;
    private void Awake()
    {   
        player = FindObjectOfType<Player>();
    }
    private void Update()
    {
        if (player.firstPersonCamera) transform.position = player.transform.position + new Vector3(0, 1.3f, -2.2f); 
        else transform.position = player.transform.position + new Vector3(0, 8.5f, -7f);
    }
}