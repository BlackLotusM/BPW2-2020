using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 20f;
    public bool hasbeenhit;

    private void Start()
    {
        hasbeenhit = false;
    }
    //public GameObject deathParticle;
    public void getHit(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

        void Die()
        {
            //Instantiate(deathParticle, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
