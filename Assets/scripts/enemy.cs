using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemy : MonoBehaviour {

	public List<Vector3> markers;
	public int currentTarget = 1;
	public float speed;
	public float health;
	public int[] waveCash = new int[] {10, 20, 30};

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		markers = Camera.main.GetComponent<main> ().markers;
		Vector3 dir = markers [currentTarget] - markers [currentTarget - 1];
		moveEnemy (dir);
		if (health <= 0) {
			Destroy (this.gameObject);
			Camera.main.GetComponent<main> ().playerCash += waveCash[Camera.main.GetComponent<main>().currentWave];
		}
	}

	void moveEnemy(Vector3 dir){
		if (!(currentTarget < markers.Count - 1)) {
			Destroy (this.gameObject);
			Camera.main.GetComponent<main> ().playerHealth -= 1;
			return;
		}
		if (Vector3.Distance (transform.position, markers [currentTarget]) >= 0.15f) {
			transform.Translate ((dir.normalized * speed) * Time.deltaTime, Space.World);
		} else {
			currentTarget += 1;
		}
	}

	void OnCollisionEnter2D(Collision2D c){
		if(c.gameObject.tag == "bullet"){
			health -= c.gameObject.GetComponent<bullet> ().damage;
		}
	}

}
