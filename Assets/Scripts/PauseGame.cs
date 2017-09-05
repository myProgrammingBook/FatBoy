using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    bool pause;
    public Canvas c;
    public bool clicked = false;
    // Use this for initialization
    public Button b1;
    public Sprite[] s1 = new Sprite[2];
    void Start () {
        pause = false;

         
    }


    // Update is called once per frame
    void Update () {
		
	}
    public void OnPause()
    {
        pause = !pause;

        if(!pause)
        {
            Time.timeScale = 1;
            b1.image.sprite = s1[0];
            c.GetComponent<Canvas>().enabled = false;


        }
        else if(pause)
        {
            c.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            b1.image.sprite = s1[1];
        }

    } 
}
