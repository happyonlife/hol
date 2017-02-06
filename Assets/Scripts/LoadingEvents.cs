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
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadingEvents : MonoBehaviour {

	// 0=VC
	// 1=Others

	public int versionType = 0;
	public Image logoEC;

	private string expPath;
//	private bool downloadStarted = false;

	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll();
        Screen.fullScreen = true;
		if (versionType == 0)
			logoEC.enabled = false;
		else
			logoEC.enabled = true;
		Invoke ("loadNextLevel", 0.5f);	
	}

	public void loadNextLevel() 
	{
		PlayerPrefs.SetInt ("versionType", versionType);
		if (versionType == 0) 
		{
			//Application.LoadLevel ("Disclaimer");
			SceneManager.LoadScene("Disclaimer");
		} 
		else if (versionType == 1) 
		{
			//Application.LoadLevel ("Disclaimer");
			SceneManager.LoadScene("Disclaimer");
		} 
        /*
		else if (versionType == 2) 
		{
			//Application.LoadLevel ("Disclaimer2");
			SceneManager.LoadScene("Disclaimer2");
		}*/
	}

}
