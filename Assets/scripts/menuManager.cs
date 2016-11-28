using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour {

	public void play(){
		SceneManager.LoadScene ("game");
	}

	public void quit(){
	
	}
}
