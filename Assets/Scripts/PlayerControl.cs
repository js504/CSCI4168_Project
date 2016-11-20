using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public GameObject player;
	public Animator animator;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			animator.SetBool ("walking", true);
		} else {
			animator.SetBool ("walking", false);
		}
	}
}
