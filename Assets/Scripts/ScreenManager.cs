using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    int width;
    int height;

    public void SetWidth(int width)
    {
        this.width = width;
    }

    public void SetHeight(int height)
    {
        this.height = height;
    }

    public void SetResolution()
    {
        Screen.SetResolution(width, height, fullscreen: false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
