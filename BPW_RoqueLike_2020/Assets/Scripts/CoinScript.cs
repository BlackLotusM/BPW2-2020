    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public int indexitem;

    private void Update()
    {
        if(GameManager.level == 1)
        {
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.white;
        }
        else if (GameManager.level == 2)
        {
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (GameManager.level == 3)
        {
            this.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
