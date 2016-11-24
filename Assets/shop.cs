using UnityEngine;

public class shop : MonoBehaviour {

	public void buyTower() {
		Camera.main.GetComponent<main> ().currentTower = "standard";
		Camera.main.GetComponent<main> ().bought = true;
	}

}
