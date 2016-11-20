using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public Animator animator;
	public float speed = 5.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			animator.SetBool ("walking", true);
//
//			if (Input.GetAxis ("Horizontal") < 0) {
//				transform.rotation = Quaternion.Euler (0, 180, 0);
//				transform.Translate (Vector3.right * Time.deltaTime * speed);
//			} else if (Input.GetAxis ("Horizontal") > 0){
//				transform.rotation = Quaternion.Euler (0, 0, 0);
//				transform.Translate (Vector3.left * Time.deltaTime * speed);
//			}
		} else {
			animator.SetBool ("walking", false);
		}
	}
}
