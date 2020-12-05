using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_Manager : MonoBehaviour {

    public Text pointsText;
    public static float points = 0 ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        pointsText.text = points.ToString();
	}
}
