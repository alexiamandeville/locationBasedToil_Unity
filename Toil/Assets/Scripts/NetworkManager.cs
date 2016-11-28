using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string roomName = "room";
	private RoomInfo[] roomsList;

	public GameObject playerPrefab;

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings ("0.1");
	}
	
	// Update is called once per frame
	void Update () {

		if (!PhotonNetwork.connected) {
			print(PhotonNetwork.connectionStateDetailed.ToString());

		} else if (PhotonNetwork.room == null) {

			PhotonNetwork.CreateRoom (roomName);

			if(roomsList != null){
				PhotonNetwork.JoinRoom(roomName);
			}
		}
	}

	void OnReceivedRoomListUpdate()
	{
		roomsList = PhotonNetwork.GetRoomList();
	}
	void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate(playerPrefab.name, Vector3.up * 5, Quaternion.identity, 0);

	}
}
