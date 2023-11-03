using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levers : MonoBehaviour
{
    private Vector3 playerPos;
    [SerializeField] private float activationDistance = 2;
    private GameObject player;
    private bool activated = false;
    private InputActions inputActions;
    private void Start()
    {
        gameObject.tag = "Puzzle";
        player = GameObject.Find("Player");
        activated = false;
    }
    private void FixedUpdate()
    {
        playerPos = player.transform.position;
        if (Vector3.Distance(playerPos, transform.position) < activationDistance)
            gameObject.tag = "Untagged";
    }
}
