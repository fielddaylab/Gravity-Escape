﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIControl : MonoBehaviour {
	[HideInInspector]public Text timerText;
	[HideInInspector]public Text fuelText;
	[HideInInspector]public GameObject timerPanel;
	[HideInInspector]public GameObject levelSelect;
	[HideInInspector]public GameObject gameStats;
	[HideInInspector]public Text fuelTextInGameStats;
	[HideInInspector]public Text distanceText;
	//after finishing current level
	public void ShowGameStats(){
		gameStats.SetActive(true);
		fuelTextInGameStats.text = (1000f-GameControl.rocket.fuel).ToString("0");
		distanceText.text = GameControl.self.totalDistance.ToString("0.0");
	}
	public void UpdateFuel(float fuelLeft){
		if(fuelText != null)
		fuelText.text = fuelLeft.ToString("0");
	}
	public void UpdateTimer(float timeLeft){
		if(timerText != null)
		timerText.text = timeLeft.ToString("0");
	}
	public void HideTimerPanel(){

		timerPanel.SetActive(false);
	}
	public void Init(){
		timerPanel.SetActive(true);
	}
	void Awake(){
		GameControl.uiControl = this;
	}
	// Use this for initialization
	void Start () {
		GameObject timerObj = GameObject.Find("TimerText");
		if(timerObj == null){
			Debug.Log("no timer text named 'TimerText'!");
			Application.Quit();
		}
		GameObject fuelObj = GameObject.Find("FuelText");
		if(fuelObj == null){
			Debug.Log("no fuel named 'FuelText'!");
			Application.Quit();
		}
		timerPanel = GameObject.Find("TimerPanel");
		if(timerPanel == null){
			Debug.Log("no timer panel named 'TimerPanel'!");
			Application.Quit();
		}
		GameObject fuelTextInStat = GameObject.Find("Fuel Value");
		if(fuelTextInStat == null){
			Debug.Log("no fuel text in stat ");
			Application.Quit();
		}
		GameObject distanceObj = GameObject.Find("Distance Value");
		if(distanceObj != null){
			fuelTextInGameStats = fuelTextInStat.GetComponent<Text>();
		}
		
		timerText = timerObj.GetComponent<Text>();
		fuelText = fuelObj.GetComponent<Text>();
		distanceText = distanceObj.GetComponent<Text>();
		Init();
		

		levelSelect = GameObject.Find("Level Select");
		if(levelSelect != null){
			levelSelect.SetActive(false);
		}
		gameStats = GameObject.Find("Game Stats");
		if(gameStats != null){
			gameStats.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
