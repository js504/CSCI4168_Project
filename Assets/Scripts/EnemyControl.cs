using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	public float patrolDistance = 1.0f;
	public float speed = 2.0f;
	Vector3 velocity;
	bool facingRight;

	Vector3 startPos;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		velocity = new Vector3 (speed, 0, 0);
		facingRight = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		float distanceTravelled = transform.position.x - startPos.x;
		if (facingRight) {
			if (-distanceTravelled >= patrolDistance) {

				FlipDirection ();
			}

			print (distanceTravelled);

			transform.Translate (velocity * Time.deltaTime * -1.0f);
		} else {
			
			if (distanceTravelled >= patrolDistance) {

				FlipDirection ();

			}
			print ("enemy going left");
			transform.Translate (velocity * Time.deltaTime * -1.0f);

		}



	}

	void FlipDirection(){
		facingRight = !facingRight;

		Quaternion enemyRot = transform.localRotation;

		if (!facingRight) {

			enemyRot.y = 180f;

		} else {

			enemyRot.y = 0f;

		}

		transform.localRotation = enemyRot;

	}
}
