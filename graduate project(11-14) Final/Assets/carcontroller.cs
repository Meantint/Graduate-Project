using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour {
    // Use this for initialization
    /* 화면 프레임 단위 캡쳐
    public string folder = "ScreenshotFolder";
    public int frameRate = 25;
    */
    public float maxTorque = 250f;
    public WheelCollider[] wheelColliders = new WheelCollider[4];
    public Transform[] tiremesh = new Transform[4];
    public Transform CenterOfMass;
    public float brakeForce = 1500f;
    public float speed = 0f;
    public int right = 0;
    public int left = 0;
    public int rightwhite = 0;
    public int leftwhite = 0;
    public int front = 0;
    public int frontfront = 0;
    public int traffic = 0;

  
    private Rigidbody m_rigidbody;

    void Start () {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.centerOfMass = CenterOfMass.localPosition;
        /*  화면 프레임 단위 캡쳐
        Time.captureFramerate = frameRate;
        System.IO.Directory.CreateDirectory(folder);
        */
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Updatemeshposition();
        //string name = string.Format("{0}/{1:D04} shot.png", folder, Time.frameCount);
        //ScreenCapture.CaptureScreenshot(name);
        _frontcamera _frontcamera = GameObject.Find("frontcamera").GetComponent<_frontcamera>();
        _rightcollider _rightcollider = GameObject.Find("rightcollider").GetComponent<_rightcollider>();
        _leftcollider _leftcollider = GameObject.Find("leftcollider").GetComponent<_leftcollider>();
        _rightcamera _rightcamera = GameObject.Find("rightcamera").GetComponent<_rightcamera>();
        _leftcamera _leftcamera = GameObject.Find("leftcamera").GetComponent<_leftcamera>();
        _frontcolider _frontcolider = GameObject.Find("frontcolider").GetComponent<_frontcolider>();
        _frontfrontcolider _frontfrontcolider = GameObject.Find("frontfrontcolider").GetComponent<_frontfrontcolider>();

        traffic = _frontcamera.check;
        right = _rightcollider.right;
        left = _leftcollider.left;
        rightwhite = _rightcamera.white;
        leftwhite = _leftcamera.white;
        front = _frontcolider.front;
        frontfront = _frontfrontcolider.frontfront;
    }
    void FixedUpdate()
    {
        float steer = Input.GetAxis("Horizontal");
        float accelerate = Input.GetAxis("Vertical");
        float finalAngle = steer * 15f;
        // drive manually
        /*
        wheelColliders[0].steerAngle = finalAngle;
        wheelColliders[1].steerAngle = finalAngle;

        
        for (int i=2;i<4;i++)
        {
            wheelColliders[i].motorTorque = accelerate * maxTorque;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            for(int i=0;i<4;i++)
            {
                wheelColliders[i].brakeTorque = brakeForce;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            for (int i = 0; i < 4; i++)
            {
                wheelColliders[i].brakeTorque = 0;
            }
        }
        */
        if (traffic == 2)
        {
            Debug.Log("2, red");
        }
        driveautomatically();
        keepline();
    }

    void Updatemeshposition()
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion quat;
            Vector3 pos;
            wheelColliders[i].GetWorldPose(out pos, out quat);

            tiremesh[i].position = pos;
            tiremesh[i].rotation = quat;
        }
    }

    float getvelocity()
    {
        speed = m_rigidbody.velocity.magnitude;
        return speed;
    }

    void driveautomatically()
    {
        if (front == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                wheelColliders[i].brakeTorque = brakeForce * 7;
            }
        }
        else if (frontfront == 1)
        {
            for (int i = 0; i < 4; i++)
            {
                wheelColliders[i].brakeTorque = brakeForce * 4;
            }
        }
        else if (traffic == 2)
        {
            if (getvelocity() > 0.001f)
            {
                for (int i = 0; i < 4; i++)
                {
                    wheelColliders[i].brakeTorque = brakeForce;
                }
            }
            
        }
        else
        {
            if (getvelocity() < 4.5f)
            {
                for (int i = 2; i < 4; i++)
                {
                    wheelColliders[i].motorTorque = maxTorque;
                }
            }
            if (getvelocity() >= 4.5f)
            {
                for (int i = 0; i < 4; i++)
                {
                    wheelColliders[i].brakeTorque = brakeForce;
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    wheelColliders[i].brakeTorque = 0;
                }
            }
        }
        
    }
    
    void keepline()
    {
        if (right == 1)
        {
            wheelColliders[0].steerAngle = -4f;
            wheelColliders[1].steerAngle = -4f;
        }
        else if (left == 1)
        {
            wheelColliders[0].steerAngle = 4f;
            wheelColliders[1].steerAngle = 4f;
        }
        else if (rightwhite == 1)
        {
            wheelColliders[0].steerAngle = -2f;
            wheelColliders[1].steerAngle = -2f;
        }
        else if (leftwhite == 1)
        {
            wheelColliders[0].steerAngle = 2f;
            wheelColliders[1].steerAngle = 2f;
        }
        else
        {
            wheelColliders[0].steerAngle = 0f;
            wheelColliders[1].steerAngle = 0f;
        }
    }
}
