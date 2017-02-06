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

public class CameraMove : MonoBehaviour {

	private const float linearSpeed = 10.0f;
	private const float rotationSpeed = 10.0f;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(0, 0.75f, -10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		float dirX = 0.0f;
		float dirY = 0.0f;
		float dirZ = 0.0f;
		float rotX = 0.0f;
		float rotY = 0.0f;

		// Prova a leggere l'input da tastiera
		if (Input.GetAxis("Horizontal")<0) {
			dirX = -1.0f * Time.deltaTime;
		}
		if (Input.GetAxis("Horizontal")>0) {
			dirX = 1.0f * Time.deltaTime;
		}
		if (Input.GetAxis("Vertical")>0) {
			dirY = 1.0f * Time.deltaTime;
		}
		if (Input.GetAxis("Vertical")<0) {
			dirY = -1.0f * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.O)) {
			dirZ = 1.0f * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.L)) {
			dirZ = -1.0f * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.Y)) {
			rotX = -1.0f * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.H)) {
			rotX = 1.0f * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.G)) {
			rotY = -1.0f * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.J)) {
			rotY = 1.0f * Time.deltaTime;
		}

		// Una volta letto l'input dell'utente provvede ad aggiornare la posizione del giocatore sullo schermo
        //Once read it, user input updates ufo's position
		dirX *= linearSpeed;
		dirY *= linearSpeed;
		dirZ *= linearSpeed;
		transform.Translate (dirX, dirY, dirZ);
		rotX *= rotationSpeed;
		rotY *= rotationSpeed;
		transform.Rotate (rotX, rotY, 0.0f);
	}
}
