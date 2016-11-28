using UnityEngine;
using System.Collections;

public class SaveLoad : MonoBehaviour {

	private GameObject _player;
	private PlayerLevel _playerLevel;
	//string fileName = "Toil";
	public GameObject saveObject;

	private string saveName = "SaveMe";

	private SaveData data;
	public Inventory myItems;

	void Start () {

		SaveObject.Initialize(saveObject);
		SaveObject.SetRefreshCallback(OnRefresh);
		SaveObject.Load(saveName);


		_player = GameObject.FindGameObjectWithTag ("Player");
		_playerLevel = _player.GetComponent<PlayerLevel> ();

		//loading
		_playerLevel.currentLevel = SaveObject.Get<SavedStats> ().level;
		_playerLevel.currentXP = SaveObject.Get<SavedStats> ().XP;

		myItems.ItemsInInventory.Clear();

		foreach (Item thing in SaveObject.Get<SavedStats> ().items) {
			myItems.addItemToInventory (thing.itemID);
		}




	}

	private void OnRefresh() {
		saveName = SaveObject.saveName;

	}

	void Update(){

		SaveObject.Get<SavedStats> ().level = _playerLevel.currentLevel;
		SaveObject.Get<SavedStats> ().XP = _playerLevel.currentXP;



	}
	
	void OnApplicationPause(){
		SaveObject.Get<SavedStats> ().items.Clear ();
		foreach (Item thing in myItems.ItemsInInventory) {
			SaveObject.Get<SavedStats> ().items.Add(thing);
		}
		SaveObject.Save();

	}
}

