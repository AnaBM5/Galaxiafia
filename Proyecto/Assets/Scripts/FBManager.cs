using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class FBManager : MonoBehaviour {

	public TextMeshProUGUI Nombre;
	//public GameObject ProfilePicture;
	public Image ProfilePicture;

	private void Start()
	{
		Nombre.text = "Hola, " + PlayerPrefs.GetString("DisplayName");
	}

	void DispName(IResult result){
		if (result.Error != null) {
			Nombre.text = result.Error;
		} else {
			Nombre.text = "Hi there: " + result.ResultDictionary ["name"];
		}
	}

	
}
