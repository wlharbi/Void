using UnityEngine;
using System.Collections;

public class PuzzleControl01 : MonoBehaviour {

    private bool isFinishedCorrectly = false;
    private bool isFailed = false;


    //The player can go from blue to green, green to red, and red to blue.
    //Any other moves will cause the player to fail and restart the puzzle.
    private string firstColor = "Blue";
    private string secondColor = "Green";
    private string thirdColor = "Red";

    private string trapColor = "Black";


    private string lastColor = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public bool checkValidity(string destinationColor)
    {
        print("CheckValidity is Called");
        if (lastColor == null)
        {
            if (destinationColor != firstColor) return false;
            lastColor = destinationColor;
            return true;
        }
        else if (lastColor == firstColor)
        {
            if (destinationColor == firstColor || destinationColor == thirdColor)
            {
                fail();
                return false;
            }
            else
            {
                correctMove(destinationColor);
                return true;
            }
        }
        else if (lastColor == secondColor)
        {
            if (destinationColor == secondColor || destinationColor == firstColor)
            {
                fail();
                return false;
            }
            else
            {
                correctMove(destinationColor);
                return true;
            }
        }
        else if (lastColor == thirdColor)
        {
            if (destinationColor == thirdColor || destinationColor == secondColor)
            {
                fail();
                return false;
            }
            else
            {
                correctMove(destinationColor);
                return true;
            }
        }
        else
            return false;
    }

    public void fail()
    {
        lastColor = null;
    }
    public void correctMove(string destinationColor)
    {
        lastColor = destinationColor;
    }
}
