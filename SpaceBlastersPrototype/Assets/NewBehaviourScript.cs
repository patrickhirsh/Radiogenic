using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

    int timtout = 11;
    double counter = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        counter += .02;
        Debug.Log(counter);
        if(counter >= timtout){
            SceneManager.LoadScene("Start Mewn");
        }
	}
}
