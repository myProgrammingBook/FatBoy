using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public GameObject playerPrefab;
	public Text continueText;
	public Text scoreText;
    public Text points;

	private float timeElapsed = 0f;
	private float bestTime = 0f;
	private float blinkTime = 0f;
	private bool blink;
	private bool gameStarted;
	private TimeManager timeManager;
	private GameObject player;
	private GameObject floor;
	private Spawner spawner;
	private bool beatBestTime;

    //super Power mode
    public bool SuperPower;
    public int coinsCollected;
    public int TotalCoins;

    public Button b1;
    SoundSC sc;
    AudioSource audios; 

    void Awake(){
		floor = GameObject.Find ("Foreground");
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
		timeManager = GetComponent<TimeManager> ();
        Application.targetFrameRate = 100;
        sc = this.GetComponent<SoundSC>();

    }

	// Use this for initialization
	void Start () {
        TotalCoins = 0;
        coinsCollected = 0;
        SuperPower = false;
		var floorHeight = floor.transform.localScale.y;

		var pos = floor.transform.position;
		pos.x = 0;
		pos.y = -((Screen.height / PixelPerfectCamera.pixelsToUnits) / 2) + (floorHeight / 2);
		floor.transform.position = pos;

		spawner.active = false;

		Time.timeScale = 0;

		continueText.text = "PRESS ANY BUTTON TO START";

		bestTime = PlayerPrefs.GetFloat ("BestTime");
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted && Time.timeScale == 0) {

			if(Input.anyKeyDown){

				timeManager.ManipulateTime(1, 1f);
                b1.gameObject.SetActive(true);
				ResetGame();
			}
		}

		if (!gameStarted) {
			blinkTime ++;

			if (blinkTime % 40 == 0) {
				blink = !blink;
			}

			continueText.canvasRenderer.SetAlpha (blink ? 0 : 1);

			var textColor = beatBestTime ? "#FF0" : "#FFF";

			scoreText.text = "TIME: " + FormatTime (timeElapsed) + "\n<color="+textColor+">BEST: " + FormatTime (bestTime)+"</color>";
            

        } else {
			timeElapsed += Time.deltaTime;
			scoreText.text = "TIME: "+FormatTime(timeElapsed);
            points.text = "Points: " + TotalCoins;
        }
	}

	void OnPlayerKilled(){

        sc._audio.mute = true;

        spawner.active = false;

		var playerDestroyScript = player.GetComponent<DestroyOffscreen> ();
		playerDestroyScript.DestroyCallback -= OnPlayerKilled;

		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		timeManager.ManipulateTime (0, 5.5f);
		gameStarted = false;

        continueText.text = "PRESS ANY BUTTON TO RESTART";

		if (timeElapsed > bestTime) {
			bestTime = timeElapsed;
			PlayerPrefs.SetFloat("BestTime", bestTime);
			beatBestTime = true;
		}
	}

	void ResetGame(){

        TotalCoins = 0;
        sc._audio.mute = false;

        coinsCollected = 0;
        SuperPower = false;
		spawner.active = true;
        coinsCollected = 0;
        player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height/PixelPerfectCamera.pixelsToUnits)/2 + 100, 0));

		var playerDestroyScript = player.GetComponent<DestroyOffscreen> ();
		playerDestroyScript.DestroyCallback += OnPlayerKilled;

		gameStarted = true;

		continueText.canvasRenderer.SetAlpha(0);

		timeElapsed = 0;
		beatBestTime = false;
	}

	string FormatTime(float value){
		TimeSpan t = TimeSpan.FromSeconds (value);

		return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
	}

    public void updateCollect()
    {
        TotalCoins++;
        //when you select the 10th coin it will get full
        if (coinsCollected ==1)
        {
            SuperPower = true;
        }
        else
        {
            coinsCollected++;
        }
    }

}
