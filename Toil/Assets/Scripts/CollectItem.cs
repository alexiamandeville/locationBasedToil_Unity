﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CollectItem : MonoBehaviour {

	public Item item;
	private Inventory _inventory;
	private GameObject _player;
	private PlayerInventory _myPlayerInfo;
	private List<int> indexList = new List<int>();

	static ItemDataBaseList inventoryItemList;

	//ui stuff
	public Text collectableName;
	public Text collectableDesc;
	public Image collectableImage;

	void Start()
	{
		//load my items
		inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");

		_player = GameObject.FindGameObjectWithTag("Player");

		if (_player != null) {
			_inventory = _player.GetComponent<PlayerInventory> ().inventory.GetComponent<Inventory> ();
			_myPlayerInfo = _player.GetComponent<PlayerInventory> ();
		}

		//check if the item equals the player's level
		foreach(Item singleItem in inventoryItemList.itemList){
			float itemToFloat = (sbyte)singleItem.itemType;
			if (itemToFloat <= _myPlayerInfo.currentLevel) {
				
				//if it does, add the index to a new list so we can choose from it later
				indexList.Add(inventoryItemList.itemList.IndexOf(singleItem));
			}
		}

		//create random number from our subset <= player's current level
		int randomNumber = Random.Range(0, indexList.Count + 1);

		//our random item is taken from our subset only
		item = inventoryItemList.itemList[indexList[randomNumber]];

		//ui stuff
		collectableName.text = inventoryItemList.itemList[randomNumber].itemName;
		collectableDesc.text = inventoryItemList.itemList[randomNumber].itemDesc;
		collectableImage.sprite = inventoryItemList.itemList[randomNumber].itemIcon;



	}


	public void collectButton(){
		/*bool check = _inventory.checkIfItemAllreadyExist(item.itemID, item.itemValue);
				if (check)
					Destroy(this.gameObject);
				else if (_inventory.ItemsInInventory.Count < (_inventory.width * _inventory.height))*/

		//add experience
		_myPlayerInfo.currentXP =+ 20;
		_myPlayerInfo.UpdateXP();

		_inventory.addItemToInventory(item.itemID, item.itemValue);
		_inventory.updateItemList();
		_inventory.stackableSettings();
	}
	}
