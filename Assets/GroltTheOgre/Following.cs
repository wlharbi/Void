using UnityEngine;
using System.Collections;

public class Following : MonoBehaviour {

    var leader : Transform;
var follower : Transform;
var speed : float =5; // The speed of the follower
 
function Update()
    {
        follower.LookAt(leader);
        follower.Translate(speed * Vector3.forward * Time.deltaTime);
    }

}
