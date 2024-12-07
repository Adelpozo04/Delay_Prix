using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateProcedural : MonoBehaviour
{

    [SerializeField] private GameObject tree_;
    [SerializeField] private GameObject rocks_;
    [SerializeField] private GameObject specialBuilding_;

    [SerializeField] private Color[,] colorOfPixel_;
    [SerializeField] private Texture2D outlineImage_;
    [SerializeField] private TextAsset outlineText_;

    [SerializeField] private float offset_;

    void Start()
    {
        GenerateFromFile();
        //GenerateFromImage();

    }

    void GenerateFromFile()
    {
        string s = outlineText_.text;
        int i;
        s = s.Replace(System.Environment.NewLine, "");

        for (i = 0; i < s.Length; i++)
        {
            int nColumns_ = i % 10;
            int nRows_ = i / 10;
            if (s[i] == '1')
            {
               Instantiate(tree_, new Vector3(transform.position.x - nColumns_ * offset_, transform.position.y, transform.position.z - nRows_ * offset_), Quaternion.identity);
            }
            else if (s[i] == '2')
            {
                Instantiate(rocks_, new Vector3(transform.position.x - nColumns_ * offset_, transform.position.y, transform.position.z - nRows_ * offset_), Quaternion.identity);
            }
            else if (s[i] == '3')
            {
                Instantiate(specialBuilding_, new Vector3(transform.position.x - nColumns_ * offset_, transform.position.y, transform.position.z - nRows_ * offset_), Quaternion.identity);
            }

        }
    }

    void GenerateFromImage()
    {

        colorOfPixel_ = new Color[outlineImage_.width, outlineImage_.height];

        for (int x = 0; x < outlineImage_.width; x++)
        {
            for (int y = 0; y < outlineImage_.height; y++)
            {

                colorOfPixel_[x, y] = outlineImage_.GetPixel(x, y);

                if (colorOfPixel_[x, y] == Color.green)
                {
                    Debug.Log("Green");
                    Instantiate(tree_, new Vector3((transform.position.x / 2 * 1) - x * offset_, transform.position.y, (transform.position.z / 2 * 1) - y * offset_), Quaternion.identity);
                }
                else if (colorOfPixel_[x, y] == Color.blue)
                {
                    Instantiate(rocks_, new Vector3((transform.position.x / 2 * 1) - x * offset_, transform.position.y, (transform.position.z / 2 * 1) - y * offset_), Quaternion.identity);
                }
                else if (colorOfPixel_[x, y] == Color.red)
                {
                    Instantiate(specialBuilding_, new Vector3((transform.position.x / 2 * 1) - x * offset_, transform.position.y, (transform.position.z / 2 * 1) - y * offset_), Quaternion.identity);
                }

            }
        }


    }




    // Update is called once per frame
    void Update()
    {

    }
}
