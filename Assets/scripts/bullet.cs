using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public float damage;

	void OnCollisionEnter2D(Collision2D c){
		Destroy(this.gameObject);
	}
}
