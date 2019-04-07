using UnityEngine;
using System.Collections;
using System.IO;

public class TextReader : MonoBehaviour 
{
    public string[] wordList;
    public static bool b_init = false;

    public void LoadText(string fileURL)
    {
        if (!b_init)
        {
            TextAsset data = Resources.Load("TextFile/" + fileURL, typeof(TextAsset)) as TextAsset;
            StringReader sr = new StringReader(data.text);

            wordList = new string[150];

            for (int i = 0; i < 150; i++)
            {
                string word = sr.ReadLine();
                wordList[i] = word;
            }
            b_init = true;
        }

        else
            return;
    }
}
