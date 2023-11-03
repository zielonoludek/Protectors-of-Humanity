using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Door : MonoBehaviour
{
    [SerializeField] private List<GameObject> puzzlesToSolve = new List<GameObject>();
    private int numeberOfPuzzles;

    private GameObject leftDoor;
    private GameObject rightDoor;

    private Vector3 initPosLeft;
    private Vector3 initPosRight;

    private Vector3 endPosLeft;
    private Vector3 endPosRight;
    private bool doorClosed = true;

    private void Awake()
    {
        leftDoor = transform.Find("DoorLeft").gameObject;
        rightDoor = transform.Find("DoorRight").gameObject;
        numeberOfPuzzles = puzzlesToSolve.Count;

        initPosLeft = leftDoor.transform.localPosition;
        initPosRight = rightDoor.transform.localPosition;

        endPosLeft = initPosLeft + new Vector3(0.004f, 0, 0);
        endPosRight = initPosRight + new Vector3(-0.01f, 0, 0);
    }
    private void Update()
    {
        int solved = 0;
        for (int i = 0; i < numeberOfPuzzles; i++)
        {
            if (puzzlesToSolve[i].tag == "Untagged") solved++;
        }

        if (leftDoor.transform.localPosition == initPosLeft && rightDoor.transform.localPosition == initPosRight) doorClosed = true;
        else doorClosed = false;

        if (solved == numeberOfPuzzles) OpenDoor();
        else if (solved != numeberOfPuzzles) CloseDoor();
    }
    private void OpenDoor()
    {
        leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, endPosLeft, 0.01f * Time.deltaTime);
        rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, endPosRight, 0.01f * Time.deltaTime);
    }
    private void CloseDoor()
    {
        if (!doorClosed)
        {
            leftDoor.transform.localPosition = Vector3.MoveTowards(leftDoor.transform.localPosition, initPosLeft, 0.01f * Time.deltaTime);
            rightDoor.transform.localPosition = Vector3.MoveTowards(rightDoor.transform.localPosition, initPosRight, 0.01f * Time.deltaTime);
        }
    }
}
