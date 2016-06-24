using UnityEngine;
using System.Collections;

public class PlayerInfo  {

	public string name;
	public int level;
	public int exp;

	public PlayerInfo(){
	}

	public PlayerInfo(string newName){
		name = newName;
		level = 1;
		exp = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
