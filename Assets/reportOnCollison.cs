using UnityEngine;
using System.Collections;

public class reportOnCollison : MonoBehaviour 
{
    public Renderer rend;

    private bool isValidMove;
    string[] colorName;
    GameObject puzzleController;
    private Material oldMaterial;
    private Material newMaterial = Resources.Load("Decrepit Dungeon/Materials/CorrectMove", typeof(Material)) as Material;

    void start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        oldMaterial = rend.material;
        puzzleController = gameObject.transform.parent.gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        
        colorName = gameObject.transform.name.Split(' ');
        
        isValidMove = puzzleController.checkValidity(colorName[0]);
        print(colorName[0] + " is " + isValidMove);
        reaction(isValidMove);
    }

    public void reaction(bool isValid)
    {
        rend.sharedMaterial = newMaterial;
    }
}
