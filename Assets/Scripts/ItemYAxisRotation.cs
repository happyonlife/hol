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

public class ItemYAxisRotation : MonoBehaviour {

	//private float dirSpeed = +0.10f;
	private Vector3 startPos;
	private float   direction = +0.10f;
    public int numDisk = 0;

	// Use this for initialization
	void Start () {

        startPos = transform.position;

        switch (numDisk)
        {
            case 1:
                transform.position = new Vector3(transform.position.x, transform.position.y+0, transform.position.z);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.10f, transform.position.z);
                break;
            case 3:
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.20f, transform.position.z);
                break;
            case 4:
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.01f, transform.position.z);
                break;
            case 5:
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.10f, transform.position.z);
                break;
            case 6:
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.20f, transform.position.z);
                break;
        }
        if (transform.position.y < startPos.y)
            direction = -direction;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPos = transform.position;
		currentPos.y += direction * Time.deltaTime;
		float posY = Mathf.Abs (currentPos.y - startPos.y);
		if (posY >= 0.25) 
			direction = -direction;
		transform.position = currentPos;
		transform.Rotate(0,20*Time.deltaTime,0);
	}
}
