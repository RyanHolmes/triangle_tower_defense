using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

	public float damage;
//	public AudioClip slow_laser;

	void Start(){
//		AudioSource audio = this.GetComponent<AudioSource> ();
//		audio.clip = slow_laser;
//		audio.Play ();
	}

	void OnCollisionEnter2D(Collision2D c){
		Destroy(this.gameObject);
	}
}
