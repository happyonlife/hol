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

public class DisclosureEvents : MonoBehaviour {

	public Text testoDisclaimer;
	public Image logoEC;

	//VAR 4 Textify
	private string[] strgs;
	
	public Text selectTxt;
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
		string[] strg = strgs [16].Split ('=');
		selectTxt.text = strg[1];
	}

	public void selectItalian() {
		PlayerPrefs.SetInt("lingua", 1);
		PlayerPrefs.SetString("linguaSuffix", "it");
		SceneManager.LoadScene("MainMenu");
	}

	public void selectEnglish() {
		PlayerPrefs.SetInt("lingua", 2);
		PlayerPrefs.SetString("linguaSuffix", "en");
		SceneManager.LoadScene("MainMenu");
	}

	public void selectFrench() {
		PlayerPrefs.SetInt("lingua", 3);
		PlayerPrefs.SetString("linguaSuffix", "fr");
		SceneManager.LoadScene("MainMenu");
	}
	
	public void selectDutch() {
		PlayerPrefs.SetInt("lingua", 4);
		PlayerPrefs.SetString("linguaSuffix", "nl");
		SceneManager.LoadScene("MainMenu");
	}

	public void selectSpain() {
		PlayerPrefs.SetInt("lingua", 5);
		PlayerPrefs.SetString("linguaSuffix", "sp");
		SceneManager.LoadScene("MainMenu");
	}

	public void selectRomanian() {
		PlayerPrefs.SetInt("lingua", 6);
		PlayerPrefs.SetString("linguaSuffix", "ro");
		SceneManager.LoadScene("MainMenu");
	}

    public void selectPortugal()
    {
        PlayerPrefs.SetInt("lingua", 7);
        PlayerPrefs.SetString("linguaSuffix", "pt");
        SceneManager.LoadScene("MainMenu");
    }
}
