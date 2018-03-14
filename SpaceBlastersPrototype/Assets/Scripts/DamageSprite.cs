using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSprite : MonoBehaviour {

    public float timer;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (timer >= 0.0f){
            timer -= .001f;
        }
        else{
            this.gameObject.SetActive(false);
            timer = .01f;
        }
	}
}
