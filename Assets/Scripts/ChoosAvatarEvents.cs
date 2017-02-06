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
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoosAvatarEvents : MonoBehaviour {

	public Text avatarScreen;

	public GameObject disk1;
	public GameObject disk2;
	public GameObject disk3;
	public GameObject disk4;
	public GameObject disk5;
	public GameObject disk6;
	
	public GameObject av1;
	public GameObject av2;
	public GameObject av3;
	public GameObject av4;
	public GameObject av5;
	public GameObject av6;

	public Text loading;
	public Image loadingBorder;

	//VAR 4 Textify
	private string[] strgs;
	
	public Button backBtn;
	public Button continueBtn;
	public Image loadingImg;
	//

	void Start () 
	{
		LangTxt();
		loading.enabled = false;
		loadingBorder.enabled = false;
		av1.SetActive(true);
		av2.SetActive(true);
		av3.SetActive(true);
		av4.SetActive(true);
		av5.SetActive(true);
		av6.SetActive(true);
		TextAsset qAsset = null;
		string suffix = PlayerPrefs.GetString ("linguaSuffix");
		string fname = "Text/phrases_" + suffix;
		//		print (fname);
		qAsset = (TextAsset)Resources.Load(fname);
		string testoIntero = qAsset.text;
		strgs = testoIntero.Split ("\r\n" [0]);
		string[] strg;
		strg = strgs [28].Split ('=');
		string plr = strg[1];
		int curPlayer = PlayerPrefs.GetInt ("curAvatarPlayer", 1);
		if (curPlayer == 1) 
		{
			avatarScreen.text = plr+" 1";
		} 
		else 
		{
			avatarScreen.text = plr+" 2";
			int p1 = PlayerPrefs.GetInt ("p1color", 1);
			switch(p1) {
			case 1:
				av1.SetActive (false);
				break;
			case 2:
				av2.SetActive (false);
				break;
			case 3:
				av3.SetActive (false);
				break;
			case 4:
				av4.SetActive (false);
				break;
			case 5:
				av5.SetActive (false);
				break;
			case 6:
				av6.SetActive (false);
				break;
			}
		}
		enableDisk (0);
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
		
		string[] strg = strgs [10].Split ('=');
		Text t1 = backBtn.GetComponentInChildren<Text> ();
		t1.text = strg[1];
		
		strg = strgs [11].Split ('=');
		Text t2 = continueBtn.GetComponentInChildren<Text> ();
		t2.text=strg[1];
		
		strg = strgs [12].Split ('=');
		Text t3 = loadingImg.GetComponentInChildren<Text> ();
		t3.text=strg[1];
	}

	// Funzione che riporta al menu principale
    //Back to main menu
	public void backToMenu() 
	{
		//Application.LoadLevel ("NumPlayers");
		SceneManager.LoadScene("NumPlayers");
	}

	// Funzione per il caricamento della scena del main game
    //Load scene
	public void beginGame() {
		int curPlayer = PlayerPrefs.GetInt ("curAvatarPlayer", 1);
		int numPlayers = PlayerPrefs.GetInt ("numplayers", 1);
		if (curPlayer == 1 && numPlayers == 2) 
		{
			PlayerPrefs.SetInt ("curAvatarPlayer",2);
			//Application.LoadLevel ("ChooseAvatar");
			SceneManager.LoadScene("ChooseAvatar");
		} else {
			int p1 = PlayerPrefs.GetInt ("p1color", 1);
			int p2 = PlayerPrefs.GetInt ("p2color", 2);
			if(p1==p2) {
				p2=p2+1;
				if(p2==7)
					p2=1;
				PlayerPrefs.SetInt ("p2color",p2);
			}

			loading.enabled = true;
			loadingBorder.enabled = true;
			//Application.LoadLevel ("PlayLevel");
			SceneManager.LoadScene("PlayLevel");
		}
	}

	// Attiva il disco selezionato deselezionando gli altri
    //This select an ufo and deselect the others
	public void enableDisk(int diskNum) {
		disk1.SetActive (false);
		disk2.SetActive (false);
		disk3.SetActive (false);
		disk4.SetActive (false);
		disk5.SetActive (false);
		disk6.SetActive (false);
		switch (diskNum) {
			case 1:
				disk1.SetActive(true);
				break;
			case 2:
				disk2.SetActive(true);
				break;
			case 3:
				disk3.SetActive(true);
				break;
			case 4:
				disk4.SetActive(true);
				break;
			case 5:
				disk5.SetActive(true);
				break;
			case 6:
				disk6.SetActive(true);
				break;
		}
	}
}
