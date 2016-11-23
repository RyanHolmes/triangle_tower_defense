﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tower : MonoBehaviour {

	public float range;
	public float cost;
	public float findRate = 1f;
	public GameObject bullet;
	private GameObject target = null;

	// Use this for initialization
	void Start () {
		range = 3f;
		InvokeRepeating ("UpdateTarget", 0f, findRate);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void UpdateTarget(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemy");
		float shortestDistance = Mathf.Infinity;
		for(int i = 0; i < enemies.Length; i++){
			if (Vector3.Distance (transform.position, enemies [i].transform.position) < shortestDistance) {
				shortestDistance = Vector3.Distance (transform.position, enemies [i].transform.position);
				target = enemies [i];
			} 
//			else {
//				target = null;
//			}
		}
		if(target != null && Vector3.Distance(transform.position, target.transform.position) < range){
			shoot (target);
		}
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = new Color (1, 1, 1, 0.25f);
		Gizmos.DrawSphere (transform.position, range);
	}

	void shoot(GameObject t){
		GameObject b = (GameObject)Instantiate(bullet, transform.position, Quaternion.identity);
		Vector3 dir = t.transform.position - transform.position;
		b.GetComponent<Rigidbody> ().AddForce (dir * 1000f);
	}
}
