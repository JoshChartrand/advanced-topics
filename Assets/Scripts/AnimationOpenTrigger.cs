using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOpenTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay(Collider other) {
		if (other.gameObject.tag == "Hand") {
			if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) == 0 && (OVRInput.GetDown(OVRInput.Button.One))) {
				GetComponentInParent<Animator> ().SetBool("Pressed", !GetComponentInParent<Animator> ().GetBool("Pressed"));
				if (GetComponentInParent<Animator> ().GetBool ("Pressed") == false) {
					GameObject[] Items = GameObject.FindGameObjectsWithTag ("Item");
					foreach (GameObject item in Items) {
                        ItemScript itemScript = item.GetComponent<ItemScript>();
                        if (itemScript != null)
                        {
                            if (item.GetComponent<ItemScript>().InInventory)
                            {
                                item.transform.SetParent(transform.parent, true);
                                item.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                            }
                        }
					}
				} else if (GetComponentInParent<Animator> ().GetBool ("Pressed") == true) {
					GameObject[] Items = GameObject.FindGameObjectsWithTag ("Item");
					foreach (GameObject item in Items) {
                        ItemScript itemScript = item.GetComponent<ItemScript>();
                        if(itemScript != null) { 
                            if (item.GetComponent<ItemScript> ().InInventory) {
							    item.transform.parent = null;
							    item.transform.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
						    }
                        }
					}
				}
			}
			if(OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) == 0 && (OVRInput.GetDown(OVRInput.Button.Three))) {
				GetComponentInParent<Animator> ().SetBool("Pressed", !GetComponentInParent<Animator> ().GetBool("Pressed"));
				if(GetComponentInParent<Animator> ().GetBool("Pressed") == false) {
					GameObject[] Items = GameObject.FindGameObjectsWithTag ("Item");
					foreach(GameObject item in Items) {
                        ItemScript itemScript = item.GetComponent<ItemScript>();
                        if (itemScript != null)
                        {
                            if (item.GetComponent<ItemScript>().InInventory)
                            {
                                item.transform.SetParent(transform.parent, true);
                                item.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                            }
                        }
					}
				} else if (GetComponentInParent<Animator> ().GetBool ("Pressed") == true) {
					GameObject[] Items = GameObject.FindGameObjectsWithTag ("Item");
					foreach (GameObject item in Items) {
                        ItemScript itemScript = item.GetComponent<ItemScript>();
                        if (itemScript != null)
                        {
                            if (item.GetComponent<ItemScript>().InInventory)
                            {
                                item.transform.parent = null;
                                item.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                            }
                        }
					}
				}
			}
		}
	}
}
