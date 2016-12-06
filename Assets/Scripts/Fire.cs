using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	public Transform playerFire;

	//public Transform fire;
	// Use this for initialization
	void Start () {
		playerFire.GetComponent<ParticleSystem> ().Stop();
	}


	// Update is called once per frame
	void Update () {
		//playerFire.GetComponent<ParticleSystem> ().enableEmission = false;
	}
	void OnParticleCollision(GameObject other){
		if (other.gameObject.name.Equals ("Particle System") || other.gameObject.name.Equals ("Particle System(Clone)")) {
			Debug.Log ("hittttttttttt");
			playerFire.GetComponent<ParticleSystem> ().Play();
			StartCoroutine (stopFire ());
		}
	}
	IEnumerator stopFire(){
		yield return new WaitForSeconds (15);
		playerFire.GetComponent<ParticleSystem> ().Stop();
	}


	public Transform fire; // drag your explosion prefab here
	//public GameObject hold;
	public void OnCollisionEnter(Collision other){
		if(playerFire.GetComponent<ParticleSystem> ().isPlaying == true){
			Instantiate(fire, other.transform.position, Quaternion.identity, other.transform);
		}
		if (other.gameObject.name.Equals ("Lumberjack_enemy")) {
			if(playerFire.GetComponent<ParticleSystem> ().isPlaying == true){
				//destroyEnemy (other.gameObject);
				Destroy(other.gameObject, 3);
			}
		}
		//Destroy(gameObject); // destroy the grenade
		//Destroy(hold, 3); // delete the explosion after 3 seconds
	}
}

