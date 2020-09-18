using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _rightcollider : MonoBehaviour{
    public int right = 0;
    // Use this for initialization
    void Start()    {

    }
    // Update is called once per frame
    void Update()    {

    }
    void OnTriggerStay(Collider col)
    {
        right = 1;
    }
    void OnTriggerExit(Collider col)
    {
        right = 0;
    }
}
