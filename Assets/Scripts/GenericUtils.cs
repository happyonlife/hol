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

public class GenericUtils : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;

	public GameObject avatarP1;
	public GameObject avatarP2;

	public int currentTurn = 1;
	public int numPlayers = 1;

	public PlayLevelEvents ple;

	public int firstAnswerOk = 1000;
	public int secondAnswerOk = 1000;
	public int firstClassified = 1500;
	public int secondClassified = 500;

	public bool gameBoardRotation = true;

	private string[] cellSequence = new string[] {"MStart","M01","M02","P01","M03","M04","M05","P02","M06","M07","G07","G06","G05","G04","G03","G02","G01","M08","M09","M10","M11",
												  "P03","M12","P04","M13","M14","P05","M15","M16","P06","M17","M18","M19","P07","M20","M21","M22","P08","M23","M24","P09","M25","M26",
												  "P10","M27","M28","M29","P11","M30","M31","M32","M33"};
	private Vector3 destination;

	private GameObject currAvatar = null;

	/*
	public int playerAvatar = 0;
	*/

	public int currAvatarCell() {
		PlayerController pc = currAvatar.GetComponent<PlayerController> ();
		return pc.currentPlace;
	}

	// This function will set the state for playerInMovement then all the necessary action will be taken
	public int destCellNum(int currentPos, int df) {
		PlayerController pc = currAvatar.GetComponent<PlayerController> ();
		int destCell = currentPos + df;
		string dcn = cellSequence [destCell];
		if (pc.jumpstops) {
			if (df > 0) {
				if (dcn.Contains ("P"))
					++destCell;
				if (dcn.Contains ("G"))
					destCell = 17;
			} else {
				if (dcn.Contains ("P"))
					--destCell;
				if (dcn.Contains ("G"))
					destCell = 9;
			}
		}
		return destCell;
	}

	public string destCellName(int currentPos, int df) {
		PlayerController pc = currAvatar.GetComponent<PlayerController> ();
		int destCell = currentPos + df;
		string dcn = cellSequence [destCell];
		//print("cella di destinazione="+dcn);
		if (pc.jumpstops) {
			if (df > 0) {
				if (dcn.Contains ("P"))
					++destCell;
				if (dcn.Contains ("G"))
					destCell = 17;
			} else {
				if (dcn.Contains ("P"))
					--destCell;
				if (dcn.Contains ("G"))
					destCell = 9;
			}
		}
		if (currentPos == 10 && destCell == 9)
			destCell = 17;
		dcn = cellSequence [destCell];
		return dcn;
	}

	void movePlayer(int df) {
		PlayerController pc = currAvatar.GetComponent<PlayerController> ();
		pc.diceNumber = df;
		pc.forced = false;
		pc.jumpstops = true;
	}

	void forcedMovePlayer(int df, bool jumpstops) {
		PlayerController pc = currAvatar.GetComponent<PlayerController> ();
		pc.diceNumber = df;
		pc.forced = true;
		pc.jumpstops = jumpstops;
	}

	public void changeTurn() {
		// Change the player in turn
		if (currentTurn == 2 && numPlayers == 1)
			Invoke ("showTurnCard", 0.5f);
		else
			showTurnCard ();
	}

	public void showTurnCard () {
		ple.showTurnCard ();
	}

	public void changeTurnStep2() {
		// Change the player in turn
		PlayerController pc = currAvatar.GetComponent<PlayerController> ();
		if (currentTurn == 1) {
			currentTurn = 2;
			if(ple.ac1.enabled) {
				ple.ac1.enabled = false;
				ple.ac2.enabled = true;
				ple.mainCanvas.worldCamera = ple.ac2;
			}
			pc = avatarP2.GetComponent<PlayerController>();
		} else {
			currentTurn = 1;
			if(ple.ac2.enabled) {
				ple.ac1.enabled = true;
				ple.ac2.enabled = false;
				ple.mainCanvas.worldCamera = ple.ac1;
			}
			pc = avatarP1.GetComponent<PlayerController>();
		}
		ple.updateControlPanel ();
		if (pc.waitTurns == 0) {
			ple.diceEnabled = true;
//			ple.btnDice.interactable = true;
			if (currentTurn == 2 && numPlayers == 1) {
				Invoke ("hitDice",1.0f);
			}
		} else {
			ple.diceEnabled = false;
			ple.btnDice.interactable = false;
			Debug.Log ("Aspetta un turno!");
			pc.waitTurns=0;
			Invoke ("changeTurn",0.5f);
		}
	}
	
	void hitDice() {
		ple.hitDice ();
	}

	public GameObject getCurrAvatar() {
		return currAvatar;
	}

	public void updateStatus () {
		Debug.Log ("Chiamata l'update status");
		PlayerController pc = currAvatar.GetComponent<PlayerController> ();
		if (pc.currentPlace < cellSequence.Length-1) {
			// Get the current position of player controller and if necessary display questions or informations
			if (pc.currentPlace == 4 || pc.currentPlace == 8 || pc.currentPlace == 17 || pc.currentPlace == 22 || pc.currentPlace == 24 || pc.currentPlace == 27 || pc.currentPlace == 30 || pc.currentPlace == 34 || pc.currentPlace == 38 || pc.currentPlace == 41 || pc.currentPlace == 44 || pc.currentPlace == 48) {
				int cardType = 0;
				if(pc.currentPlace==4 || pc.currentPlace==22 || pc.currentPlace==44)
					cardType = 1;
				if(pc.currentPlace==8 || pc.currentPlace==24 || pc.currentPlace==34)
					cardType = 2;
				if(pc.currentPlace==17 || pc.currentPlace==30 || pc.currentPlace==41)
					cardType = 3;
				if(pc.currentPlace==27 || pc.currentPlace==38 || pc.currentPlace==48)
					cardType = 4;
				
				// Display questions and wait for answers
				ple.showQuestionCard(cardType);
				ple.updateControlPanel();
			} else if (pc.currentPlace == 5 || pc.currentPlace == 32) {
				// Display the antivirus card
				ple.showAVCard();
				pc.numAntivirus = pc.numAntivirus + 1;
				ple.updateControlPanel();
			} else if (pc.currentPlace == 20 || pc.currentPlace == 42) {
				// Display the virus card or the used antivirus card
				if(pc.numAntivirus>0) {
					pc.numAntivirus = pc.numAntivirus - 1;
					ple.updateControlPanel();
					ple.showAVCardBlock();
				} else {
					pc.waitTurns = 1;
					ple.showVirus();
				}
			} else if(pc.currentPlace==6 || pc.currentPlace==18 || pc.currentPlace==19 || pc.currentPlace==28 || pc.currentPlace==31 || pc.currentPlace==36 || pc.currentPlace==39 || pc.currentPlace==46 || pc.currentPlace==49) {
				ple.showLucky();
			} else if(pc.currentPlace==9 || pc.currentPlace==25 || pc.currentPlace==35 || pc.currentPlace==45) {
				ple.showProb();
			} else {
				changeTurn();
			}
		} else {
			ple.showFinish ();
		}
	}

	public void stayAside(int steps) {
		if (currentTurn == 1) {
			currAvatar = avatarP1;
		}
		if (currentTurn == 2) {
			currAvatar = avatarP2;
		}
		forcedMovePlayer(steps,false);
	}

	public void forcedMove(int steps) {
		if (currentTurn == 1) {
			currAvatar = avatarP1;
		}
		if (currentTurn == 2) {
			currAvatar = avatarP2;
		}
		forcedMovePlayer(steps,true);
	}

	public void playTurn(int diceFace) {
		if (currentTurn == 1) {
			currAvatar = avatarP1;
		}
		if (currentTurn == 2) {
			currAvatar = avatarP2;
		}
		movePlayer(diceFace);
	}

	public Vector3 getCellCoords(string cName) {
		Vector3 cellPos = new Vector3 (0, 0, 0);
		if (cName.Contains("M")) {
			string cellName = "/Percorso/" + cName;
			cellPos = GameObject.Find(cellName).transform.position;
		}
		if (cName.Contains("P")) {
			string cellName = "/Pause/" + cName;
			cellPos = GameObject.Find(cellName).transform.position;
		}
		if (cName.Contains("G")) {
			string cellName = "/GiroLungo/" + cName;
			cellPos = GameObject.Find(cellName).transform.position;
		}
		return cellPos;
	}

	// Funzione che restituisce la posizione in coordinate in base alla cella
	public Vector3 getCellCoords(int cell, int type) {
		Vector3 cellPos = new Vector3 (0, 0, 0);
		if (type == 1) {
			string cellName = "/Percorso/M" + cell.ToString("00");
			cellPos = GameObject.Find(cellName).transform.position;
		}
		if (type == 2) {
			string cellName = "/Pause/P" + cell.ToString("00");
			cellPos = GameObject.Find(cellName).transform.position;
		}
		if (type == 3) {
			string cellName = "/GiroLungo/G" + cell.ToString("00");
			cellPos = GameObject.Find(cellName).transform.position;
		}
		return cellPos;
	}

	// Change player avatar //Assegnazione Texture
	void selectTexture(GameObject p, string prefsName, int defaultColor) {
		int playerColor = PlayerPrefs.GetInt (prefsName,defaultColor);
		Texture pTexture=Resources.Load<Texture>("Textures/DiscoArancione");
		switch (playerColor) {
		case 1:
			pTexture = Resources.Load<Texture>("Textures/DiscoArancione");
			break;
		case 2:
			pTexture = Resources.Load<Texture>("Textures/DiscoCiano");
			break;
		case 3:
			pTexture = Resources.Load<Texture>("Textures/DiscoGiallo");
			break;
		case 4:
			pTexture = Resources.Load<Texture>("Textures/DiscoMagenta");
			break;
		case 5:
			pTexture = Resources.Load<Texture>("Textures/DiscoRosso");
			break;
		case 6:
			pTexture = Resources.Load<Texture>("Textures/DiscoVerde");
			break;
		}
		p.GetComponent<Renderer>().material.mainTexture = pTexture;
	}

	// Use this for initialization
	void Start () {
		// Change textures for the players
		selectTexture (player1, "p1color", 1);
		selectTexture (player2, "p2color", 2);
		// Retrieve the number of players
		numPlayers = PlayerPrefs.GetInt ("numplayers", 1);
	}
}
