using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripttest : MonoBehaviour
{
    public float distance;

    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("enemy").Length <= 0)
        {
            this.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}
