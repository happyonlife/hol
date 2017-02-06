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

public class RingMovement : MonoBehaviour {

	public float maxScale = 20.0f;
	
	private Vector3 startScale;
	public GameObject myDisk;

	// Use this for initialization
	void Start () {
		startScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentScale= transform.localScale;
		currentScale.x += 5.0f * Time.deltaTime;
		currentScale.z += 5.0f * Time.deltaTime;
		if (currentScale.x > maxScale)
			currentScale = startScale;
		transform.localScale = currentScale;

		Vector3 currentPos = myDisk.transform.position;
		currentPos.y += -0.185f;
		currentPos.z += -0.081f;
		transform.position = currentPos;
	}
}
