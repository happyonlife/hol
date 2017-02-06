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

public class CameraRotationCustom : MonoBehaviour {
	
	public GameObject container;
	public GenericUtils gu;
	bool down = false;
	Vector3 clickPoint;
	Vector3 nowPoint;
	Vector3 newRot;
	Vector3 origRot;
	public bool v2d=false;
	public bool v3d=false;
	
	void Start () 
	{
		origRot = container.transform.rotation.eulerAngles;
		newRot = container.transform.rotation.eulerAngles;
	}
	void Update ()
	{
		if (down) 
		{
				nowPoint = Input.mousePosition;
				float diff = nowPoint.x - clickPoint.x;
				float rotY = newRot.y + diff / 20;
				container.transform.rotation = Quaternion.Euler (new Vector3 (container.transform.rotation.x, rotY, container.transform.rotation.z));
		} 
		else if (gu.gameBoardRotation)
		{
			container.transform.Rotate (0, 1 * Time.deltaTime, 0);
		}
		if (v2d) 
		{
			container.transform.rotation=Quaternion.Euler(origRot);
			v2d=false;
		}
		if (v3d) 
		{
			container.transform.rotation=Quaternion.Euler(newRot);
			v3d=false;
		}
	}
	
	void OnMouseDown()
	{
		down=true;
		clickPoint = Input.mousePosition;
		newRot = container.transform.rotation.eulerAngles;
	}
	
	void OnMouseUp()
	{
		down = false;
		newRot = container.transform.rotation.eulerAngles;
	}
}