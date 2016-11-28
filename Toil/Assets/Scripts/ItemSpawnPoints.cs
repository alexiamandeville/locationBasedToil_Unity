using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSpawnPoints : MonoBehaviour {

	public GetPlayerLocation mylocation;
	static ItemDataBaseList inventoryItemList;
	public GoogleMap myMap;

	public GameObject itemPanel;
	public bool isItemFound;

	private float timestamp;



	private float _locationAway = 0.00100f;

	void Update(){


		if (timestamp < Time.time) {
			
		//if player gets close to marker lat,long then notify
		foreach (GoogleMapMarker marker in myMap.markers) {
			foreach (GoogleMapLocation location in marker.locations) {

													
					//if player is _locationAway away from item/marker
					if ((mylocation.myLat < location.latitude + _locationAway && mylocation.myLat > location.latitude - _locationAway) || (mylocation.myLong < location.longitude + _locationAway && mylocation.myLong > location.longitude - _locationAway)) {
						ItemFound ();

					}
				}

			}
		}

	}

	void ItemFound(){
		

		//cooldown in seconds
		timestamp = Time.time + 900;

		//turn on found item panel for collection
		itemPanel.SetActive (true);

		//send notification
		//LocalNotification.SendNotification(1, 0, "Item found!", "", new Color32(0xff, 0x44, 0x44, 255)); 

		//Handheld.Vibrate();
	}

}
	