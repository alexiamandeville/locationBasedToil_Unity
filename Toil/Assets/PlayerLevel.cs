using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[System.Serializable]

public class PlayerLevel : MonoBehaviour {

	public float currentLevel = 1;
	private float lastLevel = 0;
	public float currentXP = 1;

	public float maxLevel = 10;
	public float maxXP = 1000;

	Text hpText;
	Text manaText;
	Image hpImage;
	Image manaImage;
	public Text levelText;
	public Scrollbar expBar;

	public GameObject survey;

	// Use this for initialization
	void Start () {

		UpdateXP();
	}

	void Update(){
		//if player is even level, and is greater level than before, then show my survey
		if(currentLevel > lastLevel){
			if(currentLevel % 2 == 0){
				survey.SetActive(true);
				lastLevel = currentLevel;
			}
		}
	}
	
	public void UpdateLevel()
	{
		if (currentLevel <= 10) {	
			if (currentXP >= Mathf.Pow (currentLevel, 3) + 7)
				currentLevel++;
		}

		levelText.text = "Level " + currentLevel;
	}

	public void UpdateXP()
	{
		expBar.size = currentXP / 100f;
	}

}
