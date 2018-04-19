using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class setAsTime : MonoBehaviour {
    Text text;
    float timer = 0;

	// Use this for initialization
	void Start () {
        

	}
    void Awake()
    {
        text = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        text.text = "Time " + Time.time.ToString();

	}
}
