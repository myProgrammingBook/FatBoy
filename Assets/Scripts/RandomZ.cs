using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomZ : MonoBehaviour {
    int randnum;

    // Use this for initialization
    void Start () {
        randnum = Random.Range(0, 4);

    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + randnum);
    }
}
