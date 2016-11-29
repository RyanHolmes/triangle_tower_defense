using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {

	public float currentTime;

	// Use this for initialization
	void Start () {
		currentTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - currentTime >= 1){
			Destroy (this.gameObject);
		}
	}
}
