using UnityEngine;
using System.Collections;

public class PlayerAnimationManager : MonoBehaviour {

	private Animator animator;
	private InputState inputState;
    private GameManager gm;

	void Awake(){
		animator = GetComponent<Animator> ();
		inputState = GetComponent<InputState> ();
        GameObject GameManagerObject = GameObject.Find("GameManager");
        gm = GameManagerObject.GetComponent<GameManager>();
    }

	// Update is called once per frame
	void Update () {
	
		var running = true;

		if (inputState.absVelX > 0 && inputState.absVelY < inputState.standingThreshold)
        {
            running = false;
        }

        if(gm.SuperPower)
        {
            running = false;
            animator.SetBool("running", running);
            animator.SetBool("SuperPower", true);
            StartCoroutine(waitfor());
        }
        animator.SetBool("running", running);

    }
  IEnumerator waitfor()
    {
        yield return new WaitForSeconds(5);
        gm.SuperPower = false;
        //animator.SetBool("running", true);
        animator.SetBool("SuperPower", false);

    }
}
