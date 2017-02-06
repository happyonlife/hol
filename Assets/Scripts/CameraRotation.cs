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

public class CameraRotation : MonoBehaviour {

	/*
	 * Properties:
	 * 
	 * gu : Pointer to the instance of GenericUtils
	 * 
	 */
	public GenericUtils gu;

	// Use this for initialization
	void Start () {
	
	}
	
	/*
	 * The function checks if the gu.gameBoardRotation is true, and if affirmative then the CameraRotator object is rotated o2 2 degrees per second along y axis.
	 * Else the rotation is stopped and the y axis rotation is set to 0.
	 * 
	 */
	void Update () {
		if (gu.gameBoardRotation)
			transform.Rotate (0, 2 * Time.deltaTime, 0);
		else {
			Quaternion rot = transform.rotation;
			rot.y = 0.0f;
			transform.rotation = rot;
		}
	}
}
