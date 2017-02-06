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

public class SkyboxCamera : MonoBehaviour {
	
	
	// set the main camera in the inspector
	public Camera MainCamera;
	public Camera ac1;
	public Camera ac2;
	
	// set the sky box camera in the inspector
	public Camera SkyCamera;

    // set the sky box camera in the inspector
    public Camera AgainstCamera;

    Rect norm = new Rect(0,0,1,1);
    Rect plus = new Rect(0.5F, 0, 1, 1);

    // the additional rotation to add to the skybox
    // can be set during game play or in the inspector
    public Vector3 SkyBoxRotation;
	
	// Use this for initialization
	void Start()
	{
		if (SkyCamera.depth >= MainCamera.depth)
		{
			Debug.Log("Set skybox camera depth lower "+
			          " than main camera depth in inspector");
		}
		if (MainCamera.clearFlags != CameraClearFlags.Nothing)
		{
			Debug.Log("Main camera needs to be set to dont clear" +
			          "in the inspector");
		}
	}
	
	// if you need to rotate the skybox during gameplay
	// rotate the skybox independently of the main camera
	public void SetSkyBoxRotation(Vector3 rotation)
	{
		this.SkyBoxRotation = rotation;
	}
	
	// Update is called once per frame
	void Update()
	{
		SkyBoxRotation.y += 0.01f;
		if(MainCamera.enabled)
		{
			SkyCamera.transform.position = MainCamera.transform.position;
			SkyCamera.transform.rotation = MainCamera.transform.rotation;
            SkyCamera.orthographic = MainCamera.orthographic; //Same Projection to avoid flickering
            AgainstCamera.rect = norm;
            if (MainCamera.orthographic)
                AgainstCamera.orthographic = false;
            else
                AgainstCamera.orthographic=true;

            Matrix4x4 p = AgainstCamera.projectionMatrix;
            SkyCamera.projectionMatrix = p;

        }
        else if(ac1.enabled)
		{
			SkyCamera.transform.position = ac1.transform.position;
			SkyCamera.transform.rotation = ac1.transform.rotation;
            SkyCamera.orthographic = ac1.orthographic;
            AgainstCamera.rect = plus;
            Matrix4x4 p = AgainstCamera.projectionMatrix;
            SkyCamera.projectionMatrix = p;
            //			print ("ac1");
        }
		else if(ac2.enabled)
		{
			SkyCamera.transform.position = ac2.transform.position;
			SkyCamera.transform.rotation = ac2.transform.rotation;
            SkyCamera.orthographic = ac2.orthographic;
            AgainstCamera.rect = plus;
            Matrix4x4 p = AgainstCamera.projectionMatrix;
            SkyCamera.projectionMatrix = p;
            //			print ("ac2");
        }
		SkyCamera.transform.Rotate(SkyBoxRotation);

	}
}

