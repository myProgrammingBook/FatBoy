using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSC : MonoBehaviour {

    // Use this for initialization
    public float sensitivity = 100;
    public float loudness = 0;
    public AudioSource _audio;
    public bool voiceCommand = false;
	void Start () {
        if (voiceCommand)
        {
            _audio = GetComponent<AudioSource>();
            _audio.clip = Microphone.Start(null, true, 10, 44100);
            _audio.loop = true;

            while (!(Microphone.GetPosition(null) > 0))
            { }
            _audio.Play();

        }



    }
	
	// Update is called once per frame
	void Update () {
        if (voiceCommand)
        {
            loudness = getAverageVolume() * sensitivity;
        }
		
	}
    float getAverageVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);

        foreach(float s in data)
        {
            a += Mathf.Abs(s);
        }

        return a / 256;

    }

}
