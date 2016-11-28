using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {

	public GoogleMap myMap;


	void Update () {
		if(myMap.isLoaded) gameObject.SetActive(true);
	}
}
