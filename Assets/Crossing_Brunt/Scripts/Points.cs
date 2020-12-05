using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {

    public float points;
    public float destoryTime;
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
            AudioSource.PlayClipAtPoint(snd, transform.position);
            Point_Manager.points += points;
            Destroy(this.gameObject, destoryTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Point_Manager.points += points;
            Destroy(this.gameObject, destoryTime);
        }
    }
}
