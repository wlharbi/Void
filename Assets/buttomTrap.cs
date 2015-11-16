using UnityEngine;
using System.Collections;

public class buttomTrap : MonoBehaviour {
    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerHealth>().TakeDamage(100);
    }
}
