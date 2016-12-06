using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour {

	public string levelName = "Level2";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {

		
			//SceneManager.LoadScene ("Level2", LoadSceneMode.Single);
			//SceneManager.MoveGameObjectToScene (other.gameObject, newLevel);
		}
	}
}
