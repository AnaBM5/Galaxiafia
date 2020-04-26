using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;
using TMPro;

public class FBManager : MonoBehaviour {

	public TextMeshProUGUI Nombre;
	//public GameObject ProfilePicture;
	public Image ProfilePicture;

	void Awake ()
	{
		if (!FB.IsInitialized) {
			FB.Init(InitCallback, OnHideUnity);
		} else {
			FB.ActivateApp();
		}
	}

	private void InitCallback ()
	{
		if (FB.IsInitialized) {
			FB.ActivateApp ();
		} else {
		}

		if (FB.IsLoggedIn) {
			FB.API ("/me?fields=name", HttpMethod.GET, DispName);
			FB.API("me/picture?type=square&height=128&width=128", HttpMethod.GET, GetPicture);
		} else {
			Nombre.text = "Please login to continue.";
		}
	}

	private void OnHideUnity (bool isGameShown)
	{
		if (!isGameShown) {
			Time.timeScale = 0; //pause
		} else {
			Time.timeScale = 1; //resume
		}
	}
	


	void DispName(IResult result){
		if (result.Error != null) {
			Nombre.text = result.Error;
		} else {
			Nombre.text = "Hi there: " + result.ResultDictionary ["name"];
		}
	}

	private void GetPicture(IGraphResult result)
	{
		if (result.Error == null && result.Texture != null)
		{       
			//http://stackoverflow.com/questions/19756453/how-to-get-users-profile-picture-with-facebooks-unity-sdk
			/*if (result.Texture != null) {
				Image img = ProfilePicture.GetComponent<Image> ();
				img.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
			}*/
			ProfilePicture.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		}
	}
}
