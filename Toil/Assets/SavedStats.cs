using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]

public class SavedStats : MonoBehaviour {


	public float XP;
	public float level;
	[SerializeField]
	public List<Item> items = new List<Item>();


	void Start(){

	}

	void Update () {


	}
}
