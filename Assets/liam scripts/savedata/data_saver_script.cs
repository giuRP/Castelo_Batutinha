using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class data_saver_script 
{
    


    //no idea what goes on here tbh
    

    public static void savedata(actual_save_data actualactualsave)
    { 
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/yeetsave.data";
        FileStream stream = new FileStream(path, FileMode.Create);

        actual_save_data data = new actual_save_data(actualactualsave);


        formatter.Serialize(stream, data);
        stream.Close();//always needs to close when calling these wierd binary data creating shit
     


    }

    public static actual_save_data loadsavedata()
    {
        string path = Application.persistentDataPath + "/yeetsave.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            actual_save_data newdata = formatter.Deserialize(stream) as actual_save_data;

            stream.Close();



            return newdata;
        }
        else 
        {
            Debug.Log("Save file not found in " + path);
            return null;                
        }

        


    }


}
