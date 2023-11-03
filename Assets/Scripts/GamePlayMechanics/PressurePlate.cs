using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private GameObject pressButton;
    private bool shoudlMove = false; 
    private Vector3 endPosition;
    private Vector3 startPosition;
    private Vector3 destination;

    private void Awake()
    {
        pressButton = transform.Find("PressButton").gameObject;
        pressButton.transform.localPosition = new Vector3(pressButton.transform.localPosition.x, 0, pressButton.transform.localPosition.z);
        startPosition = pressButton.transform.localPosition;
        endPosition = startPosition + new Vector3(0, 0, -3f);
        destination = endPosition;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovableBox"))
        {
            shoudlMove = true;
            gameObject.tag = "Untagged";
            destination = endPosition;
        }
    }
    private void OnTriggerExit(Collider other)
    {   
        if (other.CompareTag("MovableBox"))
        {
            shoudlMove = true;
            gameObject.tag = "Puzzle";
            destination = startPosition;
        }
    }
    private void Update()
    {
        if (shoudlMove) pressButton.transform.localPosition = Vector3.MoveTowards(pressButton.transform.localPosition, destination, 5 * Time.deltaTime);
        else if (pressButton.transform.localPosition == destination)
        {
            shoudlMove = false;
            Debug.Log(1);
            gameObject.SetActive(false);
        }
    }
} 
