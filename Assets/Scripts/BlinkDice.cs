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

public class BlinkDice : MonoBehaviour {

	/*
	 * Class properties:
	 * 
	 * rt : retain the current transform rect of the dice frame
	 * img: point to the frame image
	 * gu : Contains the pointer to the GenericUtils instance which is one for the level
	 * ple: Contains the pointer to the PlayLevelEvents instance which is connected to the MainCamera
	 * 
	 */
	public RectTransform rt;
	public Image img;
	public GenericUtils gu;
	public PlayLevelEvents ple;
	Color c;
	Vector3 cs;

	float lerpTime = 1f;
	float currentLerpTime=0.75f;
	//float perc;
	bool on=false;
	/*
	 *  Sets the localScale of the frame to the single unit scale
	 * 
	 */
	void Start () 
	{
		rt.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
		c = img.color;
		cs = rt.localScale;
	}
	
	/*
	 * This function manage the dice blinking
	 * First of all it checks if the dice is disabled or is the computer turn, if true the blinking is disabled
	 * Else it checks if the localScale of the rt property is grater then 1.2 if true the scale is reduced to 0.9 and the img alpha channel is set to 1
	 * Otherwise the scale is increased of step 0.3 per second and the alpha channel of img is descreased 1.0 step per second.
	 */
	void Update () {
		if (!ple.diceEnabled || (gu.currentTurn==2 && gu.numPlayers==1)) 
		{
			img.enabled = false;
		} 
		else 
		{
			//comment below for W8.1
			img.enabled = true;
			if (cs.x >= 1.2f) 
			{
				cs = new Vector3 (0.9f, 0.9f, 1.0f);
				rt.transform.localScale = cs;
				c.a = 1.0f;
				img.color = c;
			} 
			else 
			{
				cs.x += 0.3f * Time.deltaTime;
				cs.y += 0.3f * Time.deltaTime;
				rt.transform.localScale = cs;
				c.a -= 1.0f * Time.deltaTime;
				img.color = c;
			}
			//comment below for other OS
//			currentLerpTime += Time.deltaTime;
//			if (currentLerpTime > lerpTime) 
//			{
//				currentLerpTime = 0.75f;
//				if(on)
//				{
//					on=false;
//					img.enabled = false;
//				}
//				else
//				{
//					on=true;
//					img.enabled = true;
//				}
//			}
		}
	}
}
/* INTERPOLATION

//VAR
float lerpTime = 1f;
float currentLerpTime;
float perc;
//UPDATE
perc = currentLerpTime / lerpTime;

currentLerpTime += Time.deltaTime;
if (currentLerpTime > lerpTime) 
{
	currentLerpTime = 0.0f;
	//				cs = new Vector3 (0.8f, 0.8f, 1.0f);
	//				rt.localScale = cs;
	c.a = 1.0f;
	img.color = c;
}

cs.x = Mathf.Lerp(0.8f, 1.2f, perc);
cs.y = Mathf.Lerp(0.8f, 1.2f, perc);
rt.localScale = cs;
c.a = Mathf.Lerp(1.0f, 0.0f, perc);
img.color = c;

*/