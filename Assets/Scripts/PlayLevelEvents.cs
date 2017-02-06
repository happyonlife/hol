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
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayLevelEvents : MonoBehaviour {
	
	public Button btnDice;
	public Image dice;
	public GenericUtils gu;
	public CameraRotationCustom crc;
	
	public GameObject avatar1;
	public GameObject avatar2;

	public Text  playerText;
	public Image playerDisk;
	public Text  scoreText;
	public Text  score;
	public Text  numAV;
	
	public AudioSource music;
	public Image       audioSymbol;
	
	public Image       avCard;
	public Image 	   virusCard;
	public Image 	   luckyCard;
	public Image 	   probCard;
	public Image 	   cartaRisposta;
	public Image	   homeCard;

	public Text confirmTxt;
	public Button exitBtn;
	public Button resumeBtn;
	
	public Camera      mc;
	public Camera      ac1;
	public Camera      ac2;
	
	public Canvas	   mainCanvas;
	
	public int		   firstAttemptPoints = 1000;
	public int		   secondAttemptPoints = 500;
	public int		   finishAttemptPoints = 1500;
	
	// Question Card elements
	public Image hex1;
	public Image hex2;
	public Image hex3;
	public Image hex4;
	public Image card;
	public Image symbol;
	public Text textQuestion;
	public Button ans1;
	public Button ans2;
	public Button ans3;
	public Button ans4;
	public Button okButton;
	public Image  discoCard;
	public Text   currPlayerText;
	public Image zoom;
	public Button zoomBtn;
	
	public Text txt1Prob;
	public Text txt2Prob;
	
	// Cameras of the PlayLevel scene
	public Button camera1;
	public Button camera2;
	public Button camera3;
	
	// Finish card
	public Image finishCard;
	public Text titoloFinish;
	public Text testoFinish;
	public Button okBtnFinish;
	
	// Winner card
	public Image winnerCard;
	public Image logo;
	public Image cup;
	public Text  congText;
	public Text  playerWinText;
	public Text  scorePWinText;
	public Text  p1Text;
	public Text  scoreP1Text;
	public Text  p2Text;
	public Text  scoreP2Text;
	public Text  p3Text;
	public Text  scoreP3Text;
	public Button okButtonWin;
	public Image  okBtnWinImage;
	public ParticleSystem fireworks;
	
	// Score card
	public Image scoreCard;
	public Button confirm;
	public Image  confimImage;
	public Image logoScore;
	public Text   textScore;
	public Text   textPoints;
	public Text   tynText;
	public InputField ifName;
	public Image     ifLimits;
	public Text      ifphText;
	public Text      ifText;
	public Text 	 disclaimerText;
	
	// Power card old
	public Image       powerCard;
	public Image       btnImage;
	public Button      closePC;
	public Image	   bordoPC;

	//Power card new(VAR 4 Textify)
	private string[] strgs;
	
	public Image cardImg;
	public Image iconImg;
	public Image lineaImg;
	public Text titleCardTxt;
	public Text content1Txt;
	public Text content2Txt;
	public Text content3Txt;
	public Image flash1Img;
	public Image flash2Img;
	public Image flash3Img;
	//
	
	// Power card vinta
	public Image       winPowercard;
	public Image	   imgOkWinPC;
	public Button	   btnOkWinPC;
	public Text		   txt1WPC;
	public Text		   txt2WPC;
	public Text		   txt3WPC;
	public Text		   txt4WPC;
	
	public Image       pc1;
	public Image       pc2;
	public Image       pc3;
	public Image       pc4;
	
	private bool changeTurnPC = false;
	
	
	// Turn Card
	public Image	   cardTurn;
	public Image       turnDisc;
	public Text        playerTurn;
	public Text        textTurn;
	public Button      btnTurn;
	bool btnVis = false;
	
	public bool 	 diceEnabled = true;
	
	// Sounds section
	public AudioSource diceSound;
	public AudioSource luckySound;
	public AudioSource clickSound;
	public AudioSource virusSound;
	public AudioSource posansSound;
	public AudioSource negansSound;
	public AudioSource moveCard;
	public AudioSource antivirusCard;
	public AudioSource hiscoreSound;
	public AudioSource winnerSound;
	public AudioSource winPC;
	public AudioSource challengeSound;
	
	private string[] sentences;
	private string[] extrapos;
	private string[] extraneg;
	private string[] probcard;
	private string[] phrases;
	private int[]    extrapospoints = new int[] {400,100,300,200,100,200,300,300,300,300,100,300,100,200,200,100,200,200,200,200};
	private int[]    extranegpoints = new int[] {300,300,300,300,300,300,200,100,200,200,300,300,300,200,300,300,200,300,300,300};
	
	public int numQuestions = 11;
	public int numLucky = 40;
	private int[] qseq = new int[] {0,0,0,0,0,0,0,0,0,0};
	private int[] lseq = new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	private int   q1 = 0;
	private int   q2 = 0;
	private int   q3 = 0;
	private int   q4 = 0;
	private int   l1 = 0;
	
	private int answerResultType = 0;
	private int selectedAnswer = 0;
	private int currentAttempt = 0;
	private int answerWaited = 1;
	private int questionType = 0;
	
	private int _diceFace = 0;
	private int _forcedMove = 0;
	
	private bool its2dview = false;
	
	private bool playSounds = true;

	private string plr1;
	private string plr2;
	
	// The function prepare de question sequence
	void prepareSequence() {
		// Sequence for card 1
		int index = 0;
		while (index<numQuestions-1) {
			bool trovato = false;
			int qNum = Random.Range(1,numQuestions);
			for(int i=0;i<index;i++)
				if(qseq[i]==qNum)
					trovato=true;
			if(!trovato) {
				qseq[index]=qNum;
				++index;
			}
		}
		q1 = 0;
		q2 = 0;
		q3 = 0;
		q4 = 0;
		// sequence for lucky cards
		index = 0;
		while (index<numLucky-1)
		{
			bool trovato = false;
			int qNum=0;
			while(qNum==0)
			{
				qNum = Random.Range(-19,21);
			}
			for(int i=0;i<index;i++)
			{
				if(lseq[i]==qNum)
				{
					trovato=true;
				}
			}
			if(!trovato) 
			{
				lseq[index]=qNum;
				++index;
			}
		}
		l1 = 0;
	}
	
	// Hide powercards
	public void hidePowercards() {
		pc1.enabled = false;
		pc2.enabled = false;
		pc3.enabled = false;
		pc4.enabled = false;
	}
	
	// Shows and hide powercard message
	public void hideWinPowercard() {
		winPowercard.enabled = false;
		imgOkWinPC.enabled = false;
		btnOkWinPC.enabled = false;
		txt1WPC.enabled = false;
		txt2WPC.enabled = false;
		txt3WPC.enabled = false;
		txt4WPC.enabled = false;
	}
	
	public void showWinPowercard(int cardType) {
		if(playSounds)
			winPC.Play();
		winPowercard.enabled = true;
		imgOkWinPC.enabled = true;
		txt1WPC.enabled = true;
		txt2WPC.enabled = true;
		txt3WPC.enabled = true;
		txt4WPC.enabled = true;
		switch(cardType) {
		case 1:
			winPowercard.sprite = Resources.Load<Sprite>("Textures/green_bkg");
			break;
		case 2:
			winPowercard.sprite = Resources.Load<Sprite>("Textures/blue_bkg");
			break;
		case 3:
			winPowercard.sprite = Resources.Load<Sprite>("Textures/red_bkg");
			break;
		case 4:
			winPowercard.sprite = Resources.Load<Sprite>("Textures/orange_bkg");
			break;
		}
		txt1WPC.text = getPhraseFromId ("R00001");
		txt2WPC.text = getPhraseFromId ("R00002");
		txt4WPC.text = getPhraseFromId ("R00003");
		switch(cardType) {
		case 1:
			txt3WPC.text = getPhraseFromId ("R00004");
			break;
		case 2:
			txt3WPC.text = getPhraseFromId ("R00005");
			break;
		case 3:
			txt3WPC.text = getPhraseFromId ("R00006");
			break;
		case 4:
			txt3WPC.text = getPhraseFromId ("R00007");
			break;
		}
		if (gu.currentTurn == 2 && gu.numPlayers == 1) 
			Invoke("closeWinPC",2.0f);
		else
			btnOkWinPC.enabled = true;
		updateControlPanel ();
	}
	
	public void closeWinPC() {
		hideWinPowercard ();
		showPowerCard (questionType);
	}
	
	// Shows and hide powercard
	public void hidePowercard() {
//		powerCard.enabled = false;
		btnImage.enabled = false;
		closePC.enabled = false;
		bordoPC.enabled = false;

		cardImg.enabled=false;
		iconImg.enabled=false;
		flash1Img.enabled=false;
		flash2Img.enabled=false;
		flash3Img.enabled=false;
		titleCardTxt.enabled=false;
		content1Txt.enabled=false;
		content2Txt.enabled=false;
		content3Txt.enabled=false;
	}
	
	public void showPowerCard(int cardType) {
//		powerCard.enabled = true;
		btnImage.enabled = true;
		bordoPC.enabled = true;
//		string suffix = PlayerPrefs.GetString ("linguaSuffix");

		cardImg.enabled=true;
		iconImg.enabled=true;
		flash1Img.enabled=true;
		flash2Img.enabled=true;
		flash3Img.enabled=true;
		titleCardTxt.enabled=true;
		content1Txt.enabled=true;
		content2Txt.enabled=true;
		content3Txt.enabled=true;

		//Textify
		TextAsset qAsset = null;
		string suffix = PlayerPrefs.GetString ("linguaSuffix");
		string fname = "Text/power_" + suffix;
		//		//print (fname);
		qAsset = (TextAsset)Resources.Load(fname);
		string testoIntero = qAsset.text;
		strgs = testoIntero.Split ("\r\n" [0]);
		string[] strg;

		switch(cardType) {
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
		case 4 : 
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
		case 3 : 
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
		PlayerController pc = gu.getCurrAvatar().GetComponent<PlayerController> ();
		pc.currentScore += 500;
		if (gu.currentTurn == 2 && gu.numPlayers == 1)
			Invoke ("closePowerCardButton", 3.0f);
		else
			closePC.enabled = true;
	}
	
	public void closePowerCardButton() {
		if(playSounds)
			clickSound.Play ();
		hidePowercard ();
		if(changeTurnPC) 
			gu.changeTurn ();
	}
	
	public void showPowerCard1() {
		changeTurnPC=false;
		showPowerCard(1);
	}
	
	public void showPowerCard2() {
		changeTurnPC=false;
		showPowerCard(2);
	}
	
	public void showPowerCard3() {
		changeTurnPC=false;
		showPowerCard(4);
	}
	
	public void showPowerCard4() {
		changeTurnPC=false;
		showPowerCard(3);
	}
	
	// Shows and hides score card
	public void hideScore() {
		scoreCard.enabled = false;
		confirm.enabled = false;
		confimImage.enabled = false;
		logoScore.enabled = false;
		textScore.enabled = false;
		textPoints.enabled = false;
		tynText.enabled = false;
		ifName.enabled = false;
		ifLimits.enabled = false;
		ifphText.enabled = false;
		ifText.enabled = false;
		disclaimerText.enabled = false;
	}
	
	public void showScore(string playerScore) {
		if(playSounds)
			hiscoreSound.Play ();
		scoreCard.enabled = true;
		confirm.enabled = true;
		confimImage.enabled = true;
		logoScore.enabled = true;
		textScore.enabled = true;
		textPoints.enabled = true;
		tynText.enabled = true;
		ifName.enabled = true;
		ifLimits.enabled = true;
		ifphText.enabled = true;
		ifText.enabled = true;

		disclaimerText.enabled = true;

		textPoints.text = playerScore;
		if(playerScore==scorePWinText.text)
			ifphText.text = playerWinText.text;
		else
			ifphText.text = p2Text.text;
		tynText.text = getPhraseFromId ("R00008");
		disclaimerText.text = getPhraseFromId ("R00009");
		ifName.ActivateInputField ();
		ifName.Select ();
		ifText.text = "";
		ifName.text = "";
		/*
		EventSystem.current.SetSelectedGameObject(ifName.gameObject, null);
		ifName.OnPointerClick (new PointerEventData(EventSystem.current));
		*/
	}
	
	public void confirmName() {
		if(playSounds)
			clickSound.Play ();
//		PlayerController pc = gu.getCurrAvatar().GetComponent<PlayerController> ();
		int[] sc = new int[] {0,0,0,0,0};
		string[] scName = new string[] {"","","","",""};
		sc[0] = PlayerPrefs.GetInt ("sc1");
		sc[1] = PlayerPrefs.GetInt ("sc2");
		sc[2] = PlayerPrefs.GetInt ("sc3");
		sc[3] = PlayerPrefs.GetInt ("sc4");
		sc[4] = PlayerPrefs.GetInt ("sc5");
		scName[0] = PlayerPrefs.GetString ("nam1");
		scName[1] = PlayerPrefs.GetString ("nam2");
		scName[2] = PlayerPrefs.GetString ("nam3");
		scName[3] = PlayerPrefs.GetString ("nam4");
		scName[4] = PlayerPrefs.GetString ("nam5");
        if (ifphText.text == "Player 1" || ifphText.text == "Joueur 1" || ifphText.text == "Giocatore 1" || ifphText.text == "Speler 1" || ifphText.text == "Jugador 1" || ifphText.text == "PLAYER 1" || ifphText.text == "JOUEUR 1" || ifphText.text == "GIOCATORE 1" || ifphText.text == "SPELER 1" || ifphText.text == "JUGADOR 1") 
		{
            //print("ifphText.text=" + ifphText.text);
			if (int.Parse(textPoints.text) > sc [0]) {
				//print("maggiore del primo");
				for (int i=4; i>0; i--) {
					//print("cambio"+ sc [i]+" con "+sc [i-1]);
					//print("cambio"+ scName [i]+" con "+scName [i-1]);
					sc [i] = sc [i-1];
					scName [i] = scName [i-1];
				}
				sc [0] = int.Parse(textPoints.text);
				scName [0] = ifText.text;
			} else if (int.Parse(textPoints.text) > sc [1]) {
				//print("maggiore del secondo");
                for (int i=4; i>1; i--)
                {
					//print("cambio"+ sc [i]+" con "+sc [i-1]);
					//print("cambio"+ scName [i]+" con "+scName [i-1]);
					sc [i] = sc [i-1];
					scName [i] = scName [i-1];
				}
				sc [1] = int.Parse(textPoints.text);
				scName [1] = ifText.text;
			} else if (int.Parse(textPoints.text) > sc [2]) {
				//print("maggiore del terzo");
                for (int i = 4; i > 2; i--)
                {
                    //print("cambio" + sc[i] + " con " + sc[i - 1]);
                    //print("cambio" + scName[i] + " con " + scName[i - 1]);
                    sc[i] = sc[i - 1];
                    scName[i] = scName[i - 1];
                }
                sc[2] = int.Parse(textPoints.text);
                scName[2] = ifText.text;
			} else if (int.Parse(textPoints.text) > sc [3]) {
				//print("maggiore del quarto");
                for (int i = 4; i > 3; i--)
                {
                    //print("cambio" + sc[i] + " con " + sc[i - 1]);
                    //print("cambio" + scName[i] + " con " + scName[i - 1]);
                    sc[i] = sc[i - 1];
                    scName[i] = scName[i - 1];
                }
                sc[3] = int.Parse(textPoints.text);
                scName[3] = ifText.text;
			} else if (int.Parse(textPoints.text) > sc [4]) {
				//print("maggiore del quinto");
				sc [4] = int.Parse(textPoints.text);
				scName [4] = ifText.text;
			}

			for (int i=0; i<5; i++) {
				//print(i+"salvo "+ sc [i]+" punti con il nome "+scName [i]);
				PlayerPrefs.SetInt ("sc" + (i+1).ToString (), sc [i]);
				PlayerPrefs.SetString ("nam" + (i+1).ToString (), scName [i]);
			}

			if (p2Text.text != "Computer" && p2Text.text != "Player 1" && int.Parse(scoreP2Text.text) > sc [4] && int.Parse(scoreP2Text.text)!= sc [3] && int.Parse(scoreP2Text.text)!= sc [2] && int.Parse(scoreP2Text.text)!= sc [1] && int.Parse(scoreP2Text.text)!= sc [0])
			{
				showScore(scoreP2Text.text);
				return;
			}
		}
        else if (ifphText.text == "Player 2" || ifphText.text == "Joueur 2" || ifphText.text == "Giocatore 2" || ifphText.text == "Speler 2" || ifphText.text == "Jugador 2" || ifphText.text == "PLAYER 2" || ifphText.text == "JOUEUR 2" || ifphText.text == "GIOCATORE 2" || ifphText.text == "SPELER 2" || ifphText.text == "JUGADOR 2") 
		{
            print("ifphText.text=" + ifphText.text);
            if (int.Parse(textPoints.text) > sc[0])
            {
                //print("maggiore del primo");
                for (int i = 4; i > 0; i--)
                {
                    //print("cambio" + sc[i] + " con " + sc[i - 1]);
                    //print("cambio" + scName[i] + " con " + scName[i - 1]);
                    sc[i] = sc[i - 1];
                    scName[i] = scName[i - 1];
                }
                sc[0] = int.Parse(textPoints.text);
                scName[0] = ifText.text;
            }
            else if (int.Parse(textPoints.text) > sc[1])
            {
                //print("maggiore del secondo");
                for (int i = 4; i > 1; i--)
                {
                    //print("cambio" + sc[i] + " con " + sc[i - 1]);
                    //print("cambio" + scName[i] + " con " + scName[i - 1]);
                    sc[i] = sc[i - 1];
                    scName[i] = scName[i - 1];
                }
                sc[1] = int.Parse(textPoints.text);
                scName[1] = ifText.text;
            }
            else if (int.Parse(textPoints.text) > sc[2])
            {
                //print("maggiore del terzo");
                for (int i = 4; i > 2; i--)
                {
                    //print("cambio" + sc[i] + " con " + sc[i - 1]);
                    //print("cambio" + scName[i] + " con " + scName[i - 1]);
                    sc[i] = sc[i - 1];
                    scName[i] = scName[i - 1];
                }
                sc[2] = int.Parse(textPoints.text);
                scName[2] = ifText.text;
            }
            else if (int.Parse(textPoints.text) > sc[3])
            {
                //print("maggiore del quarto");
                for (int i = 4; i > 3; i--)
                {
                    //print("cambio" + sc[i] + " con " + sc[i - 1]);
                    //print("cambio" + scName[i] + " con " + scName[i - 1]);
                    sc[i] = sc[i - 1];
                    scName[i] = scName[i - 1];
                }
                sc[3] = int.Parse(textPoints.text);
                scName[3] = ifText.text;
            }
            else if (int.Parse(textPoints.text) > sc[4])
            {
                //print("maggiore del quinto");
                sc[4] = int.Parse(textPoints.text);
                scName[4] = ifText.text;
            }

			for (int i=0; i<5; i++) {
				//print(i+"salvo"+ sc [i]+" punti con il nome "+scName [i]);
				PlayerPrefs.SetInt ("sc" + (i+1).ToString (), sc [i]);
				PlayerPrefs.SetString ("nam" + (i+1).ToString (), scName [i]);
			}

			if (p2Text.text != "Computer" && p2Text.text != "Player 2" && int.Parse(scoreP2Text.text) > sc [4] && int.Parse(scoreP2Text.text)!= sc [3] && int.Parse(scoreP2Text.text)!= sc [2] && int.Parse(scoreP2Text.text)!= sc [1] && int.Parse(scoreP2Text.text)!= sc [0])
			{
				showScore(scoreP2Text.text);
				return;
			}
		}
		//Application.LoadLevel ("MainMenu");
		SceneManager.LoadScene("MainMenu");
	}
	
	public void showFinish() 
	{
		finishCard.enabled = true;
		titoloFinish.enabled = true;
		testoFinish.enabled = true;
		okBtnFinish.enabled = true;
		Image img = okBtnFinish.GetComponent<Image> ();
		img.enabled = true;
		if (gu.currentTurn == 1) 
			titoloFinish.text = plr1;
		else
			if (gu.currentTurn == 2 && gu.numPlayers == 1)
				titoloFinish.text = "Computer";
		else 
				titoloFinish.text = plr2;
		testoFinish.text = getPhraseFromId ("R00025");
		if(playSounds)
			winPC.Play();
		if (gu.currentTurn == 2 && gu.numPlayers == 1)
			Invoke ("hideFinish", 3.0f);
	}
	
	public void hideFinish() 
	{
		//Assegno il Bonus a chi è arrivato al Finish
		PlayerController pc = null;
		if (gu.currentTurn == 1) 
			pc = avatar1.GetComponent<PlayerController> ();
		else
			pc = avatar2.GetComponent<PlayerController> ();
		pc.currentScore = pc.currentScore + finishAttemptPoints;
		updateControlPanel ();
		//Nascondo la carta
		finishCard.enabled = false;
		titoloFinish.enabled = false;
		testoFinish.enabled = false;
		okBtnFinish.enabled = false;
		Image img = okBtnFinish.GetComponent<Image> ();
		img.enabled = false;
		//Show the winner
		showWinner ();
	}
	
	// Shows and hides winner card
	public void hideWinner() {
		winnerCard.enabled = false;
		logo.enabled = false;
		congText.enabled = false;
		playerWinText.enabled = false;
		scorePWinText.enabled = false;
		cup.enabled = false;
		okButtonWin.enabled = false;
		okBtnWinImage.enabled = false;
		p1Text.enabled = false;
		scoreP1Text.enabled = false;
		p2Text.enabled = false;
		scoreP2Text.enabled = false;
		p3Text.enabled = false;
		scoreP3Text.enabled = false;
		fireworks.Stop ();
	}
	
	public void showWinner() 
	{
		winnerCard.enabled = true;
		logo.enabled = true;
		congText.enabled = true;
		cup.enabled = true;
		playerWinText.enabled = true;
		scorePWinText.enabled = true;
		p2Text.enabled = true;
		scoreP2Text.enabled = true;
		okButtonWin.enabled = true;
		okBtnWinImage.enabled = true;

		//Catturo i punteggi
		p1Text.text = plr1;
		PlayerController p1=avatar1.GetComponent<PlayerController> ();
		PlayerController p2=avatar2.GetComponent<PlayerController> ();
		string p1score=p1.currentScore.ToString();
		string p2score=p2.currentScore.ToString();

		//Capire chi ha vinto
		//parità
		if(int.Parse(p1score)==int.Parse(p2score))
		{
			cup.enabled = false;
			congText.text = getPhraseFromId ("R00026");
			playerWinText.text="";
			//print ("Parità!!!");

			playerWinText.text = plr1;
			scorePWinText.text=p1score;
			if (PlayerPrefs.GetInt("numplayers") == 1)
				p2Text.text = "Computer";
			else 
				p2Text.text = plr2;
			scoreP2Text.text=p2score;
		}
		//player1 wins
		else if(int.Parse(p1score)>int.Parse(p2score))
		{
			congText.text = getPhraseFromId ("R00027");
			playerWinText.text = plr1;
			scorePWinText.text=p1score;
			if (PlayerPrefs.GetInt("numplayers") == 1)
				p2Text.text = "Computer";
			else 
				p2Text.text = plr2;
			scoreP2Text.text=p2score;
			fireworks.Play ();
		}
		//player2 wins
		else if(int.Parse(p1score)<int.Parse(p2score))
		{
			if (PlayerPrefs.GetInt("numplayers") == 1)
			{
				cup.enabled = false;
				playerWinText.text = "Computer";
				scorePWinText.text=p2score;
				p2Text.text = plr1;
				scoreP2Text.text=p1score;
				congText.text = getPhraseFromId ("R00028");
			}
			else 
			{
				playerWinText.text = plr2;
				scorePWinText.text=p2score;
				p2Text.text = plr1;
				scoreP2Text.text=p1score;
				congText.text = getPhraseFromId ("R00027");
				fireworks.Play ();
			}
		}
		if(playSounds)
			winnerSound.Play ();
		if (gu.currentTurn == 2 && gu.numPlayers == 1)
			Invoke ("okWinButtonPressed", 5.0f);
	}
	
	public void okWinButtonPressed() {
		if(playSounds)
			clickSound.Play ();
		hideWinner ();
		int s5 = PlayerPrefs.GetInt ("sc5", 0);
		if (gu.currentTurn == 2 && gu.numPlayers == 1) 
		{
			if(int.Parse(scorePWinText.text)>s5) 
				showScore(scorePWinText.text);
			else
			{
				//Application.LoadLevel ("MainMenu");
				SceneManager.LoadScene("MainMenu");
			}
		} 
		else 
		{
			// Checks for hi-scores
			if(playerWinText.text==plr1)
			{
				if(int.Parse(scorePWinText.text)>s5)
					showScore(scorePWinText.text);
				else if(int.Parse(scoreP2Text.text)>s5) 
					showScore(scoreP2Text.text);
				else
				{
					//Application.LoadLevel ("MainMenu");
					SceneManager.LoadScene("MainMenu");
				}
			}
			else
			{
				if(int.Parse(scorePWinText.text)>s5) 
					showScore(scorePWinText.text);
				else if(int.Parse(scoreP2Text.text)>s5)
					showScore(scoreP2Text.text);
				else
				{
					//Application.LoadLevel ("MainMenu");
					SceneManager.LoadScene("MainMenu");
				}
			}
		}
	}
		
	private string getPhraseFromId (string id) 
	{
		for (int idx=0; idx<phrases.Length; idx++) 
		{
			string[] couple = phrases [idx].Split ('=');
			couple [0] = couple [0].Replace ("\n", "").Replace ("\r", "");
			if(string.Compare(couple[0],id)==0) 
			{
				// string found
				return couple[1];
			}
		}
		return "";
	}

	//per levare gli invii e spazi prima e dopo la stringa
	private string getPhraseFromId2 (string id) 
	{
		id = id.Replace ("\n", "").Replace ("\r", "");
		return id;
	}
	
	// This function loads questions and answers based on selected language
	void loadSentences() {
		TextAsset qAsset = null;
		string suffix = PlayerPrefs.GetString ("linguaSuffix");
		string fname = "Text/questions_" + suffix;
		qAsset = (TextAsset)Resources.Load(fname);
		string testoDomande = qAsset.text;
		sentences = testoDomande.Split ("\r\n" [0]);
		
		fname = "Text/extrapos_" + suffix;
		qAsset = (TextAsset)Resources.Load(fname);
		string testoExtrapos = qAsset.text;
		extrapos = testoExtrapos.Split ("\r\n" [0]);
		
		fname = "Text/extraneg_" + suffix;
		qAsset = (TextAsset)Resources.Load(fname);
		string testoExtraneg = qAsset.text;
		extraneg = testoExtraneg.Split ("\r\n" [0]);
		
		fname = "Text/probcard_" + suffix;
		qAsset = (TextAsset)Resources.Load(fname);
		string testoProbcard = qAsset.text;
		probcard = testoProbcard.Split ("\r\n" [0]);
		
		fname = "Text/phrases_" + suffix;
		qAsset = (TextAsset)Resources.Load(fname);
		string testoPhrases = qAsset.text;
		phrases = testoPhrases.Split ("\r\n" [0]);
	}
	
	// This function switch to 2d view
	public void switchTo2DView() {
		if (!its2dview) {
			if(playSounds)
				clickSound.Play();
			gu.gameBoardRotation = false;
			mc.orthographic = true;
			mc.enabled = true;
			ac1.enabled = false;
			ac2.enabled = false;
			mainCanvas.worldCamera = mc;
			Vector3 pos = transform.localPosition;
			Quaternion rot = transform.localRotation;
			pos.x = 0f;
			pos.y = 10f;
			pos.z = -0.6f;
			rot.x = 0.90f;
			rot.y = 0.0f;
			rot.z = 0.0f;
			transform.localPosition = pos;
			mc.transform.localRotation = rot;
			Image symbol1 = camera1.GetComponent<Image> ();
			symbol1.sprite = Resources.Load<Sprite> ("Textures/2d_on");
			Image symbol2 = camera2.GetComponent<Image> ();
			symbol2.sprite = Resources.Load<Sprite> ("Textures/3d_off");
			Image symbol3 = camera3.GetComponent<Image> ();
			symbol3.sprite = Resources.Load<Sprite> ("Textures/3d_offplus");
			crc.v2d=true;
			its2dview = true;
		}
	}
	
	private void internalSwitch3D() {
		its2dview = false;
		gu.gameBoardRotation = true;
		mc.orthographic = false;
		mc.enabled = true;
		ac1.enabled = false;
		ac2.enabled = false;
		mainCanvas.worldCamera = mc;
		Vector3 pos = transform.localPosition;
		Quaternion rot = Quaternion.Euler(37.91977f, 34.30883f, 3.484097f);
		pos.x = -13.03f;
		pos.y = 14.91f;
		pos.z = -18.36f;
		transform.localPosition = pos;
		mc.transform.localRotation = rot;
		crc.v3d=true;
		Image symbol1 = camera1.GetComponent<Image> ();
		symbol1.sprite = Resources.Load<Sprite> ("Textures/2d_off");
		Image symbol2 = camera2.GetComponent<Image> ();
		symbol2.sprite = Resources.Load<Sprite> ("Textures/3d_on");
		Image symbol3 = camera3.GetComponent<Image> ();
		symbol3.sprite = Resources.Load<Sprite> ("Textures/3d_offplus");
	}
	
	// This function switches to 3d view
	public void switchTo3DView() {
		if(playSounds)
			clickSound.Play ();
		internalSwitch3D();
	}
	
	// This function switches to 3d+ view
	public void switchTo3DPlusView() {
		internalSwitch3D();
		if(playSounds)
			clickSound.Play ();
		its2dview = false;
		gu.gameBoardRotation = false;
		mc.orthographic = false;
		mc.enabled = false;
		ac1.enabled = false;
		ac2.enabled = false;
		if (gu.currentTurn == 1) {
			ac1.enabled = true;
			mainCanvas.worldCamera = ac1;
		} else {
			ac2.enabled = true;
			mainCanvas.worldCamera = ac2;
		}
		Image symbol1 = camera1.GetComponent<Image> ();
		symbol1.sprite = Resources.Load<Sprite> ("Textures/2d_off");
		Image symbol2 = camera2.GetComponent<Image> ();
		symbol2.sprite = Resources.Load<Sprite> ("Textures/3d_off");
		Image symbol3 = camera3.GetComponent<Image> ();
		symbol3.sprite = Resources.Load<Sprite> ("Textures/3d_onplus");
	}
	
	// Dice hit and show
	public void hitDice() {
		if (diceEnabled) 
		{
			diceEnabled = false;
			_diceFace = Random.Range (1, 7);
			Sprite sprite = null;
			switch (_diceFace) {
			case 1: 
				sprite = Resources.Load<Sprite> ("Textures/D1");
				break;
			case 2: 
				sprite = Resources.Load<Sprite> ("Textures/D2");
				break;
			case 3: 
				sprite = Resources.Load<Sprite> ("Textures/D3");
				break;
			case 4: 
				sprite = Resources.Load<Sprite> ("Textures/D4");
				break;
			case 5: 
				sprite = Resources.Load<Sprite> ("Textures/D5");
				break;
			case 6: 
				sprite = Resources.Load<Sprite> ("Textures/D6");
				break;
			}
			dice.sprite = sprite;
			dice.enabled = true;
			Invoke ("hideDice", 1);
			if (playSounds)
				diceSound.Play ();
			btnDice.interactable = false;
		}
	}
	
	// Hide the dice
	void hideDice() {
		dice.enabled = false;
		gu.playTurn(_diceFace);
	}
	
	void hideHomeCard() {
		homeCard.enabled = false;
		confirmTxt.enabled = false;
		exitBtn.enabled = false;
		resumeBtn.enabled = false;
		Text t2 = exitBtn.GetComponentInChildren<Text> ();
		t2.enabled = false;
		Text t3 = resumeBtn.GetComponentInChildren<Text> ();
		t3.enabled = false;
	}
	
	void hideVirusCard() {
		virusCard.enabled = false;
		Image[] imgs = virusCard.GetComponentsInChildren<Image> ();
		for(int i=0;i<imgs.Length;i++) 
			imgs[i].enabled = false;
		Text txt = virusCard.GetComponentInChildren<Text> ();
		txt.enabled = false;
		Button btn = virusCard.GetComponentInChildren<Button> ();
		btn.enabled = false;
		Image img = btn.GetComponent<Image> ();
		img.enabled = false;
	}
	
	void hideLuckyCard() {
		luckyCard.enabled = false;
		Image[] imgs = luckyCard.GetComponentsInChildren<Image> ();
		for(int i=0;i<imgs.Length;i++) 
			imgs[i].enabled = false;
		Text txt = luckyCard.GetComponentInChildren<Text> ();
		txt.enabled = false;
		Button btn = luckyCard.GetComponentInChildren<Button> ();
		btn.enabled = false;
		Image img = btn.GetComponent<Image> ();
		img.enabled = false;
	}

	public void hideTurnCardOnClick() 
	{
		if (gu.currentTurn == 1 && gu.numPlayers == 2 || gu.currentTurn == 2)
			btnDice.interactable = true;
		btnVis = false;
		cardTurn.enabled = false;
		turnDisc.enabled = false;
		playerTurn.enabled = false;
		textTurn.enabled = false;
		btnTurn.enabled = false;
		gu.changeTurnStep2 ();
	}

	void hideTurnCard() {
		if(btnVis)
		{
			if (gu.currentTurn == 1 && gu.numPlayers == 2 || gu.currentTurn == 2)
					btnDice.interactable = true;
			btnVis = false;
			cardTurn.enabled = false;
			turnDisc.enabled = false;
			playerTurn.enabled = false;
			textTurn.enabled = false;
			btnTurn.enabled = false;
			gu.changeTurnStep2 ();
		}
	}
	
	void hideProbsCard() {
		probCard.enabled = false;
		Image[] imgs = probCard.GetComponentsInChildren<Image> ();
		for(int i=0;i<imgs.Length;i++) 
			imgs[i].enabled = false;
		txt1Prob.enabled = false;
		txt2Prob.enabled = false;
		Button btn = probCard.GetComponentInChildren<Button> ();
		btn.enabled = false;
		Image img = btn.GetComponent<Image> ();
		img.enabled = false;
		Invoke ("forcedMove", 0.5f);
	}
	
	// Functions to show or hide avCard
	void hideAVCard() {
		avCard.enabled = false;
		Image[] imgs = avCard.GetComponentsInChildren<Image> ();
		for (int i=0; i<imgs.Length; i++) {
			imgs[i].enabled = false;
		}
		Text txt = avCard.GetComponentInChildren<Text> ();
		txt.enabled = false;
		Button btn = avCard.GetComponentInChildren<Button> ();
		btn.enabled = false;
		Image img = btn.GetComponent<Image> ();
		img.enabled = false;
	}
	
	public void showTurnCard() {
		cardTurn.enabled = true;
		turnDisc.enabled = true;
		playerTurn.enabled = true;
		textTurn.enabled = true;
		btnTurn.enabled = true;
		btnVis = true;
		PlayerController pc = null;
		PlayerController pcCheck = null;
		if(gu.getCurrAvatar()!=null) 
			pc = gu.getCurrAvatar().GetComponent<PlayerController> ();
		int playerColor = 0;
		if (gu.currentTurn == 1) {
			pc = avatar1.GetComponent<PlayerController> ();
			pcCheck = avatar2.GetComponent<PlayerController> ();
			playerColor = PlayerPrefs.GetInt ("p2color", 1);
			if (gu.currentTurn == 1 && gu.numPlayers == 1)
				playerTurn.text = "Computer";
			else 
				playerTurn.text = plr2;
		} else {
			pc = avatar2.GetComponent<PlayerController> ();
			pcCheck = avatar1.GetComponent<PlayerController> ();
			playerColor = PlayerPrefs.GetInt ("p1color", 2);
			playerTurn.text = plr1;
		}
		Sprite sprite  = null;
		switch (playerColor) {
		case 1 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoArancioneFisso");
			break;
		case 2 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoCianoFisso");
			break;
		case 3 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoGialloFisso");
			break;
		case 4 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoMagentaFisso");
			break;
		case 5 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoRossoFisso");
			break;
		case 6 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoVerdeFisso");
			break;
		}
		turnDisc.sprite = sprite;
		if (pcCheck.waitTurns == 0) 
			textTurn.text = getPhraseFromId ("R00012");
		else
			textTurn.text = getPhraseFromId ("R00013");
		Invoke ("hideTurnCard", 2.0f);
	}
	
	public void showHomeCard() {
		homeCard.enabled = true;
		confirmTxt.enabled = true;
		exitBtn.enabled = true;
		resumeBtn.enabled = true;
		
		TextAsset qAsset = null;
		string suffix = PlayerPrefs.GetString ("linguaSuffix");
		string fname = "Text/menu_" + suffix;
		qAsset = (TextAsset)Resources.Load(fname);
		string testoIntero = qAsset.text;
		strgs = testoIntero.Split ("\r\n" [0]);
		
		string[] strg = strgs [17].Split ('=');
		confirmTxt.text = strg[1];

		strg = strgs [18].Split ('=');
		Text t2 = exitBtn.GetComponentInChildren<Text> ();
		t2.enabled = true;
		t2.text=strg[1];
		
		strg = strgs [19].Split ('=');
		Text t3 = resumeBtn.GetComponentInChildren<Text> ();
		t3.enabled = true;
		t3.text=strg[1];

//		Button[] b = homeCard.GetComponentsInChildren<Button> ();
//		for (int i=0; i<b.Length; i++) {
//			Text t = b[i].GetComponentInChildren<Text>();
//			t.enabled = true;
//		}
//		Text l = homeCard.GetComponentInChildren<Text> ();
//		l.enabled = true;
	}
	
	public void showVirus() {
		if(playSounds)
			virusSound.Play ();
		virusCard.enabled = true;
		Image[] imgs = virusCard.GetComponentsInChildren<Image> ();
		for(int i=0;i<imgs.Length;i++) 
			imgs[i].enabled = true;
		Text txt = virusCard.GetComponentInChildren<Text> ();
		txt.enabled = true;
		txt.text = getPhraseFromId ("R00014");
		if (gu.currentTurn == 2 && gu.numPlayers == 1)
			Invoke ("closeVCardButton", 3.0f);
		else {
			Button btn = virusCard.GetComponentInChildren<Button> ();
			btn.enabled = true;
			Image img = btn.GetComponent<Image> ();
			img.enabled = true;
		}
	}
	
	public void showLucky() {
		if(playSounds)
			luckySound.Play ();
		luckyCard.enabled = true;
		Image[] imgs = luckyCard.GetComponentsInChildren<Image> ();
		for(int i=0;i<imgs.Length;i++) 
			imgs[i].enabled = true;
		Text txt = luckyCard.GetComponentInChildren<Text> ();
		txt.enabled = true;
		int punti = 0;
		int tipmsg = lseq [l1];
		if (tipmsg > 0) {
			int nummsg = Mathf.Abs(tipmsg)-1;
			txt.text = getPhraseFromId2(extrapos[nummsg]);
			punti = extrapospoints[nummsg];
		} else {
			int nummsg = Mathf.Abs(tipmsg);
			if(nummsg<0)nummsg=0;
			txt.text = getPhraseFromId2(extraneg[nummsg]);
			punti = -extranegpoints[nummsg];
		}
		l1 = l1 + 1;
		if (l1 == 40)l1 = 0;
		PlayerController pc = null;
		if (gu.currentTurn == 1) 
			pc = avatar1.GetComponent<PlayerController> ();
		if (gu.currentTurn == 2) 
			pc = avatar2.GetComponent<PlayerController> ();
		pc.currentScore = pc.currentScore + punti;
		// Chiama la chiusura della card se è il turno del computer
		if (gu.currentTurn == 2 && gu.numPlayers == 1)
			Invoke ("closeLCardButton", 5.0f);
		else {
			Button btn = luckyCard.GetComponentInChildren<Button> ();
			btn.enabled = true;
			Image img = btn.GetComponent<Image> ();
			img.enabled = true;
		}
		updateControlPanel ();
	}
	
	public void showProb() {
		if(playSounds)
			moveCard.Play ();
		probCard.enabled = true;
		Image[] imgs = probCard.GetComponentsInChildren<Image> ();
		for(int i=0;i<imgs.Length;i++) 
			imgs[i].enabled = true;
		txt1Prob.enabled = true;
		txt2Prob.enabled = true;
		int pos = Random.Range (0, probcard.Length);
        if(pos==0)
            txt2Prob.text = "\r\n"+probcard[pos];
        else
            txt2Prob.text = probcard[pos];
		int move = 0;
		switch (pos) {
		case 0:
			txt1Prob.text=getPhraseFromId("R00015");
			move=1;
			break;
		case 1:
			txt1Prob.text=getPhraseFromId("R00015");
			move=2;
			break;
		case 2:
			txt1Prob.text=getPhraseFromId("R00016");
			move=-1;
			break;
		case 3:
			txt1Prob.text=getPhraseFromId("R00016");
			move=-2;
			break;
		}
		_forcedMove = move;
		if (gu.currentTurn == 2 && gu.numPlayers == 1) 
		{
			Button btn = probCard.GetComponentInChildren<Button> ();
			btn.enabled = false;
			Invoke ("closePCardButton", 3.0f);
		}
		else {
			Button btn = probCard.GetComponentInChildren<Button> ();
			btn.enabled = true;
			Image img = btn.GetComponent<Image> ();
			img.enabled = true;
		}
	}
	
	public void showAVCardBlock() {
		if(playSounds)
			antivirusCard.Play ();
		avCard.enabled = true;
		Image[] imgs = avCard.GetComponentsInChildren<Image> ();
		for (int i=0; i<imgs.Length; i++) {
			imgs[i].enabled = true;
		}
		Text txt = avCard.GetComponentInChildren<Text> ();
		txt.enabled = true;
		txt.text = getPhraseFromId("R00017");
		if (gu.currentTurn == 2 && gu.numPlayers == 1)
			Invoke ("closeAVCardButton", 3.0f);
		else {
			Button btn = avCard.GetComponentInChildren<Button> ();
			btn.enabled = true;
			Image img = btn.GetComponent<Image> ();
			img.enabled = true;
		}
	}
	
	public void showAVCard() {
		if(playSounds)
			antivirusCard.Play();
		avCard.enabled = true;
		Image[] imgs = avCard.GetComponentsInChildren<Image> ();
		for (int i=0; i<imgs.Length; i++) {
			imgs[i].enabled = true;
		}
		Text txt = avCard.GetComponentInChildren<Text> ();
		txt.enabled = true;
		txt.text = getPhraseFromId("R00018");
		if (gu.currentTurn == 2 && gu.numPlayers == 1)
			Invoke ("closeAVCardButton", 3.0f);
		else {
			Button btn = avCard.GetComponentInChildren<Button> ();
			btn.enabled = true;
			Image img = btn.GetComponent<Image> ();
			img.enabled = true;
		}
	}
	
	// Update control panel with the current player data
	public void updateControlPanel() {
		PlayerController pc = null;
		if(gu.getCurrAvatar()!=null) 
			pc = gu.getCurrAvatar().GetComponent<PlayerController> ();
		int playerColor = 0;
		if (gu.currentTurn == 1) {
			pc = avatar1.GetComponent<PlayerController> ();
			playerColor = PlayerPrefs.GetInt ("p1color", 1);
		} else {
			pc = avatar2.GetComponent<PlayerController> ();
			playerColor = PlayerPrefs.GetInt ("p2color", 2);
		}
		Sprite sprite  = null;
		switch (playerColor) {
		case 1 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoArancioneFisso");
			break;
		case 2 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoCianoFisso");
			break;
		case 3 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoGialloFisso");
			break;
		case 4 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoMagentaFisso");
			break;
		case 5 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoRossoFisso");
			break;
		case 6 : 
			sprite = Resources.Load<Sprite>("Textures/DiscoVerdeFisso");
			break;
		}
		playerDisk.sprite = sprite;
		score.text = pc.currentScore.ToString("#,##0");
		numAV.text = pc.numAntivirus.ToString ();
		
		// Updates the powercards for the control panel
		pc1.enabled = false;
		pc2.enabled = false;
		pc3.enabled = false;
		pc4.enabled = false;
		
		if (pc.pcOwned [0] >= 2) 
			pc1.enabled = true;
		if (pc.pcOwned [1] >= 2) 
			pc2.enabled = true;
		if (pc.pcOwned [3] >= 2) 
			pc3.enabled = true;
		if (pc.pcOwned [2] >= 2) 
			pc4.enabled = true;
		
	}
	
	// Toggle di audio from the game
	public void toggleAudio() {
		if (music.isPlaying) {
			playSounds = false;
			music.Stop ();
			audioSymbol.sprite = Resources.Load<Sprite>("Textures/audio_off");
		} else {
			playSounds = true;
			clickSound.Play ();
			music.Play ();
			audioSymbol.sprite = Resources.Load<Sprite>("Textures/audio_on");
		}
	}

	void wordTranslate()
	{
		TextAsset qAsset = null;
		string suffix = PlayerPrefs.GetString ("linguaSuffix");
		string fname = "Text/phrases_" + suffix;
		//print (fname);
		qAsset = (TextAsset)Resources.Load(fname);
		string testoIntero = qAsset.text;
		strgs = testoIntero.Split ("\r\n" [0]);
		string[] strg;
		strg = strgs [28].Split ('=');
		playerText.text = strg[1];
		plr1=strg[1]+" 1";
		plr2=strg[1]+" 2";
		//print (strgs.Length);
		strg = strgs [29].Split ('=');
		scoreText.text = strg[1];
	}

	// Use this for initialization
	void Start () {
		// Random Seed initialization
		fireworks.Stop ();
		Random.seed = System.Environment.TickCount;
		hideDice();
		updateControlPanel ();
		hideQuestionCard ();
		hideAVCard ();
		hideVirusCard ();
		hideAnswerResult ();
		hideHomeCard ();
		loadSentences ();
		finishCard.enabled = false;
		titoloFinish.enabled = false;
		testoFinish.enabled = false;
		okBtnFinish.enabled = false;
		Image img = okBtnFinish.GetComponent<Image> ();
		img.enabled = false;
		hideWinner ();
		hideScore ();
		hidePowercard ();
		hideWinPowercard ();
		hidePowercards ();
		prepareSequence ();
		wordTranslate();
		gu.currentTurn = 2;
		showTurnCard ();
	}
	
	// The following functions allow to select an answer and highlights the hexagon associated
	void hideQuestionCard() {
		hex1.enabled = false;
		hex2.enabled = false;
		hex3.enabled = false;
		hex4.enabled = false;
		card.enabled = false;
		symbol.enabled = false;
		textQuestion.enabled = false;
		ans1.enabled = false;
		Text t1 = ans1.GetComponentInChildren<Text> ();
		t1.enabled = false;
		ans2.enabled = false;
		Text t2 = ans2.GetComponentInChildren<Text> ();
		t2.enabled = false;
		ans3.enabled = false;
		Text t3 = ans3.GetComponentInChildren<Text> ();
		t3.enabled = false;
		ans4.enabled = false;
		Text t4 = ans4.GetComponentInChildren<Text> ();
		t4.enabled = false;
		okButton.enabled = false;
		Image i = okButton.GetComponent<Image> ();
		i.enabled = false;
		discoCard.enabled = false;
		currPlayerText.enabled = false;
		zoom.enabled = false;
	}
	
	public void showQuestionCard(int cardType) {
		if(playSounds)
			challengeSound.Play();
		clearAllHex ();
		questionType = cardType;
		discoCard.enabled = true;
		currPlayerText.enabled = true;
		if (gu.currentTurn == 1) {
			currPlayerText.text = plr1;
		} else {
			if (gu.currentTurn == 2 && gu.numPlayers == 1)
				currPlayerText.text = "Computer";
			else 
				currPlayerText.text = plr2;
		}
		int playerColor = 0;
		if (gu.currentTurn == 1) {
			playerColor = PlayerPrefs.GetInt ("p1color", 1);
		} else {
			playerColor = PlayerPrefs.GetInt ("p2color", 2);
		}
		Sprite sprite = null;
		switch (playerColor) {
		case 1: 
			sprite = Resources.Load<Sprite> ("Textures/DiscoArancioneFisso");
			break;
		case 2: 
			sprite = Resources.Load<Sprite> ("Textures/DiscoCianoFisso");
			break;
		case 3: 
			sprite = Resources.Load<Sprite> ("Textures/DiscoGialloFisso");
			break;
		case 4: 
			sprite = Resources.Load<Sprite> ("Textures/DiscoMagentaFisso");
			break;
		case 5: 
			sprite = Resources.Load<Sprite> ("Textures/DiscoRossoFisso");
			break;
		case 6: 
			sprite = Resources.Load<Sprite> ("Textures/DiscoVerdeFisso");
			break;
		}
		discoCard.sprite = sprite;
		hex1.enabled = true;
		hex2.enabled = true;
		hex3.enabled = true;
		hex4.enabled = true;
		card.enabled = true;
		symbol.enabled = true;
		textQuestion.enabled = true;
		ans1.enabled = true;
		Text t1 = ans1.GetComponentInChildren<Text> ();
		t1.enabled = true;
		ans2.enabled = true;
		Text t2 = ans2.GetComponentInChildren<Text> ();
		t2.enabled = true;
		ans3.enabled = true;
		Text t3 = ans3.GetComponentInChildren<Text> ();
		t3.enabled = true;
		ans4.enabled = true;
		Text t4 = ans4.GetComponentInChildren<Text> ();
		t4.enabled = true;
		okButton.enabled = true;
		Image i = okButton.GetComponent<Image> ();
		i.enabled = true;
		selectedAnswer = 0;
		switch (cardType) {
		case 1:
			symbol.sprite = Resources.Load<Sprite> ("Textures/inguardia_icon");
			break;
		case 2:
			symbol.sprite = Resources.Load<Sprite> ("Textures/giocasicuro_icon");
			break;
		case 3:
			symbol.sprite = Resources.Load<Sprite> ("Textures/restaconnesso_icon");
			break;
		case 4:
			symbol.sprite = Resources.Load<Sprite> ("Textures/cyberbullismo_icon");
			break;
		}
		for (int idx=0; idx<sentences.Length; idx++) {
			string[] couple = sentences [idx].Split ('=');
			couple [0] = couple [0].Replace ("\n", "").Replace ("\r", "");
			string qa = couple [0].Substring (0, 1);
			string type = couple [0].Substring (1, 1);
			int qnum = int.Parse (couple [0].Substring (2, 2));
			int qorder = int.Parse (couple [0].Substring (4, 1));
			//string starred = couple[0].Substring(5,1);
			int rightans = int.Parse (couple [0].Substring (6, 1));
			if (cardType == 1 && type.CompareTo ("I") == 0) {
				if (qseq [q1] == qnum) {
					if (qa.CompareTo ("Q") == 0) {
						textQuestion.text = couple [1];
					}
					if (qa.CompareTo ("A") == 0) {
						if (qorder == 1) {
							t1.text = couple [1];
						}
						if (qorder == 2) {
							t2.text = couple [1];
						}
						if (qorder == 3) {
							t3.text = couple [1];
						}
						if (qorder == 4) {
							t4.text = couple [1];
						}
						if (rightans == 1) {
							answerWaited = qorder;
						}
					}
				}
			}
			
			if (cardType == 2 && type.CompareTo ("G") == 0) {
				if (qseq [q2] == qnum) {
					if (qa.CompareTo ("Q") == 0) {
						textQuestion.text = couple [1];
					}
					if (qa.CompareTo ("A") == 0) {
						if (qorder == 1) {
							t1.text = couple [1];
						}
						if (qorder == 2) {
							t2.text = couple [1];
						}
						if (qorder == 3) {
							t3.text = couple [1];
						}
						if (qorder == 4) {
							t4.text = couple [1];
						}
						if (rightans == 1) {
							answerWaited = qorder;
						}
					}
				}
			}
			
			if (cardType == 3 && type.CompareTo ("R") == 0) {
				if (qseq [q3] == qnum) {
					if (qa.CompareTo ("Q") == 0) {
						textQuestion.text = couple [1];
					}
					if (qa.CompareTo ("A") == 0) {
						if (qorder == 1) {
							t1.text = couple [1];
						}
						if (qorder == 2) {
							t2.text = couple [1];
						}
						if (qorder == 3) {
							t3.text = couple [1];
						}
						if (qorder == 4) {
							t4.text = couple [1];
						}
						if (rightans == 1) {
							answerWaited = qorder;
						}
					}
				}
			}
			
			if (cardType == 4 && type.CompareTo ("B") == 0) {
				if (qseq [q4] == qnum) {
					if (qa.CompareTo ("Q") == 0) {
						textQuestion.text = couple [1];
					}
					if (qa.CompareTo ("A") == 0) {
						if (qorder == 1) {
							t1.text = couple [1];
						}
						if (qorder == 2) {
							t2.text = couple [1];
						}
						if (qorder == 3) {
							t3.text = couple [1];
						}
						if (qorder == 4) {
							t4.text = couple [1];
						}
						if (rightans == 1) {
							answerWaited = qorder;
						}
					}
				}
			}
		}
		if (cardType == 1) {
			++q1;
			if (q1 >= 10) 
				q1 = 0;
		}
		if (cardType == 2) {
			++q2;
			if (q2 >= 10) 
				q2 = 0;
		}
		if (cardType == 3) {
			++q3;
			if (q3 >= 10) 
				q3 = 0;
		}
		if (cardType == 4) {
			++q4;
			if (q4 >= 10) 
				q4 = 0;
		}
		currentAttempt = 1;
		if (gu.currentTurn == 2 && gu.numPlayers == 1) {
			int ans = Random.Range (1, 5);
			if (ans == 1) 
				Invoke ("selectAnswer1", 5.0f);
			if (ans == 2) 
				Invoke ("selectAnswer2", 5.0f);
			if (ans == 3) 
				Invoke ("selectAnswer3", 5.0f);
			if (ans == 4) 
				Invoke ("selectAnswer4", 5.0f);
		}
		if (gu.currentTurn == 2 && gu.numPlayers == 1) {
			Button[] btns = card.GetComponentsInChildren<Button> ();
			for (int j=0; j<btns.Length; j++) {
				btns [j].enabled = false;
			}
		} else {
			Button[] btns = card.GetComponentsInChildren<Button> ();
			for (int j=0; j<btns.Length; j++) {
				btns [j].enabled = true;
			}
		}
		zoom.enabled = true;
		zoomBtn.enabled = true;
	}
	
	void clearAllHex() {
		hex1.sprite = Resources.Load<Sprite>("Textures/1b");
		hex2.sprite = Resources.Load<Sprite>("Textures/2b");
		hex3.sprite = Resources.Load<Sprite>("Textures/3b");
		hex4.sprite = Resources.Load<Sprite>("Textures/4b");
	}
	
	public void selectAnswer1() {
		if(playSounds)
			clickSound.Play ();
		clearAllHex ();
		hex1.sprite = Resources.Load<Sprite>("Textures/1");
		selectedAnswer = 1;
		if (gu.currentTurn == 2 && gu.numPlayers == 1) {
			Invoke ("selectOkButton",5.0f);
		}
	}
	
	public void selectAnswer2() {
		if(playSounds)
			clickSound.Play ();
		clearAllHex ();
		hex2.sprite = Resources.Load<Sprite>("Textures/2");
		selectedAnswer = 2;
		if (gu.currentTurn == 2 && gu.numPlayers == 1) {
			Invoke ("selectOkButton",5.0f);
		}
	}
	
	public void selectAnswer3() {
		if(playSounds)
			clickSound.Play ();
		clearAllHex ();
		hex3.sprite = Resources.Load<Sprite>("Textures/3");
		selectedAnswer = 3;
		if (gu.currentTurn == 2 && gu.numPlayers == 1) {
			Invoke ("selectOkButton",5.0f);
		}
	}
	
	public void selectAnswer4() {
		if(playSounds)
			clickSound.Play ();
		clearAllHex ();
		hex4.sprite = Resources.Load<Sprite>("Textures/4");
		selectedAnswer = 4;
		if (gu.currentTurn == 2 && gu.numPlayers == 1) {
			Invoke ("selectOkButton",5.0f);
		}
	}
	
	public void selectOkButton() {
		if (selectedAnswer != 0) 
		{
			okButton.interactable=false;
			if(playSounds)
				clickSound.Play ();
			if (selectedAnswer == answerWaited) 
			{
				PlayerController pc = null;
				if (gu.currentTurn == 1) 
					pc = avatar1.GetComponent<PlayerController> ();
				if (gu.currentTurn == 2) 
					pc = avatar2.GetComponent<PlayerController> ();
				if(currentAttempt==1) 
				{
					showAnswerResult(1);
					pc.currentScore = pc.currentScore + firstAttemptPoints;
					//print ("1");
				}
				else if(currentAttempt==2) 
				{
					showAnswerResult(2);
					pc.currentScore = pc.currentScore + secondAttemptPoints;
					//print ("2");
				}
				updateControlPanel ();
				return;
			}
			++currentAttempt;
			if(currentAttempt==2) 
				showAnswerResult(3);
			else if (currentAttempt > 2)
				showAnswerResult (4);
		}
	}
	
	public void closeAVCardButton() {
		if(playSounds)
			clickSound.Play ();
		hideAVCard ();
		gu.changeTurn ();
	}
	
	public void closeVCardButton() {
		if(playSounds)
			clickSound.Play ();
		hideVirusCard ();
		gu.changeTurn ();
	}
	
	public void closeTCardButton() {
		if(playSounds)
			clickSound.Play ();
		hideTurnCard ();
		gu.changeTurnStep2 ();
	}
	
	public void closeLCardButton() {
		if(playSounds)
			clickSound.Play ();
		hideLuckyCard ();
		gu.changeTurn ();
	}
	
	public void closePCardButton() {
		if(playSounds)
			clickSound.Play ();
		hideProbsCard ();
		probCard.enabled = false;
		Image[] imgs = probCard.GetComponentsInChildren<Image> ();
		for(int i=0;i<imgs.Length;i++) 
			imgs[i].enabled = false;
		txt1Prob.enabled = false;
		txt2Prob.enabled = false;
		Button btn = probCard.GetComponentInChildren<Button> ();
		btn.enabled = false;
		Image img = btn.GetComponent<Image> ();
		img.enabled = false;
		Invoke ("forcedMove", 0.5f);
	}
	
	void forcedMove() {
		gu.forcedMove (_forcedMove);
	}
	
	public void showAnswerResult(int resultType) {
		cartaRisposta.enabled = true;
		Text[] txts = cartaRisposta.GetComponentsInChildren<Text> ();
		for (int i=0; i<txts.Length; i++) {
			txts[i].enabled = true;
		}
		string testo1 = "";
		string testo2 = "";
		switch (resultType) {
		case 1:
			testo1 = getPhraseFromId("R00019");
			testo2 = getPhraseFromId("R00020");
			break;
		case 2:
			testo1 = getPhraseFromId("R00021");
			testo2 = getPhraseFromId("R00020");
			break;
		case 3:
			testo1 = getPhraseFromId("R00023");
			testo2 = getPhraseFromId("R00022");
			break;
		case 4:
			testo1 = getPhraseFromId("R00024");
			testo2 = getPhraseFromId("R00022");
			break;
		}
		if(playSounds) {
			if (resultType == 1 || resultType == 2) {
				posansSound.Play();
			} else {
				negansSound.Play();
			}
		}
		
		txts [0].text = testo1;
		txts [1].text = testo2;
		Button b = cartaRisposta.GetComponentInChildren<Button> ();
		Image img = b.GetComponent<Image> ();
		img.enabled = true;
		b.enabled = true;
		if (gu.currentTurn == 2 && gu.numPlayers == 1) {
			Invoke ("selectOkResult", 2.0f);
			b.enabled = false;
		}
		answerResultType = resultType;
	}
	
	public void hideAnswerResult() {
		cartaRisposta.enabled = false;
		Text[] txts = cartaRisposta.GetComponentsInChildren<Text> ();
		for (int i=0; i<txts.Length; i++) {
			txts[i].enabled = false;
		}
		Button b = cartaRisposta.GetComponentInChildren<Button> ();
		Image img = b.GetComponent<Image> ();
		img.enabled = false;
	}
	
	public void selectOkResult() {
		if(playSounds)
			clickSound.Play ();
		hideAnswerResult ();
		okButton.interactable = true;
		if (answerResultType == 1 || answerResultType == 2 || answerResultType == 4) {
			hideQuestionCard ();
			if(answerResultType==4) {
				gu.stayAside(-1);
			} else {
				PlayerController pc = null;
				if (gu.currentTurn == 1) 
					pc = avatar1.GetComponent<PlayerController> ();
				if (gu.currentTurn == 2) 
					pc = avatar2.GetComponent<PlayerController> ();
				Debug.Log (questionType.ToString());
				++pc.pcOwned[questionType-1];
				if(pc.pcOwned[questionType-1]==2) {
					changeTurnPC=true;
					showWinPowercard(questionType);
				} else {
					gu.changeTurn ();
				}
			}
		} else {
			if (gu.currentTurn == 2 && gu.numPlayers == 1) {
				int ans = Random.Range(1,5);
				if (ans==selectedAnswer)
				{
					++ans;
					if(ans==5)
						ans=1;
				}
				if(ans==1) 
					Invoke ("selectAnswer1", 1.0f);
				if(ans==2) 
					Invoke ("selectAnswer2", 1.0f);
				if(ans==3) 
					Invoke ("selectAnswer3", 1.0f);
				if(ans==4) 
					Invoke ("selectAnswer4", 1.0f);
			}
		}
	}
	
	public void quitGame() {
		if(playSounds)
			clickSound.Play ();
		Application.Quit ();
	}
	
	public void backToMenu() {
		if(playSounds)
			clickSound.Play ();
		//Application.LoadLevel ("MainMenu");
		SceneManager.LoadScene("MainMenu");
	}
	
	public void resumeGame() {
		if(playSounds)
			clickSound.Play ();
		hideHomeCard ();
	}
	
	public void showHomeMenu() {
		if(playSounds)
			clickSound.Play ();
		showHomeCard();
	}
	
	/**
	 * toggleZoom
	 * 
	 * La funzione altera l'ingrandimento della carta. Funziona in toggle.
	 * La prima volta che viene schiacciato il pulsante la carta viene ingrandita
	 * La seconda volta viene rimpicciolita.
	 * Lo stato dello zoom è mantenuto per tutta la durata della partita.
	 * 
	 */
	public void toggleZoom() {
		RectTransform rt = card.rectTransform;
		Vector3 currentScale = rt.localScale;
		if (rt.localScale.x == 1.0f) {
			currentScale.x = 1.4f;
			currentScale.y = 1.4f;
			rt.localScale = currentScale;
			zoom.sprite = Resources.Load<Sprite>("Textures/icon_2");
		} else {
			currentScale.x = 1.0f;
			currentScale.y = 1.0f;
			rt.localScale = currentScale;
			zoom.sprite = Resources.Load<Sprite>("Textures/icon_1");
		}
	}
	
}