using UnityEngine;

[CreateAssetMenu(fileName = "PlayerParameters", menuName = "PlayerParameters", order = 2)]

public class PlayerParameters : ScriptableObject
{
    public float movementSpeed;
    public float jumpHeight;
}