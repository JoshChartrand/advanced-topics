using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class item : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision colli)
    {
        if (colli.relativeVelocity.magnitude > 5) //requires a certain magnitude to open application
        {
            //Debug.Log(colli.relativeVelocity.magnitude);
            SceneManager.LoadScene("Word", LoadSceneMode.Single); //open new scene
        }
    }
}
