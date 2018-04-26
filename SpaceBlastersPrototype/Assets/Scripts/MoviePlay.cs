using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoviePlay : MonoBehaviour {

	// Use this for initialization

    public MovieTexture movTexture;
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = movTexture;
        movTexture.Play();
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
