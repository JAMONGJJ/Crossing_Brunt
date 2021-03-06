using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePause : MonoBehaviour {

	public GameObject Pause_Canvas;
    private bool isPause;

	void Start () {
        isPause = false;
		hidePaused ();
	}
	
	public void Pause () {
		if(!isPause)
		{
			Time.timeScale = 0.0f;
            isPause = true;
			showPaused();
		} else
        {			
			Time.timeScale = 1.0f;
            isPause = false;
			hidePaused();
		}
	}

	public void showPaused(){
		Pause_Canvas.SetActive(true);
	}


	public void hidePaused(){
		Pause_Canvas.SetActive(false);
    }
}
