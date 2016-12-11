using UnityEngine;
using System.IO;
using System.Collections;

public class CreateMaskShader : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        int width = 128;
        int height = 128;
        Texture2D tex = new Texture2D(width, height);
        for(int i =0; i<width; i++)
        {
            for(int j = 0; j<height; j++)
            {
                float randomAlpha = (float)Random.Range((int)0,(int)2);
                tex.SetPixel(i,j,new Color(1f,0f,0f,randomAlpha));
            }
        }

        // Read screen contents into the texture
        //tex.ReadPixels( new Rect( 0 , 0 , width , height ) , 0 , 0 );
        tex.Apply();

        // Encode texture into PNG
        byte[] bytes = tex.EncodeToPNG();
        //Object.Destroy( tex );

        // For testing purposes, also write to a file in the project folder
        File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
