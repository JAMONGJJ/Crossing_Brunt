using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Over : MonoBehaviour {

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;
    public static bool isCollision;

	// Use this for initialization
	void Start () {
        isCollision = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isCollision)
            Life_Check();
	}

    public void Life_Check() {
        
        if (Life3.activeSelf == true)
        {
            Life3.SetActive(false);
        }
        else if (Life2.activeSelf == true)
        {
            Life2.SetActive(false);
        }
        else if (Life1.activeSelf == true)
        {
            Life1.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene("Game_Over_Scene");
        }
        isCollision = false;
    }
}
