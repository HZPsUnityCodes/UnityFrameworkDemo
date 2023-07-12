using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//管理全局

public class GameRoot : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameRoot Instance { get; private set; }

    public SceneSystem SceneSystem { get; private set; }

    private string nowSceneName;

    public GameObject scene2sceneMsgManager;

    public bool isReadOp = false;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;

        }
        else {
            Destroy(gameObject);
        }
        
        SceneSystem = new SceneSystem();

        DontDestroyOnLoad(gameObject);
    }


    void Start()
    {
        SceneSystem.SetScene(new StartScence());
        nowSceneName = SceneManager.GetActiveScene().name;
    }



    // Update is called once per frame
    void Update()
    {      
        if (nowSceneName != SceneManager.GetActiveScene().name) {
            nowSceneName = SceneManager.GetActiveScene().name;
            Debug.Log("nowSceneName改变一次");

            switch (nowSceneName) {
                case "MainScence":
                    scene2sceneMsgManager = GetManager("gameManager");
                    break;
            }

            if (isReadOp)
            {
                DisPatchReadMsg();
                isReadOp = false;
            }
        }


    }
    private GameObject GetManager(string name)
    {
        return GameObject.Find(name);
    }


    /// <summary>
    /// 读档操作
    /// </summary>
    private void DisPatchReadMsg() 
    {
        Debug.Log("输出一次");
        GameRoot.Instance.scene2sceneMsgManager.GetComponent<MainSceneMsg>().MainSceneLoadDispatch();
    }
}
