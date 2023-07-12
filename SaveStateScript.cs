using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveStateScript : MonoBase
{
    void Start()
    {
        Bind(AreaCode.Record, RecordEventCode.Game_Record_save,RecordEventCode.Game_Record_read);
    }

    void Update()
    {

    }
    public override void Execute(int eventCode, object message)
    {
        SaveScript saveMsg = (SaveScript)message;
        switch (eventCode)
        {
            case RecordEventCode.Game_Record_save:
                Debug.Log("保存Game_Record_save信息");
                
                CreateSave(saveMsg);          
                break;

            case RecordEventCode.Game_Record_read:
                Debug.Log("Game_Record_read");
                saveMsg = LoadByDeserialization();
                Dispatch(AreaCode.Character,CharacterEventCode.To_Read_Character_Msg, saveMsg);
                break;
        }


    }

    public void CreateSave(SaveScript saveMsg)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(Application.dataPath + "/Data.yj");
        bf.Serialize(fs, saveMsg);
        fs.Close();
        Debug.Log("成功保存");
    }


    private SaveScript LoadByDeserialization()
    {
        Debug.Log("开始读取");
        if (File.Exists(Application.dataPath + "/Data.yj"))
        //判断文件是否创建
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(Application.dataPath + "/Data.yj", FileMode.Open);//打开文件
            SaveScript save = bf.Deserialize(fs) as SaveScript;
            //反序列化并将数据储存至save（因为返回变量类型不对，所以要强制转换为Save类
            fs.Close();

            Debug.Log("成功读取");
            return save;
            //关文件流
        }
        else
        {
            Debug.Log("成功读取");

            return null;
        }
    }
}
