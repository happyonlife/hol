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

public class MainMenuEvents : MonoBehaviour {
	//VAR 4 Textify
	private string[] strgs;

	public Button startBtn;
	public Button scoreBtn;
	public Button langBtn;
	public Button powerBtn;
	public Button extraBtn;
	public Button instruBtn;
	public Button aboutBtn;
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
		
		string[] strg = strgs [0].Split ('=');
		Text t1 = startBtn.GetComponentInChildren<Text> ();
		t1.text = strg[1];
		
		strg = strgs [1].Split ('=');
		Text t2 = scoreBtn.GetComponentInChildren<Text> ();
		t2.text=strg[1];
		
		strg = strgs [2].Split ('=');
		Text t3 = langBtn.GetComponentInChildren<Text> ();
		t3.text=strg[1];
		
		strg = strgs [3].Split ('=');
		Text t4 = powerBtn.GetComponentInChildren<Text> ();
		t4.text=strg[1];
		
		strg = strgs [4].Split ('=');
		Text t5 = extraBtn.GetComponentInChildren<Text> ();
		t5.text=strg[1];
		
		strg = strgs [5].Split ('=');
		Text t6 = instruBtn.GetComponentInChildren<Text> ();
		t6.text=strg[1];
		
		strg = strgs [6].Split ('=');
		Text t7 = aboutBtn.GetComponentInChildren<Text> ();
		t7.text=strg[1];
	}

	public void startSetup() {
		int versionType = PlayerPrefs.GetInt ("versionType", 0);
		if(versionType<=1)
		{
			//Application.LoadLevel("Disclaimer");
			SceneManager.LoadScene("Disclaimer");
		}/*
		else
		{
			//Application.LoadLevel("Disclaimer2");
			SceneManager.LoadScene("Disclaimer2");
		}*/
	}

	public void startInstructions() {
		//Application.LoadLevel("Instructions");
		SceneManager.LoadScene("Instructions");
	}

	// Funzione per il caricamento della scena del main game
	public void startGame() {
		//Application.LoadLevel ("NumPlayers");
		SceneManager.LoadScene("NumPlayers");
	}

	// Funzione per il caricamento della scena delle powercards
	public void startPowercards() {
		//Application.LoadLevel ("Powercards");
		SceneManager.LoadScene("Powercards");
	}

	// Funzione per il caricamento della scena del ventaglio
	public void startVentaglio() {
		//Application.LoadLevel ("Ventaglio");
		SceneManager.LoadScene("Ventaglio");
	}

	public void startClassifica() {
		//Application.LoadLevel ("Classifica");
		SceneManager.LoadScene("Classifica");
	}

	public void startAbout() {
		//Application.LoadLevel ("Credits");
		SceneManager.LoadScene("Credits");
	}
}
