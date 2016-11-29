using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemy : MonoBehaviour {

	public List<Vector3> markers;
	public int currentTarget;
	public float speed;
	public float health;
	public int[] waveCash;
	public bool isBoss;
	public GameObject healthBar;
	public GameObject hb;
	public GameObject anim;

	public GameObject slow;
	public GameObject std;
	public GameObject fast;

	// Use this for initialization
	void Start () {
//		currentTarget = 1;
		hb = (GameObject)Instantiate (healthBar, new Vector3 (transform.position.x, transform.position.y - 0.55f, 0), Quaternion.identity);
		hb.transform.parent = this.transform;
		waveCash = new int[]{ 3, 4, 4, 5, 5, 6, 8, 9, 10, 100 };
		markers = Camera.main.GetComponent<main> ().markers;
		if (this.gameObject.name == "boss") {
			isBoss = true;
		} else {
			isBoss = false;		
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = markers [currentTarget] - markers [currentTarget - 1];
		moveEnemy (dir);
		if (health <= 0) {
			Destroy (this.gameObject);
			Camera.main.GetComponent<main> ().playerCash += waveCash[Camera.main.GetComponent<main>().currentWave];
			Instantiate (anim, new Vector3(transform.position.x, transform.position.y + 7.5f, 0f), Quaternion.identity);
			if(isBoss){
				anim.transform.localScale = new Vector3 (1.5f, 1.5f, 0f);
				Instantiate (anim, new Vector3(transform.position.x, transform.position.y + 7.5f, 0f), Quaternion.identity);
				deathSpawn ();
			}
		}
	}

	void moveEnemy(Vector3 dir){
		if (!(currentTarget < markers.Count - 1)) {
			Destroy (this.gameObject);
			if (isBoss) {
				Camera.main.GetComponent<main> ().playerHealth -= 4;
				return;
			} else {
				Camera.main.GetComponent<main> ().playerHealth -= 1;
				return;
			}
		}
		if (Vector3.Distance (transform.position, markers [currentTarget]) >= 0.2f) {
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

	void deathSpawn () {
		//TODO: spawn enemies after death using boss' currenTarget
		GameObject stand = (GameObject)Instantiate(std, transform.position, Quaternion.identity);
		stand.GetComponent<enemy> ().currentTarget = this.currentTarget;
		stand.GetComponent<enemy>().health = 350;
		stand.GetComponent<enemy>().speed = 2f;

		GameObject f = (GameObject)Instantiate(fast, transform.position, Quaternion.identity);
		f.GetComponent<enemy> ().currentTarget = this.currentTarget;
		f.GetComponent<enemy>().health = 250;
		f.GetComponent<enemy>().speed = 4f;

		GameObject sl = (GameObject)Instantiate(slow, transform.position, Quaternion.identity);
		sl.GetComponent<enemy> ().currentTarget = this.currentTarget;
		sl.GetComponent<enemy>().health = 900;
		sl.GetComponent<enemy>().speed = 1f;
	}

}
