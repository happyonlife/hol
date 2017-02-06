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

public class VentaglioEvents : MonoBehaviour {

	public Text counter;
	public Image cardImage;
	public Image p01;
	public Image p02;
	public Image p03;
	public Image p04;
	public Image p05;
	public Image p06;
	public Image p07;
	public Image p08;
	public Image p09;
	public Image p10;
	public Image p11;
	public Image p12;
	public Image p13;
	public Image p14;

	private int currentCard = 1;

	//VAR 4 Textify
	private string[] strgs;
	
	public Button backBtn;
	public Text titleTxt;
	public Text title1Txt;
	public Text title2Txt;
	public Image iconImg;
	public Text content1Txt;
	public Text content2Txt;
	//

	// Use this for initialization
	void Start () {
		LangTxt();
		showCards();
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
		
		strg = strgs [4].Split ('=');
		titleTxt.text=strg[1];
	}

	public void batckToMain() {
		//Application.LoadLevel("MainMenu");
		SceneManager.LoadScene("MainMenu");
	}

	private void clearPins() {
		p01.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p02.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p03.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p04.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p05.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p06.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p07.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p08.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p09.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p10.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p11.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p12.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p13.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p14.sprite = Resources.Load<Sprite>("Textures/vuoto");
	}

	void showCards() {
		clearPins ();
		TextAsset qAsset = null;
		string suffix = PlayerPrefs.GetString ("linguaSuffix");
		string fname = "Text/extracards_" + suffix;
		//		print (fname);
		qAsset = (TextAsset)Resources.Load(fname);
		string testoIntero = qAsset.text;
		strgs = testoIntero.Split ("\r\n" [0]);
		string[] strg;

		switch (currentCard) {
		case 1: 
//			sprite = Resources.Load<Sprite> ("Textures/01_" + suffix);
			iconImg.enabled=false;
			title2Txt.enabled=false;
			content2Txt.enabled=false;
			title1Txt.enabled=true;
			content1Txt.enabled=true;
			strg = strgs [0].Split ('=');
			title1Txt.text = strg[1];
			strg = strgs [1].Split ('=');
			content1Txt.text = strg[1];
			break;
		case 2: 
//			sprite = Resources.Load<Sprite> ("Textures/02_" + suffix);
			iconImg.enabled=true;
			title1Txt.enabled=false;
			content1Txt.enabled=false;
			title2Txt.enabled=true;
			content2Txt.enabled=true;
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon02");
			strg = strgs [2].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [3].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 3: 
//			sprite = Resources.Load<Sprite> ("Textures/03_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon03");
			strg = strgs [4].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [5].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 4: 
//			sprite = Resources.Load<Sprite> ("Textures/04_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon04");
			strg = strgs [6].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [7].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 5: 
//			sprite = Resources.Load<Sprite> ("Textures/05_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon05");
			strg = strgs [8].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [9].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 6: 
//			sprite = Resources.Load<Sprite> ("Textures/06_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon06");
			strg = strgs [10].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [11].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 7: 
//			sprite = Resources.Load<Sprite> ("Textures/07_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon07");
			strg = strgs [12].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [13].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 8: 
//			sprite = Resources.Load<Sprite> ("Textures/08_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon08");
			strg = strgs [14].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [15].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 9: 
//			sprite = Resources.Load<Sprite> ("Textures/09_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon09");
			strg = strgs [16].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [17].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 10: 
//			sprite = Resources.Load<Sprite> ("Textures/10_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon10");
			strg = strgs [18].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [19].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 11: 
//			sprite = Resources.Load<Sprite> ("Textures/11_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon11");
			strg = strgs [20].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [21].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 12: 
//			sprite = Resources.Load<Sprite> ("Textures/12_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon12");
			strg = strgs [22].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [23].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 13: 
//			sprite = Resources.Load<Sprite> ("Textures/13_" + suffix);
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon13");
			strg = strgs [24].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [25].Split ('=');
			content2Txt.text = strg[1];
			break;
		case 14: 
//			sprite = Resources.Load<Sprite> ("Textures/14_" + suffix);
			iconImg.enabled=true;
			title1Txt.enabled=false;
			content1Txt.enabled=false;
			title2Txt.enabled=true;
			content2Txt.enabled=true;
			iconImg.sprite = Resources.Load<Sprite>("Textures/ea_icon14");
			strg = strgs [26].Split ('=');
			title2Txt.text = strg[1];
			strg = strgs [27].Split ('=');
			content2Txt.text = strg[1];
			break;
		}
//		cardImage.sprite = sprite;
		switch (currentCard) {
			case 1 :
				p01.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 2 :
				p02.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 3 :
				p03.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 4 :
				p04.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 5 :
				p05.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 6 :
				p06.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 7 :
				p07.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 8 :
				p08.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 9 :
				p09.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 10 :
				p10.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 11 :
				p11.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 12 :
				p12.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 13 :
				p13.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 14 :
				p14.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
		}
	}

    // Passa alla prossima powercard
    //Go to next powercard
    public void nextVentaglio() {
		++currentCard;
		if(currentCard>14) {
			currentCard = 1;
		}
		showCards ();
	}

    // Passa alla powercard precedente
    //Go to previous powercard
    public void prevVentaglio() {
		--currentCard;
		if(currentCard<1) {
			currentCard = 14;
		}
		showCards ();
	}
}
