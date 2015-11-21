using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuzzleControl01 : MonoBehaviour {

    private bool isFinishedCorrectly = false;
    private bool isPassedByEntrance = false;
    private string fullChildObjectName;
    private List<string> trampledObjects;

    //The player can go from blue to green, green to red, and red to blue.
    //Any other moves will cause the player to fail and restart the puzzle.
    private string firstColor = "Blue";
    private string secondColor = "Green";
    private string thirdColor = "Red";
    //private string trapColor = "Black";

    private string lastColor = null;

    [SerializeField]
    private Material firstMaterial;
    [SerializeField]
    private Material secondMaterial;
    [SerializeField]
    private Material thirdMaterial;
    [SerializeField]
    private Material correctMoveMaterial;
    // Use this for initialization
    void Start () {
        trampledObjects = new List<string>();
    }

    public void checkValidity(string destinationObject)
    {
        if (destinationObject=="Entrance")
        {
            if (trampledObjects.Count > 0) fail();
            isPassedByEntrance = true;
            return;
        }
        if (destinationObject.Contains("Border"))
        {
            if(destinationObject=="TopBorder" && trampledObjects[trampledObjects.Count - 1].Contains("Blue"))
            {
                win();
                return;
            }
            fail();
            return;
        }

        fullChildObjectName = destinationObject;
        trampledObjects.Add(fullChildObjectName);
        destinationObject = destinationObject.Split(' ')[0];
        //print("Full Object name is: " + fullChildObjectName);
        
        if (lastColor == null && isPassedByEntrance)
        {
            if (destinationObject != firstColor) return;
            lastColor = destinationObject;
            correctMove(fullChildObjectName);
            return;
        }
        else if (lastColor == firstColor)
        {
            if (destinationObject == secondColor)
                correctMove(fullChildObjectName);
            else
                fail();
            return;
        }
        else if (lastColor == secondColor)
        {
            if (destinationObject == thirdColor)
                correctMove(fullChildObjectName);
            else
                fail();
            return;
        }
        else if (lastColor == thirdColor)
        {
            if (destinationObject == firstColor)
                correctMove(fullChildObjectName);
            else
                fail();
            return;
        }
        else
            fail();
    }

    public void fail()
    {  
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
        trampledObjects.Clear();
        lastColor = null;
        isPassedByEntrance = false;
    }
    public void correctMove(string destinationObject)
    {
        lastColor = destinationObject.Split(' ')[0];
        if (lastColor != "Black")
        {
            //print("I will Change "+ destinationObject + " To White");
            GameObject childObject = GameObject.Find(destinationObject);
            Renderer My_renderer = childObject.GetComponent<Renderer>();
            My_renderer.material = correctMoveMaterial;
        }
    }
    public void win()
    {
        print("You Win!");
        fail();
    }
}
