using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PuddleTrapped : MonoBehaviour {

    public ParticleSystem particle;
    public AudioClip snd;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            particle.Play();
            AudioSource.PlayClipAtPoint(snd, transform.position);
            Game_Over.isCollision = true;
            PenguinScript.isCollided = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Game_Over.isCollision = true;
        }
    }
}
