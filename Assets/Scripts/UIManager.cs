using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer spriteRenderer;

    void Start()
    {
         
    }

    public void RandColor()
    {
        int rng = Random.Range(0, 4);

        spriteRenderer.color = rng switch
        {
            1 => Color.red,
            2 => Color.green,
            3 => Color.blue,
            4 => Color.white,
            _ => Color.black
        };


    }

    // Update is called once per frame
    void Update()
    {

    }
}
