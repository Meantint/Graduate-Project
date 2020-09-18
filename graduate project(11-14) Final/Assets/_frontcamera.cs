using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;
using System.IO;

public class _frontcamera : MonoBehaviour
{
    [DllImport("frontOpencvDLL")]
    public static extern int checkTrafficLight(ref Color32[] _img_bgr, int width, int height);
    public Camera camera3;
    public int check = -1;
    private RenderTexture targettexture;

    // Start is called before the first frame update
    void Start()
    {
        targettexture = camera3.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        var texture = toTexture2D(targettexture);
        var image = texture.GetPixels32();
        check = checkTrafficLight(ref image, texture.width, texture.height);
        /*
        if (check == 1)
        {
            Debug.Log("1, green");
        }
        else if (check == 2)
        {
            Debug.Log("2, red");
        }
        else if (check == 3)
        {
            Debug.Log("3, shit");
        }
        else
        {
            Debug.Log("4, ???");
        }
        */
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
