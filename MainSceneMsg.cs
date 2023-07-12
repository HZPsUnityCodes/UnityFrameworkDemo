using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneMsg : MonoBase
{
    
    // Start is called before the first frame update
    void Start()
    {
        Bind(AreaCode.Record,RecordEventCode.Game_Record_save,RecordEventCode.Game_Record_read);
    }

    // Update is called once per frame
    public void MainSceneExitDispatch()
    {
        Debug.Log("MainSceneExitDispatch ������");
        Dispatch(AreaCode.Character, CharacterEventCode.To_Save_Character_Msg, null);
    }

    public void MainSceneLoadDispatch()
    {
        Debug.Log("MainSceneLoadDispatch ������ �ַ���ȡ�浵��Ϣ");
        Dispatch(AreaCode.Record,RecordEventCode.Game_Record_read,null);
   
    }

}
