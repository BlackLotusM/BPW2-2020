using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwordScript : MonoBehaviour
{
    public Animator anim;
    public bool checkforhit;
    public bool canhit;
    public int BaseDamage;
    public int SpecialDamage;
    public GameObject t;
    public UIItem t2;

    private void Start()
    {
        //t = GameObject.Find("Slot1");
        
        t2 = t.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<UIItem>();
        canhit = false;
        checkforhit = false;
        anim = GetComponent<Animator>();           
    }
    private void Update()
    {
        try
        {
            t2.item.stats.TryGetValue("BaseDamage", out int ree);
            if (BaseDamage != ree)
            {
                BaseDamage = ree;
            }

            t2.item.stats.TryGetValue("SpecialDamage", out int ree2);

            if (SpecialDamage != ree2)
            {
                SpecialDamage = ree2;
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    canhit = true;
                    checkforhit = true;
                    anim.Play("leftClick");
                }

                if (Input.GetMouseButtonDown(1))
                {
                    canhit = true;
                    anim.Play("RightClick");
                }
            }
            gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
        }
        catch
        {
            gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if(other.gameObject.name == "enemie")
        {
            GameObject enemy = other.gameObject;
            if (!enemy.GetComponent<Health>().hasbeenhit)
            {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("leftClick"))
                {
                    enemy.GetComponent<Health>().hasbeenhit = true;
                    other.gameObject.GetComponent<Health>().getHit(BaseDamage);
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("RightClick"))
                {
                    enemy.GetComponent<Health>().hasbeenhit = true;
                    other.gameObject.GetComponent<Health>().getHit(SpecialDamage);
                }
            }
            else
            {

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "enemie")
        {
            other.gameObject.GetComponent<Health>().hasbeenhit = false;
        }
    }

    public void checkhit()
    {
        if (checkforhit)
        {
            checkforhit = false;
        }
        else
        {
            checkforhit = true;
            canhit = false;
        }
    }
}
