using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficlight : MonoBehaviour
{
    
    
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat.color = Color.black;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Timee = Timee + Time.deltaTime;
        if (Timee % 10 < 5 && Timee % 10 > 0)
        {
            mat.color = Color.red;
        }
        else
        {
            mat.color = Color.green;
        }
        */
        if(Input.GetKey("r"))
        {
            mat.color = Color.red;
        }
        if (Input.GetKey("g"))
        {
            mat.color = Color.green;
        }
    }
}
