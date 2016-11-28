using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoogleMap : MonoBehaviour
{
	public GetPlayerLocation mylocation;

	public Text latitudeLoc;
	public Text longitudeLoc;

	public enum MapType
	{
		RoadMap,
		Satellite,
		Terrain,
		Hybrid
	}
	public bool loadOnStart = true;
	public bool isLoaded;
	public bool autoLocateCenter = true;
	public GoogleMapLocation centerLocation;
	public int zoom = 13;
	public MapType mapType;
	public int size = 512;
	public bool doubleResolution = false;
	public GoogleMapMarker[] markers;
	public GoogleMapPath[] paths;
			
	void Start() {
		if(loadOnStart) Refresh();	
	}

	void Update(){
		latitudeLoc.text = mylocation.myLat.ToString ();
		longitudeLoc.text = mylocation.myLong.ToString ();

	}
	
	public void Refresh() {
		if(autoLocateCenter && (markers.Length == 0 && paths.Length == 0)) {
			Debug.LogError("Auto Center will only work if paths or markers are used.");	
		}

		StartCoroutine(_Refresh());

	}
		

	IEnumerator _Refresh ()
	{
		while (true) {
			var url = "http://maps.googleapis.com/maps/api/staticmap";
			var qs = "";
			if (!autoLocateCenter) {
				if (centerLocation.address != "")
					qs += "center=" + WWW.UnEscapeURL (centerLocation.address);
				else {
					//centerLocation.latitude = 28;
					//centerLocation.longitude = -81;
					qs += "center=" + WWW.UnEscapeURL (string.Format ("{0},{1}", mylocation.myLat, mylocation.myLong));
				}
		
				qs += "&zoom=" + zoom.ToString ();
			}
			qs += "&size=" + WWW.UnEscapeURL (string.Format ("{0}x{0}", size));
			qs += "&scale=" + (doubleResolution ? "2" : "1");
			qs += "&maptype=" + mapType.ToString ().ToLower ();

			//map styling ////
			//////////////////

			//set geometry style to map
			qs += "&style=feature:landscape" + "|" + "element:geometry.fill" + "|" + "color:0x23142b";
			//set label style to map
			qs += "&style=feature:all" + "|" + "element:labels" + "|" + "visibility:off";
			//set style to roads
			qs += "&style=feature:road" + "|" + "element:geometry" + "|" + "color:0x2a2849";
			//set style to points of interest
			qs += "&style=feature:poi" + "|" + "element:geometry" + "|" + "color:0x2a2849";

			//water
			qs += "&style=feature:water" + "|" + "element:geometry" + "|" + "color:0x293658";

			qs += "&style=feature:administrative" + "|" + "visibility:off";

			//////////

			var usingSensor = false;
#if UNITY_IPHONE
		usingSensor = Input.location.isEnabledByUser && Input.location.status == LocationServiceStatus.Running;
#endif
			qs += "&sensor=" + (usingSensor ? "true" : "false");
		
			//create markers
			foreach (var i in markers) {
				qs += "&markers=" + string.Format ("size:{0}|color:{1}|label:{2}", i.size.ToString ().ToLower (), i.color, i.label);
				foreach (var loc in i.locations) {
					if (loc.address != "")
						qs += "|" + WWW.UnEscapeURL (loc.address);
					else
						qs += "|" + WWW.UnEscapeURL (string.Format ("{0},{1}", loc.latitude, loc.longitude));
				}
			}
		
			//create paths
			foreach (var i in paths) {
				qs += "&path=" + string.Format ("weight:{0}|color:{1}", i.weight, i.color);
				if (i.fill)
					qs += "|fillcolor:" + i.fillColor;
				foreach (var loc in i.locations) {
					if (loc.address != "")
						qs += "|" + WWW.UnEscapeURL (loc.address);
					else
						qs += "|" + WWW.UnEscapeURL (string.Format ("{0},{1}", loc.latitude, loc.longitude));
				}
			}
				
			var req = new WWW (url + "?" + qs);
			yield return req;
			GetComponent<Renderer> ().material.mainTexture = req.texture;
			yield return new WaitForSeconds (15f);
			isLoaded = true;
		}
	}
	
	
}

public enum GoogleMapColor
{
	black,
	brown,
	green,
	purple,
	yellow,
	blue,
	gray,
	orange,
	red,
	white
}

[System.Serializable]
public class GoogleMapLocation
{
	public string address;
	public float latitude;
	public float longitude;
}

[System.Serializable]
public class GoogleMapMarker
{
	public enum GoogleMapMarkerSize
	{
		Tiny,
		Small,
		Mid
	}
	public GoogleMapMarkerSize size;
	public GoogleMapColor color;
	public string label;
	public GoogleMapLocation[] locations;
	
}

[System.Serializable]
public class GoogleMapPath
{
	public int weight = 5;
	public GoogleMapColor color;
	public bool fill = false;
	public GoogleMapColor fillColor;
	public GoogleMapLocation[] locations;	
}
	