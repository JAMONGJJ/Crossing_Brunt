using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {
    public Slider volumeSlider;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void volumeChanged()
    {
        AudioListener.volume = volumeSlider.value;
    }
}
