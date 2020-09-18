using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _leftcollider : MonoBehaviour {
    public int left = 0;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerStay(Collider col)
    {
        left = 1;
    }
    void OnTriggerExit(Collider col)
    {
        left = 0;
    }
}
