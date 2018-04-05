using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AI : MonoBehaviour {

	public GameObject catMesh;
	public float moveForce = 0f;
	private Rigidbody rbody;
	public Vector3 moveDir;
	public LayerMask whatIsWall;
	public float maxDistFromWall = 0f;

	public int DirMinTime = 5;
	public int DirMaxTime = 20;
	private float Dirtimez = 0;
	private float DirRandTime;

	public int StaMinTime = 10;
	public int StaMaxTime = 20;
	private float Statimez = 0;
	private float StaRandTime;

	public int WaiMinTime = 1;
	public int WaiMaxTime = 8;
	private float Waitimez = 0;
	private float WaiRandTime;

	private float y;

	public float health = 50.0f;

	public GameObject Meat = null;
	public GameObject Cloudpuff = null;

	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody> ();
		moveDir = ChooseDirection ();
		transform.rotation = Quaternion.LookRotation (moveDir);
		//rend = catMesh.GetComponent<SkinnedMeshRenderer> ();
		//rend.material.mainTexture = catTex;
		//zombie = false;
		//GlobalValues.ZombieCats = 0; 
		DirRandTime = Random.Range (DirMinTime, DirMaxTime);
		StaRandTime = Random.Range (StaMinTime, StaMaxTime);
		WaiRandTime = Random.Range (WaiMinTime, WaiMaxTime);

		y = transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		if(Statimez + StaRandTime > Time.time){
			rbody.velocity = moveDir * moveForce;
			if(Physics.Raycast(transform.position, transform.forward, maxDistFromWall, whatIsWall)){
				moveDir = ChooseDirection ();
				transform.rotation = Quaternion.LookRotation (moveDir);
			}

			if (Dirtimez + DirRandTime < Time.time){
				moveDir = ChooseDirection ();
				transform.rotation = Quaternion.LookRotation (moveDir);
				Dirtimez = Time.time;
				DirRandTime = Random.Range (DirMinTime, DirMaxTime);
			}
		}
		else{
			//print ("pause");
			rbody.velocity = new Vector3(0,0,0);
			if(Waitimez + WaiRandTime < Time.time){
				//print ("unpause");
				Statimez = Time.time;
				StaRandTime = Random.Range (StaMinTime, DirMaxTime);
				Waitimez = Time.time;
				WaiRandTime = Random.Range (WaiMinTime, WaiMaxTime);
			}
		}

		if(y != transform.position.y){
			transform.position = new Vector3 (transform.position.x, y, transform.position.z);
		}

		if (health <= 0) {
			Instantiate (Meat, transform.position, transform.rotation);
			Instantiate (Cloudpuff, transform.position, transform.rotation);
			//PLAY SOUND
			Destroy (transform.gameObject);
		}
	}

	Vector3 ChooseDirection()
	{
		System.Random ran = new System.Random ();
		int i = ran.Next (0,3);
		Vector3 temp = new Vector3 ();

		if(i==0){
			temp = transform.forward;
		}
		else if(i == 1){
			temp = transform.right;
		}
		else if(i == 2){
			temp = transform.right;
		}
		return temp;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name.Contains("Rock")) {
			health -= col.relativeVelocity.magnitude;
			// PLAY PIGGIE SOUND
		}
	}
}
