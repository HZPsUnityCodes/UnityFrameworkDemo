using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveTest : MonoBehaviour
{
    public SaveScript saveTest;
    // Start is called before the first frame update
    void Start()
    {
        SaveScript saveTest = new SaveScript(2,3,4f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        CreateSave(saveTest);
    }

    public void CreateSave(SaveScript saveMsg)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.dataPath + "/Data.yj");
        bf.Serialize(fs, saveMsg);
        fs.Close();
        Destroy(this);
    }
}
