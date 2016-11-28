using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Survey : MonoBehaviour {

	private GameObject _player;
	private PlayerLevel _myPlayerInfo;
	public string[] questions;
	public string[] answers;

	public Text surveyQ1;


	// Use this for initialization
	void Awake () {
		gameObject.SetActive(false);
		_player = GameObject.FindGameObjectWithTag("Player");
	}

	void Start(){
		_myPlayerInfo = _player.GetComponent<PlayerLevel> ();

		switch((int)_myPlayerInfo.currentLevel){
		case 2:
			surveyQ1.text = "Level 2";
			break;
		case 4:
			surveyQ1.text = "Level 4";
			break;
		case 6:
			surveyQ1.text = "Level 6";
			break;
		case 8:
			surveyQ1.text = "Level 8";
			break;
		case 10:
			surveyQ1.text = "Level 10";
			break;
		default:
			break;
		}
	}

}
