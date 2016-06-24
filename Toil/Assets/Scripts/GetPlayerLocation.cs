using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GetPlayerLocation : MonoBehaviour {

	public Text latitudeLoc;
	public Text longitudeLoc;
	public ItemDataBaseList myItems;

	public float myLat;
	public float myLong;

	void Start(){
		StartCoroutine ("StartLoc");
	}

	//update player location 
	void Update(){
		// Access granted and location value could be retrieved
		//print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
		//latitudeLoc.text = Input.location.lastData.latitude.ToString();
		//longitudeLoc.text = Input.location.lastData.longitude.ToString();

		//update my current location
		myLat = Input.location.lastData.latitude;
		myLong = Input.location.lastData.longitude;

	}

	//finds player location
	IEnumerator StartLoc()
		{
			// First, check if user has location service enabled
			if (!Input.location.isEnabledByUser)
				yield break;

			// Start service before querying location
			Input.location.Start(0.1f,0.1f);

			// Wait until service initializes
			int maxWait = 20;
			while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
			{
				yield return new WaitForSeconds(1);
				maxWait--;
			}

			// Service didn't initialize in 20 seconds
			if (maxWait < 1)
			{
				print("Timed out");
				yield break;
			}

			// Connection has failed
			if (Input.location.status == LocationServiceStatus.Failed)
			{
				print("Unable to determine device location");
				yield break;
			}
					

			// Stop service if there is no need to query location updates continuously
			//Input.location.Stop();
		}


	}

	
