using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _frontfrontcolider : MonoBehaviour
{
    public int frontfront = 0;
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
        frontfront = 1;
    }
    void OnTriggerExit(Collider col)
    {
        frontfront = 0;
    }
}
