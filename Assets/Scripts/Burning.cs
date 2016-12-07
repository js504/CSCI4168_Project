using UnityEngine;
using System.Collections;

public class Burning : MonoBehaviour {


	bool onFire;

	// Use this for initialization
	void Start () {
		onFire = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetOnFire(bool onFire){
		this.onFire = onFire;

		StartCoroutine (Burn ());
	}

	public bool GetOnFire(){
		return onFire;
	}

	IEnumerator Burn(){
		

		print ("burning");

		yield return new WaitForSeconds (3f);

		Destroy (this.gameObject);

	}
}
