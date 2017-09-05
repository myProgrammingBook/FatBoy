using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

	public float jumpSpeed = 240f;
	public float forwardSpeed = 20;

	private Rigidbody2D body2d;
	private InputState inputState;
    private SoundSC sos;
	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();
		inputState = GetComponent<InputState> ();

        GameObject GameManagerObject = GameObject.Find("GameManager");
      
        sos = GameManagerObject.GetComponent<SoundSC>();
       

    }

	// Update is called once per frame
	void Update () {

		if (inputState.standing) {
			if((inputState.actionButton || sos.loudness>6)) {
				body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0, jumpSpeed);
			}

		}

	}
}
