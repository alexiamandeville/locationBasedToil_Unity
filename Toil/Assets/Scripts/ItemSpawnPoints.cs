using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemSpawnPoints : MonoBehaviour {

	public GetPlayerLocation mylocation;
	public Spawner[] spawnPoints;
	public Item itemList;
	public GoogleMap myMap;

	public GameObject itemPanel;
	public Text itemFound;


	private float _locationAway = 0.00100f;

	void Start(){
		//itemList = (ItemDataBaseList)Resources.Load("ItemDatabase");

	}

	void Update(){
		
		//if player gets close to marker lat,long then notify
		foreach (GoogleMapMarker marker in myMap.markers) {
			foreach (GoogleMapLocation location in marker.locations) {

				//if player is _locationAway away from item/marker
				if ((mylocation.myLat < location.latitude + _locationAway && mylocation.myLat > location.latitude - _locationAway) || (mylocation.myLong < location.longitude + _locationAway && mylocation.myLong > location.longitude - _locationAway)) {
					//itemPanel.SetActive (true);
					itemFound.text = "Item Found!";
				}

			}
		}

				//if player is in vici);nty of marker, then pop up item
	}
}

//i dont need this because the level will be on the items
[System.Serializable]
public class Spawner
{
	public SpawnLevel level;
}

//i dont need this because the level will be on the items
public enum SpawnLevel
{
	One = 1,
	Two = 2,
	Three = 3,
	Four = 4,
	Five = 5
}


