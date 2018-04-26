using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    void Awake()
    {
        GameObject[] obs = GameObject.FindGameObjectsWithTag("Music");
        if (obs.Length > 1)
            Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
