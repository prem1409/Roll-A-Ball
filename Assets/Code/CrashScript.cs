using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CrashScript : MonoBehaviour
{
    public AudioSource crash;

    void Start()
    {
        crash=GetComponent<AudioSource>();
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag ("Sphere")){        
            crash.Play();
        }
  
    }
}
