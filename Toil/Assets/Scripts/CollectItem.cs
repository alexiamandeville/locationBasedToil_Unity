using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour {

	public Item item;
	private Inventory _inventory;
	private GameObject _player;
	static ItemDataBaseList inventoryItemList;

	//ui stuff
	public Text collectableName;

	void Start()
	{

		inventoryItemList = (ItemDataBaseList)Resources.Load("ItemDatabase");

		int randomNumber = Random.Range(1, inventoryItemList.itemList.Count - 1);

		_player = GameObject.FindGameObjectWithTag("Player");
		if (_player != null)
			_inventory = _player.GetComponent<PlayerInventory>().inventory.GetComponent<Inventory>();

		item = inventoryItemList.itemList[randomNumber];

		//ui stuff
		collectableName.text = inventoryItemList.itemList[randomNumber].itemName;

	}
	


	public void collectButton(){
		/*bool check = _inventory.checkIfItemAllreadyExist(item.itemID, item.itemValue);
				if (check)
					Destroy(this.gameObject);
				else if (_inventory.ItemsInInventory.Count < (_inventory.width * _inventory.height))*/

		_inventory.addItemToInventory(item.itemID, item.itemValue);
		_inventory.updateItemList();
		_inventory.stackableSettings();
	}
	}

