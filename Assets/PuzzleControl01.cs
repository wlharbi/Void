using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleControl01 : MonoBehaviour {

    private bool isFinishedCorrectly = false;
    private bool isFailed = false;
    private string fullChildObjectName;
    private List<string> trampledObjects;

    //The player can go from blue to green, green to red, and red to blue.
    //Any other moves will cause the player to fail and restart the puzzle.
    private string firstColor = "Blue";
    private string secondColor = "Green";
    private string thirdColor = "Red";
    private string trapColor = "Black";

    private string lastColor = null;

    private Material firstMaterial;
    private Material secondMaterial;
    private Material thirdMaterial;

    private Material correctMoveMaterial;
    // Use this for initialization
    void Start () {
        trampledObjects = new List<string>();
        firstMaterial = Resources.Load("Decrepit Dungeon/Materials/Blue", typeof(Material)) as Material;
        secondMaterial = Resources.Load("Decrepit Dungeon/Materials/Green", typeof(Material)) as Material;
        thirdMaterial = Resources.Load("Decrepit Dungeon/Materials/Red", typeof(Material)) as Material;

        correctMoveMaterial = Resources.Load("Decrepit Dungeon/Materials/CorrectMove.mat", typeof(Material)) as Material;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void checkValidity(string destinationColor)
    {
        fullChildObjectName = destinationColor;
        trampledObjects.Add(fullChildObjectName);
        destinationColor = destinationColor.Split(' ')[0];

        print("Full Object name is: " + fullChildObjectName);
        if (lastColor == null)
        {
            if (destinationColor != firstColor) return;
            lastColor = destinationColor;
            correctMove(fullChildObjectName);
            return;
        }
        else if (lastColor == firstColor)
        {
            if (destinationColor == firstColor || destinationColor == thirdColor)
            {
                fail();
                return;
            }
            else
            {
                correctMove(destinationColor);
                return;
            }
        }
        else if (lastColor == secondColor)
        {
            if (destinationColor == secondColor || destinationColor == firstColor)
            {
                fail();
                return;
            }
            else
            {
                correctMove(fullChildObjectName);
                return;
            }
        }
        else if (lastColor == thirdColor)
        {
            if (destinationColor == thirdColor || destinationColor == secondColor)
            {
                fail();
                return;
            }
            else
            {
                correctMove(fullChildObjectName);
                return;
            }
        }
    }

    public void fail()
    {
        lastColor = null;
        for(int i=0; i< trampledObjects.Count; i++)
        {
            GameObject childObject = GameObject.Find(trampledObjects[i]);
            Renderer My_renderer = childObject.GetComponent<Renderer>();
            string childName = childObject.transform.name;
            if (childName.Contains("Blue"))
            {
                My_renderer.material = firstMaterial;
            }
            else if (childName.Contains("Green"))
            {
                My_renderer.material = secondMaterial;
            }
            else if (childName.Contains("Red"))
            {
                My_renderer.material = thirdMaterial;
            }
        }
    }
    public void correctMove(string destinationColor)
    {
        lastColor = destinationColor.Split(' ')[0];
        if (lastColor != "Black")
        {
            print("I will Change "+ destinationColor + " To White");
            GameObject childObject = GameObject.Find(destinationColor);
            Renderer My_renderer = childObject.GetComponent<Renderer>();
            My_renderer.material = correctMoveMaterial;
        }
    }
}
