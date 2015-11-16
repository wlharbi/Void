using UnityEngine;
using System.Collections;

public class collisionControl : MonoBehaviour {

  
    void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Floor").SetActive(false);
        StartCoroutine(myDelay(2f));
    }


    IEnumerator myDelay(float amount)
    {
        yield return new WaitForSeconds(amount);
        GameObject.Find("Floor").SetActive(true);
    }
}
