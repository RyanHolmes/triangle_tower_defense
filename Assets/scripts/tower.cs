using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class tower : MonoBehaviour {

	public GameObject range_prefab;
	public GameObject r;
	public GameObject lvl2;
	public GameObject lvl3;
	public GameObject b2;
	public GameObject b3;

	public Text costUI;
	public Text rangeUI;
	public Text damageUI;
	public Text frUI;

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
		costUI = GameObject.FindGameObjectWithTag ("cost").GetComponent<Text>();
		rangeUI = GameObject.FindGameObjectWithTag ("rangeui").GetComponent<Text>();
		damageUI = GameObject.FindGameObjectWithTag ("damage").GetComponent<Text>();
		frUI = GameObject.FindGameObjectWithTag ("fireRate").GetComponent<Text>();
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
//		costUI = cost;
		rangeUI.text = "Range: " + range.ToString();
		damageUI.text = "Damage: " + damage.ToString ();
		frUI.text = "Fire Rate: " + fireRate.ToString();
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
		if (level == 2){
			b2 = (GameObject)Instantiate (lvl2, new Vector3(transform.position.x - 0.15f, transform.position.y + 0.15f, 0), Quaternion.identity);
		} else {
			Destroy (b2.gameObject);
			b3 = (GameObject)Instantiate (lvl3, new Vector3(transform.position.x - 0.15f, transform.position.y + 0.15f, 0), Quaternion.identity);
		}
	}
}
