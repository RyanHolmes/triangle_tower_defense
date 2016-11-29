using UnityEngine;
using System.Collections;

public class soundManager : MonoBehaviour {

	public AudioClip explode;
	public AudioClip scream;

	public void boom(){
		this.GetComponent<AudioSource> ().clip = explode;
		this.GetComponent<AudioSource> ().Play ();
	}

	public void screamer() {
		this.GetComponent<AudioSource> ().clip = scream;
		this.GetComponent<AudioSource> ().Play ();
	}

}
