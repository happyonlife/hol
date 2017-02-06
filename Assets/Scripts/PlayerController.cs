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

public class PlayerController : MonoBehaviour {

	public int currentPlace = 0;
	public int diceNumber = 0;

	public Vector3 destination;
	public Vector3 startPos;

	public GenericUtils gu;

	public float   interPolationPos = 0.0f;
	public float   originalY = 0.0f;

	public int		currentScore = 0;
	public int		numAntivirus = 0;
	public int 		waitTurns = 0;
	public int[]	pcOwned = new int[6] {0,0,0,0,0,0};

	public bool 	forced = false;
	public bool 	jumpstops = true;

	private bool inMovement = false;

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		destination = startPos;
		originalY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (diceNumber != 0 || transform.position!=destination) {
			inMovement = true;
			// if the diceNumber i greather than 0 it will be decreased until it reach it and the avatart will be moved
			if (transform.position != destination) 
			{
				interPolationPos = interPolationPos + Time.deltaTime;
				transform.position = Vector3.Lerp (startPos, destination, interPolationPos);
			} 
			else 
			{
				int diffValue=1;
				if(currentPlace>=10 && currentPlace<=16) 
				{
					--diceNumber;
					diffValue=-1;
					jumpstops=false;
				} 
				else 
				{
					if(diceNumber>0) 
					{
						--diceNumber;
						jumpstops=true;
					}
					if(diceNumber<0) 
					{
						++diceNumber;
						diffValue = -1;
					}
				}
				startPos = transform.position;
				string dcn = gu.destCellName (currentPlace, diffValue);
				destination = gu.getCellCoords (dcn);
				destination.y += originalY;
				currentPlace = gu.destCellNum (currentPlace, diffValue);
				interPolationPos = 0.0f;
			}
		} 
		else 
		{
			if(inMovement && transform.position==destination) 
			{
				if(currentPlace==11 || currentPlace==13 || currentPlace==15) 
				{
					string dcn = "M10";
					currentPlace = 19;
					destination = gu.getCellCoords (dcn);
					destination.y += originalY;
					interPolationPos = 0.0f;
				} 
				else 
				{
					inMovement = false;
					gu.updateStatus();
				}
			}
		}
	}

}
