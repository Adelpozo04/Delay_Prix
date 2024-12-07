using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateProcedural : MonoBehaviour
{

    [SerializeField] private GameObject tree_;
    [SerializeField] private GameObject rocks_;
    [SerializeField] private GameObject specialBuilding_;

    Color[,] colorOfPixel;
    public Texture2D outlineImage;

    int column, row;
    GameObject t;

    void Start()
    {
        //GenerateFromFile();
        GenerateFromImage();

    }

    void GenerateFromFile()
    {
        TextAsset t1 = (TextAsset)Resources.Load("atrezzo", typeof(TextAsset));
        string s = t1.text;
        int i;
        s = s.Replace(System.Environment.NewLine, "");

        for (i = 0; i < s.Length; i++)
        {
            column = i % 10;
            row = i / 10;
            if (s[i] == '1')
            {
                t = (GameObject)(Instantiate(wall, new Vector3(50 - column * 10, 1.5f, 50 - row * 10), Quaternion.identity));
            }


            if (s[i] == '2')
            {

                t = (GameObject)(Instantiate(target, new Vector3(50 - column * 10, 1.5f, 50 - row * 10), Quaternion.identity));
                t.name = "target";
            }

            if (s[i] == '3')
            {

                t = (GameObject)(Instantiate(NPC, new Vector3(50 - column * 10, 1.5f, 50 - row * 10), Quaternion.identity));
            }

        }
    }

    void GenerateFromImage()
    {

        colorOfPixel = new Color[outlineImage.width, outlineImage.height];

        for (int x = 0; x < outlineImage.width; x++)
        {
            for (int y = 0; y < outlineImage.height; y++)
            {
                colorOfPixel[x, y] = outlineImage.GetPixel(x, y);
                float r, g, b;
                r = colorOfPixel[x, y].r;
                g = colorOfPixel[x, y].g;
                b = colorOfPixel[x, y].b;
                if (g > 0.9) print("some green detected");
                //print("RGB="+r+"."+b+"."+b);


                if (colorOfPixel[x, y] == Color.black)
                {

                    GameObject t = (GameObject)(Instantiate(smallerWall, new Vector3((outlineImage.width / 2 * 1) - x * 1, 1.5f, (outlineImage.height / 2 * 1) - y * 1), Quaternion.identity));

                }




                else if (colorOfPixel[x, y] == Color.blue)
                {
                    GameObject t = (GameObject)(Instantiate(smallWater, new Vector3((outlineImage.width / 2 * 1) - x * 1, -1.0f, (outlineImage.height / 2 * 1) - y * 1), Quaternion.identity));
                }

                else if (colorOfPixel[x, y] == Color.red)
                {
                    GameObject t = (GameObject)(Instantiate(tree, new Vector3((outlineImage.width / 2 * 1) - x * 1, 2.0f, (outlineImage.height / 2 * 1) - y * 1), Quaternion.identity));

                }




            }
        }


    }




    // Update is called once per frame
    void Update()
    {

    }
}
