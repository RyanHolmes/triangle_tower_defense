using UnityEngine;

public class shop : MonoBehaviour {

	public void buyTower() {
		Camera.main.GetComponent<main> ().currentTower = "standard";
		Camera.main.GetComponent<main> ().bought = true;
	}

	public void buyTower2() {
		Camera.main.GetComponent<main> ().currentTower = "slow";
		Camera.main.GetComponent<main> ().bought = true;
	}

	public void buyTower3() {
		Camera.main.GetComponent<main> ().currentTower = "fast";
		Camera.main.GetComponent<main> ().bought = true;
	}

	public void nextWave(){
		Camera.main.GetComponent<main> ().nextWave ();
	}

}
