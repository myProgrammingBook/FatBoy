using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

    // Use this for initialization

    public GameManager gm;
	void Start () {
        

    }
    private void Awake()
    {
        GameObject GameManagerObject = GameObject.Find("GameManager");
        gm = GameManagerObject.GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gm.updateCollect();
            Destroy(gameObject);
        }
    }
}
