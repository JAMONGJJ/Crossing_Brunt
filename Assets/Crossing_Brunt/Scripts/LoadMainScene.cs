using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour {
    float time;

    private void Start()
    {
        time = 0.0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 5.0)
            SceneManager.LoadScene("Main_Scene");
    }
}
