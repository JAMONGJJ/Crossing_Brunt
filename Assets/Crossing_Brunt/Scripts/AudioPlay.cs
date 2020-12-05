using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {

    public AudioClip snd;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void sound_Play()
    {
        AudioSource.PlayClipAtPoint(snd, transform.position);
    }
}
