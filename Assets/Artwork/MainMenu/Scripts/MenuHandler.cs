using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    SoundSC sc;
    public Button on;
    public Button off;
    private void Awake()
    {
        GameObject s = GameObject.Find("GameManager");
        sc = s.GetComponent <SoundSC> ();
    }
    public Canvas c;

    public void startgame(string gamelevel)
    {
        SceneManager.LoadScene(gamelevel);

    }
    public void exitgame()
    {
        Application.Quit();

    }
    public void help()
    {
        Debug.Log("here");
        c.GetComponent<Canvas>().enabled = !c.GetComponent<Canvas>().enabled;
    }
    public void voiceCommandchange()
    {
        if(sc.voiceCommand)
        {
            
            on.GetComponent<Image>().enabled = false;
            off.GetComponent<Image>().enabled = true;
            sc.voiceCommand = false;
        }
        else
        {
            off.GetComponent<Image>().enabled = false;
            on.GetComponent<Image>().enabled = true;
            sc.voiceCommand = true;
        }
    }
}
