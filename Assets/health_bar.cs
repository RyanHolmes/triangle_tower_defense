using UnityEngine;
using System.Collections;

public class health_bar : MonoBehaviour {

	public float startHealth;

	void Start(){
		startHealth = transform.parent.GetComponent<enemy> ().health;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.parent.GetComponent<enemy> ().health <= 0) {
			Destroy (this.gameObject);
			return;
		}
		transform.localScale = new Vector3 ((0.35f * (transform.parent.GetComponent<enemy> ().health/startHealth)), 0.35f, 0);
	}
}
