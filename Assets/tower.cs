using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tower : MonoBehaviour {

	public float range;
	public float findRate = 1f;
	public float currentTime = 0;

	// Use this for initialization
	void Start () {
		range = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		if((Time.time - currentTime) >= findRate){
			UpdateTarget ();
			currentTime = Time.time;
		}
	}

	void UpdateTarget(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemy");
		for(int i = 0; i < enemies.Length; i++){
			if(Vector3.Distance(transform.position, enemies[i].transform.position) <= range){
				Debug.Log ("shoot");
			}
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = new Color (1, 1, 1, 0.25f);
		Gizmos.DrawSphere (transform.position, range);
	}
}
