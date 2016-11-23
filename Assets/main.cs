using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class main : MonoBehaviour {

	public GameObject start;
	public GameObject e;
	public GameObject enemy;
	public int currentWave;
	public int currentEnemy;

	// Use this for initialization
	void Start () {
		e = (GameObject)Instantiate (enemy, start.transform.position, Quaternion.identity);
		e.name = "enemy";
		e.tag = "enemy";
	}
	
	// Update is called once per frame
	void Update () { 
	}
}
