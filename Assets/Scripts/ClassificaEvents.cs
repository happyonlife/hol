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

public class ClassificaEvents : MonoBehaviour {

	public Text score1;
	public Text score2;
	public Text score3;
	public Text score4;
	public Text score5;

	public Text name1;
	public Text name2;
	public Text name3;
	public Text name4;
	public Text name5;

	//VAR 4 Textify
	private string[] strgs;
	
	public Button backBtn;
	public Text scoreTitleTxt;
	public Text scoreTxt;
	public Text nameTxt;

	public void backToMain() {
		//Application.LoadLevel("MainMenu");
		SceneManager.LoadScene("MainMenu");
	}

	// Use this for initialization
	void Start () 
	{
		LangTxt();
		int s1 = PlayerPrefs.GetInt ("sc1", 0);
		int s2 = PlayerPrefs.GetInt ("sc2", 0);
		int s3 = PlayerPrefs.GetInt ("sc3", 0);
		int s4 = PlayerPrefs.GetInt ("sc4", 0);
		int s5 = PlayerPrefs.GetInt ("sc5", 0);
		string n1 = PlayerPrefs.GetString ("nam1", "Anon");
		string n2 = PlayerPrefs.GetString ("nam2", "Anon");
		string n3 = PlayerPrefs.GetString ("nam3", "Anon");
		string n4 = PlayerPrefs.GetString ("nam4", "Anon");
		string n5 = PlayerPrefs.GetString ("nam5", "Anon");
		score1.text = s1.ToString ("#,000");
		score2.text = s2.ToString ("#,000");
		score3.text = s3.ToString ("#,000");
		score4.text = s4.ToString ("#,000");
		score5.text = s5.ToString ("#,000");
		name1.text = n1;
		name2.text = n2;
		name3.text = n3;
		name4.text = n4;
		name5.text = n5;
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
		
		string[] strg = strgs [13].Split ('=');
		Text t1 = backBtn.GetComponentInChildren<Text> ();
		t1.text = strg[1];
		
		strg = strgs [1].Split ('=');
		scoreTitleTxt.text=strg[1];
		
		strg = strgs [14].Split ('=');
		scoreTxt.text=strg[1];
		
		strg = strgs [15].Split ('=');
		nameTxt.text=strg[1];
	}
}
