using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class Dialogue_Database : MonoBehaviour
{
    //This is where the database is stored in volatile memory.
    string[] LoadedVolatileDatabase;
    public static string VolatileString;
    public static bool FoundKeyword = false;
    public static bool IsReading = false;
    
    void Start()
    {
        //This is for example. If you want to test this script, uncomment the following line.
        //ReadFromTextDatabase("./Assets/scripts/Dialogue_Control_V2/DatabaseTextFiles/DialogueDatabaseNonVolatile.txt", '@', 1, false, "Null");
    }

    // This is used to read the data from a file.
    // Path is used to input the complete path of the text file. I.E. "./Assets/scripts/Dialogue_Control_V2/DatabaseTextFiles/DialogueDatabaseNonVolatile.txt"
    // DelimiterInp is used to decide what character you want the delimiter to be. This is syntax, and should be universal.
    public void ReadFromTextDatabase(string Path, char delimiterInp, int Line, bool SearchKeywords, string KeywordSearchInp)
    {
        IsReading = true;
        //Create a new streamreader.
        StreamReader reader = new StreamReader(Path); 
        //Create the reader.
        string itemStrings = reader.ReadLine();
        //Begin reading.
        while (itemStrings != null)
        {
            LoadedVolatileDatabase = itemStrings.Split(delimiterInp);

            //These next few lines are just used for displaying the database to Debug log.
            for (int i = 0; i < LoadedVolatileDatabase.Length; i++)
            {
                Debug.Log("Primary key is " + i + ". The data is " + LoadedVolatileDatabase[i]);
            }

            itemStrings = reader.ReadLine();
        }

        //Load the specified array index to a volatile memory module.
        VolatileString = LoadedVolatileDatabase[Line];

        //This next line searches for the specified keyword.
        //Limitations: Can only search for one keyword.
        if(SearchKeywords == true)
        {
            if(VolatileString.Contains(KeywordSearchInp) == true)
            {
                //Return that we have found it to be true.
                FoundKeyword = true;
                //Remove the keyword from the string.
                VolatileString = VolatileString.Replace(KeywordSearchInp, "");
            } else
            {
                //Otherwise, it's false.
                FoundKeyword = false;
            }
        }

    }



    

}