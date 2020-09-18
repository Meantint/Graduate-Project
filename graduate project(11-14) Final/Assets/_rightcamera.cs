﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System.IO;

public class _rightcamera : MonoBehaviour
{
    [DllImport("rightOpencvDLLtest1")]
    public static extern bool checkWhite(ref Color32[] _img_bgr, int width, int height);
    public int white = 0;
    public Camera camera1;
    private RenderTexture targettexture;
    
    // Start is called before the first frame update
    void Start()
    {
        targettexture = camera1.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
        var texture = toTexture2D(targettexture);
        var image = texture.GetPixels32();
        if (checkWhite(ref image, texture.width, texture.height))
        {
            white = 1;
        }
        else
        {
            white = 0;
        }

        //Debug.Log("right" + white);
    }
    
    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGB24, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
