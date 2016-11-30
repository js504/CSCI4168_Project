using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	public Animator animator;
	public float patrolDistance = 1.0f;
	public float speed = 2.0f;
	Vector3 velocity;
	bool facingRight;

	Vector3 startPos;

	bool moving = true;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		velocity = new Vector3 (speed, 0, 0);
		facingRight = true;
		animator.SetBool ("walking", true);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (moving) {
			float distanceTravelled = transform.position.x - startPos.x;
			if (facingRight) {
				if (-distanceTravelled >= patrolDistance) {

					FlipDirection ();
				}

				transform.Translate (velocity * Time.deltaTime * -1.0f);
			} else {
			
				if (distanceTravelled >= patrolDistance) {

					FlipDirection ();

				}

				transform.Translate (velocity * Time.deltaTime * -1.0f);

			}
		}


	}

	void FlipDirection(){
		facingRight = !facingRight;

		Vector3 enemyRot = transform.eulerAngles;

		if (!facingRight) {

			enemyRot.y = 180f;

		} else {

			enemyRot.y = 0f;

		}

		transform.eulerAngles = enemyRot;



		StartCoroutine (WaitRoutine());



	}

	IEnumerator WaitRoutine(){

		animator.SetBool ("walking", false);
		moving = false;
		yield return new WaitForSeconds (5f);
		moving = true;
		animator.SetBool ("walking", true);

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag.Equals ("Player")) {
			print ("hit the player");
			animator.SetBool ("attack", true);
		} 
	}

	void OnTriggerExit(Collider other){
		animator.SetBool ("attack", false);

	}


}
