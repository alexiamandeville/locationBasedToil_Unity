using UnityEngine;
using System.Collections;

public class LoadScreen : MonoBehaviour {

	public GoogleMap myMap;

	// Update is called once per frame
	void Update () {
		if (myMap.isLoaded)
			StartCoroutine ("waiting");
	}

	IEnumerator waiting(){
		yield return new WaitForSeconds(4);
		gameObject.SetActive(false);

	}
}
