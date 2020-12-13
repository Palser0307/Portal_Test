using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("portal")){
            this.GetComponent<Transform>().position=cam.GetComponent<Transform>().position;
        }
    }
}
