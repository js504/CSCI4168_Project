using UnityEngine;
using System.Collections;

public class GrowTree : MonoBehaviour {

	public GameObject tree;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.name.Equals ("Player")) {
			Instantiate (tree, other.transform.position, transform.rotation);
		}
	}
}
