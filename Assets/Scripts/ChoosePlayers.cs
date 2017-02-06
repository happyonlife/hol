/*
* Copyright 2016 European Commission
*
* Licensed under the EUPL, Version 1.1 or – as soon they
will be approved by the European Commission - subsequent
versions of the EUPL (the "Licence");
* You may not use this work except in compliance with the
Licence.
* You may obtain a copy of the Licence at:
*
* https://joinup.ec.europa.eu/software/page/eupl5
*
* Unless required by applicable law or agreed to in
writing, software distributed under the Licence is
distributed on an "AS IS" basis,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
express or implied.
* See the Licence for the specific language governing
permissions and limitations under the Licence.
*/ 

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChoosePlayers : MonoBehaviour {

	//VAR 4 Textify
	private string[] strgs;
	
	public Button oneBtn;
	public Button twoBtn;
	public Button backBtn;
	//

	void Start () 
	{
		LangTxt();
	}
	//Textify
	void LangTxt () 
	{
		TextAsset qAsset = null;
		string suffix = PlayerPrefs.GetString ("linguaSuffix");
		string fname = "Text/menu_" + suffix;
		qAsset = (TextAsset)Resources.Load(fname);
		string testoIntero = qAsset.text;
		strgs = testoIntero.Split ("\r\n" [0]);
		
		string[] strg = strgs [7].Split ('=');
		Text t1 = oneBtn.GetComponentInChildren<Text> ();
		t1.text = strg[1];
		
		strg = strgs [8].Split ('=');
		Text t2 = twoBtn.GetComponentInChildren<Text> ();
		t2.text=strg[1];
		
		strg = strgs [9].Split ('=');
		Text t3 = backBtn.GetComponentInChildren<Text> ();
		t3.text=strg[1];
	}

	/*
	 * The function chooseAvatar is connected to the One Player button
	 * When the user press the button the function writes into PlaerPrefs the numPlayers property equal to 1
	 * And the curAvatarPlayer to 1 (this is to tell the level that it actually is to choose the first player avatar
	 * The it loads the ChooseAvatar level.
	 * 
	 */
	public void chooseAvatar() 
	{
		PlayerPrefs.SetInt ("numplayers", 1);
		PlayerPrefs.SetInt ("curAvatarPlayer", 1);
		//Application.LoadLevel ("ChooseAvatar");
		SceneManager.LoadScene("ChooseAvatar");
	}

	/*
	 * The function chooseAvatar2 is connected to the Two Players button
	 * When the user press the button the function writes into PlaerPrefs the numPlayers property equal to 2
	 * And the curAvatarPlayer to 1 (this is to tell the level that it actually is to choose the first player avatar
	 * The it loads the ChooseAvatar level.
	 * 
	 */
	public void chooseAvatar2() 
	{
		PlayerPrefs.SetInt ("numplayers", 2);
		PlayerPrefs.SetInt ("curAvatarPlayer", 1);
		//Application.LoadLevel ("ChooseAvatar");
		SceneManager.LoadScene("ChooseAvatar");
	}

	/*
	 * The function load the MainMenu Level. It's connected to Back to Menu button.
	 * 
	 */
	public void backToMenu() 
	{
		//Application.LoadLevel ("MainMenu");
		SceneManager.LoadScene("MainMenu");
	}
}
