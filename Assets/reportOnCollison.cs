using UnityEngine;
using System.Collections;

public class reportOnCollison : MonoBehaviour 
{
    private Renderer rend;

    private string[] colorName;
    PuzzleControl01 puzzleController;
    private Material oldMaterial;

    void start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        oldMaterial = rend.material;
        
    }

    void OnTriggerEnter(Collider other)
    {
        puzzleController = transform.parent.gameObject.GetComponent("PuzzleControl01") as PuzzleControl01;
        puzzleController.checkValidity(gameObject.transform.name);
    }

    public void reaction()
    {
        if (true)
        {
            //rend.sharedMaterial = newMaterial;
        }
        
    }
}
