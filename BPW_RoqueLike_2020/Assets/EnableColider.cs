using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableColider : MonoBehaviour
{
    public bool abletohit;

    private void Update()
    {
        if (abletohit)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
        else
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "PlayerTrack")
        {
           PlayerHealth T = other.GetComponentInParent<PlayerHealth>();
            T.health = T.health - 10;
        }
    }
}
