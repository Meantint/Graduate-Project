using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _frontcolider : MonoBehaviour
{
    public int front = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider col)
    {
        front = 1;
    }
    void OnTriggerExit(Collider col)
    {
        front = 0;
    }
}
