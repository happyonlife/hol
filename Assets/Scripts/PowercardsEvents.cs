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

public class PowercardsEvents : MonoBehaviour {

//	public Image cardImage;
	public Image p1;
	public Image p2;
	public Image p3;
	public Image p4;

	private int currentCard = 1;

	//VAR 4 Textify
	private string[] strgs;

	public Image cardImg;
	public Button backBtn;
	public Text titleTxt;
	public Image iconImg;
	public Text titleCardTxt;
	public Text content1Txt;
	public Text content2Txt;
	public Text content3Txt;
	//

	// Use this for initialization
	void Start () {
		LangTxt();
		showCard();
//		clearPins ();
//		string suffix = PlayerPrefs.GetString ("linguaSuffix");
//		Sprite sprite  = null;
//		string textureFile = string.Concat ("Textures/green_", suffix);
//		sprite = Resources.Load<Sprite> (textureFile);
//		cardImage.sprite = sprite;
//		p1.sprite = Resources.Load<Sprite>("Textures/pieno");
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
		
		strg = strgs [3].Split ('=');
		titleTxt.text=strg[1];
	}

	// Ricarica la pagina principale
	public void loadMainLevel() {
		//Application.LoadLevel("MainMenu");
		SceneManager.LoadScene("MainMenu");
	}

	void clearPins() {
		p1.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p2.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p3.sprite = Resources.Load<Sprite>("Textures/vuoto");
		p4.sprite = Resources.Load<Sprite>("Textures/vuoto");
	}

	void showCard() 
	{
		clearPins ();
//		string suffix = PlayerPrefs.GetString ("linguaSuffix");
//		Sprite sprite  = null;
		//Textify
		TextAsset qAsset = null;
		string suffix = PlayerPrefs.GetString ("linguaSuffix");
		string fname = "Text/power_" + suffix;
//		print (fname);
		qAsset = (TextAsset)Resources.Load(fname);
		string testoIntero = qAsset.text;
		strgs = testoIntero.Split ("\r\n" [0]);
		string[] strg;

		switch(currentCard){
		case 1 : 
//			sprite = Resources.Load<Sprite>("Textures/green_" + suffix);
			cardImg.sprite = Resources.Load<Sprite>("Textures/green_bkg");
			iconImg.sprite = Resources.Load<Sprite>("Textures/inguardia_icon");
			strg = strgs [12].Split ('=');
			titleCardTxt.text = strg[1];
			strg = strgs [13].Split ('=');
			content1Txt.text = strg[1];
			strg = strgs [14].Split ('=');
			content2Txt.text = strg[1];
			strg = strgs [15].Split ('=');
			content3Txt.text = strg[1];
			break;
		case 2 : 
//			sprite = Resources.Load<Sprite>("Textures/blue_" + suffix);
			cardImg.sprite = Resources.Load<Sprite>("Textures/blue_bkg");
			iconImg.sprite = Resources.Load<Sprite>("Textures/giocasicuro_icon");
			strg = strgs [8].Split ('=');
			titleCardTxt.resizeTextForBestFit=false;
			titleCardTxt.text = strg[1];
			strg = strgs [9].Split ('=');
			content1Txt.resizeTextForBestFit=false;
			content1Txt.text = strg[1];
			strg = strgs [10].Split ('=');
			content2Txt.text = strg[1];
			strg = strgs [11].Split ('=');
			content3Txt.text = strg[1];
			break;
		case 3 : 
//			sprite = Resources.Load<Sprite>("Textures/orange_" + suffix);
			cardImg.sprite = Resources.Load<Sprite>("Textures/orange_bkg");
			iconImg.sprite = Resources.Load<Sprite>("Textures/cyberbullismo_icon");
			strg = strgs [4].Split ('=');
			if(suffix=="fr")
			{
				titleCardTxt.resizeTextForBestFit=true;
			}
			titleCardTxt.text = strg[1];
			strg = strgs [5].Split ('=');
			if(suffix == "it" || suffix == "nl")
			{
				content1Txt.resizeTextForBestFit=false;
			}
			else
			{
				content1Txt.resizeTextForBestFit=true;
			}
			content1Txt.text = strg[1];
			strg = strgs [6].Split ('=');
			content2Txt.text = strg[1];
			strg = strgs [7].Split ('=');
			content3Txt.text = strg[1];
			break;
		case 4 : 
//			sprite = Resources.Load<Sprite>("Textures/red_" + suffix);
			cardImg.sprite = Resources.Load<Sprite>("Textures/red_bkg");
			iconImg.sprite = Resources.Load<Sprite>("Textures/restaconnesso_icon");
			strg = strgs [0].Split ('=');
			titleCardTxt.resizeTextForBestFit=false;
			titleCardTxt.text = strg[1];
			strg = strgs [1].Split ('=');
			content1Txt.resizeTextForBestFit=false;
			content1Txt.text = strg[1];
			strg = strgs [2].Split ('=');
			content2Txt.text = strg[1];
			strg = strgs [3].Split ('=');
			content3Txt.text = strg[1];
			break;
		}
//		cardImage.sprite = sprite;
		switch (currentCard) {
			case 1:
				p1.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 2:
				p2.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 3:
				p3.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
			case 4:
				p4.sprite = Resources.Load<Sprite>("Textures/pieno");
				break;
		}
	}

	// Passa alla prossima powercard
    //Go to next card
	public void nextPowercard() {
		++currentCard;
		if(currentCard>4) {
			currentCard=1;
		} 
		showCard ();
	}

    // Passa alla powercard precedente
    //Go to previous card
    public void prevPowercard() {
		--currentCard;
		if(currentCard<1) {
			currentCard=4;
		} 
		showCard ();
	}
}
