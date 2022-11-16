using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    private void Start(){
        Invoke("destroyGameObj", 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth == null ){return;}

        playerHealth.Crash();
    }

    
    private void destroyGameObj()
    {
        Destroy(gameObject);
    }
}
