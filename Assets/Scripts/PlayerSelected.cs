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

public class PlayerSelected : MonoBehaviour {

	public float maxScale = 20.0f;

	private Vector3 startScale;
//	private float dirSpeed = +0.10f;
	private Vector3 startPos;
	private float   direction = +0.10f;
	
	// Use this for initialization
	void Start () {
		startScale = transform.localScale;
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentScale = transform.localScale;
		currentScale.x += 10.0f * Time.deltaTime;
		currentScale.z += 10.0f * Time.deltaTime;
		if (currentScale.x > maxScale)
			currentScale = startScale;
		transform.localScale = currentScale;

		Vector3 currentPos = transform.position;
		currentPos.y += direction * Time.deltaTime;
		float posY = Mathf.Abs (currentPos.y - startPos.y);
		if (posY >= 0.25) 
			direction = -direction;
		transform.position = currentPos;
	}
}
