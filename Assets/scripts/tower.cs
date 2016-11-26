using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class tower : MonoBehaviour {

	public GameObject range_prefab;
	public GameObject r;

	public string type;
	public int level;
	public float damage;
	public float range;
	public float cost;
	public float value;
	public float fireRate;
	public GameObject bullet;
	private GameObject target = null;

	// Use this for initialization
	void Start () {
		level = 1;
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
		b.GetComponent<Rigidbody2D> ().AddForce (dir.normalized * 2000f);
		b.tag = "bullet";
		b.GetComponent<bullet> ().damage = damage;
	}

	void OnMouseDown(){
		//upgrade and sell or cancel
		GameObject[] ranges = GameObject.FindGameObjectsWithTag("range");
		if (ranges.Length > 0) {
			foreach(GameObject ra in ranges){
				Destroy(ra.gameObject);
			}
		}
		r = (GameObject)Instantiate (range_prefab, new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
		r.transform.localScale = new Vector3(range, range, 0);
		r.tag = "range";

		GameObject s = GameObject.FindGameObjectWithTag("sell");
		s.transform.position = new Vector3 (transform.position.x, transform.position.y + 0.4f, 0);
		s.gameObject.GetComponent<sell> ().tower = this.gameObject;

		GameObject u = GameObject.FindGameObjectWithTag("upgrade");
		u.transform.position = new Vector3 (transform.position.x + 0.9f, transform.position.y + 0.4f, 0);
		u.gameObject.GetComponent<upgrade> ().tower = this.gameObject;

		GameObject c = GameObject.FindGameObjectWithTag("cancel");
		c.transform.position = new Vector3(transform.position.x - 0.9f, transform.position.y + 0.36f, 0);
		c.gameObject.GetComponent<cancel> ().tower = this.gameObject;
	}

	void OnMouseOver(){
		transform.localScale = new Vector3 (1.05f, 1.05f, 1.05f);
	}

	void OnMouseExit(){
		transform.localScale = new Vector3 (1f, 1f, 1f);
	}

	public void upgrade(){
		//TODO check upgrade is available
		level += 1;
		Dictionary<string, float[]> upgrades = Camera.main.GetComponent<main> ().upgrades;
		//cost, range, damage, speed, value
		range = upgrades[type + level.ToString()][1];
		damage = upgrades[type + level.ToString()][2];
		fireRate = upgrades[type + level.ToString()][3];
		value = upgrades[type + level.ToString()][4];
	}
}
