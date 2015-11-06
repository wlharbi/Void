using UnityEngine;
using System.Collections;

public class collisionControl : MonoBehaviour {

    PlayerHealth playerHealth;
    void OnTriggerEnter(Collider other)
    {
        playerHealth = other.GetComponent<PlayerHealth>();
        GameObject.Find("Floor").SetActive(false);
        StartCoroutine(myDelay(.8f));
        //other.GetComponent<PlayerHealth>().TakeDamage(100);
    }


    IEnumerator myDelay(float amount)
    {
        yield return new WaitForSeconds(amount);
        playerHealth.TakeDamage(100);
    }
}
