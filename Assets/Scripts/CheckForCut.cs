﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForCut : MonoBehaviour {

    //public AudioClip KnifeCut;

    AudioSource audioSource;
	public bool cut;
    public AudioSource audio = null;

    // Use this for initialization
    void Start () {
        audio = GetComponent<AudioSource>();
		cut = false;
        GetComponent<Rigidbody> ().maxAngularVelocity = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
    {
		if (col.gameObject.name == "Sickle" && col.relativeVelocity.magnitude >= 20)
        {
			if (cut == false) {
				GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
				GetComponent<Rigidbody> ().velocity = Vector3.zero;
				GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;
				transform.localScale = new Vector3 (transform.localScale.x * 0.5f, transform.localScale.y * 0.5f, transform.localScale.z * 0.5f);

				audio.Play ();
				cut = true;
			}
        }
	}
}
