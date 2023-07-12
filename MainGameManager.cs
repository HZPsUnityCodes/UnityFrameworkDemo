using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBase
{

    public bool isPause = false;
    // Start is called before the first frame update
    void Start()
    {
        Bind(AreaCode.Record, RecordEventCode.GamePause, RecordEventCode.GameResume);
    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case RecordEventCode.GamePause:
                gamePause();
                break;
            case RecordEventCode.GameResume:
                gameResume();
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseDispatch()
    {
        Dispatch(AreaCode.Record, RecordEventCode.GamePause,null);
    }

    public void ResumeDispatch()
    {
        Dispatch(AreaCode.Record, RecordEventCode.GameResume, null);
    }

    public void gamePause() 
    {
        Time.timeScale = 0.0f;
        isPause = true;

    }

    public void gameResume()
    {
        Time.timeScale = 1.0f;
        isPause = false;
    }

}
