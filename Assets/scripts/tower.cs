using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tower : MonoBehaviour {

	public GameObject sell;
	public GameObject upgrade;
	public string type;
	public float damage;
	public float range;
	public float cost;
	public float fireRate;
	public GameObject bullet;
	private GameObject target = null;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("UpdateTarget", 0f, fireRate);
	}

	void UpdateTarget(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("enemy");
		float shortestDistance = Mathf.Infinity;
		for(int i = 0; i < enemies.Length; i++){
			if (Vector3.Distance (transform.position, enemies [i].transform.position) < shortestDistance) {
				shortestDistance = Vector3.Distance (transform.position, enemies [i].transform.position);
				target = enemies [i];
			} 
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
		b.GetComponent<Rigidbody2D> ().AddForce (dir.normalized * 1000f);
		b.tag = "bullet";
		b.GetComponent<bullet> ().damage = damage;
	}

	void OnMouseDown(){
		//upgrade and sell
//		GameObject s = (GameObject)Instantiate(sell, new Vector3(transform.position.x - 0.4f, transform.position.y + 0.4f, -0.4f), Quaternion.identity);
//		GameObject u = (GameObject)Instantiate(upgrade, transform.position, Quaternion.identity);
	}
//
//	void OnMouseExit(){
//		// destroy upgrade and sell
//	}
}
