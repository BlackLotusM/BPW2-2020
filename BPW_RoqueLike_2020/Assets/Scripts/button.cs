using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class button : MonoBehaviour
    
{
    public bool exit1;
    // Start is called before the first frame update

    public button t;
    void Start()
    {
        Button tt = t.GetComponent<Button>();
        //t = this.gameObject.GetComponent<button>();
        if (exit1)
        {
            tt.onClick.AddListener(exit);
        }
        else
        {
            tt.onClick.AddListener(start);
        }
    }
    void exit()
    {
        Application.Quit();
    }

    void start()
    {
        SceneManager.LoadScene("Game");
        GameManager.enemiesCounter = 5;
        GameManager.level = 1;
    }
}
