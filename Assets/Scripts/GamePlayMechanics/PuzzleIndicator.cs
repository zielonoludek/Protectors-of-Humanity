using System.Collections.Generic;
using UnityEngine;

public class PuzzleIndicator : MonoBehaviour
{
    [SerializeField] private int numberOfPuzzles;
    [SerializeField] private List<GameObject> lightList = new List<GameObject>();
    [SerializeField] private List<Material> materialList = new List<Material>();

    private void Awake()
    {
        GameObject[] puzzleList = GameObject.FindGameObjectsWithTag("Puzzle");
        numberOfPuzzles = puzzleList.Length;
        if (numberOfPuzzles != CountChildren()) Debug.LogError("Number of lights  is not equal to number of puzzles");
    }
    private void Update()
    {
        GameObject[] puzzleList = GameObject.FindGameObjectsWithTag("Puzzle");
        if (puzzleList.Length < numberOfPuzzles || puzzleList.Length > numberOfPuzzles) Invoke("ChangeColor", 0.5f);
        numberOfPuzzles = puzzleList.Length;
    }
    private int CountChildren()
    {
        foreach (Transform child in transform.GetComponentsInChildren<Transform>())
        {
            if (child.childCount == 0) lightList.Add(child.gameObject);
        }
        return lightList.Count;
    }
    private void ChangeColor()
    {
        

    }
}
