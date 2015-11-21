using UnityEngine;
using System.Collections;

public class reportOnCollison : MonoBehaviour 
{
    PuzzleControl01 puzzleController;

    void OnTriggerEnter(Collider other)
    {
        puzzleController = transform.parent.gameObject.GetComponent("PuzzleControl01") as PuzzleControl01;
        puzzleController.checkValidity(gameObject.transform.name);
    }

}
