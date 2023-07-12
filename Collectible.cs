using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBase
{
    // Start is called before the first frame update
    void Start()
    {
        Bind(AreaCode.Game,CharacterEventCode.Change_Player_health);       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController2D pc = collision.GetComponent<PlayerController2D>();
        if (pc != null)
        {
            Debug.Log("��������˲�ݮ���� ");
            Dispatch(AreaCode.Character, CharacterEventCode.Change_Player_health, 1);
            Debug.Log("��ݮ�����ˣ��� ");
            Destroy(this.gameObject);

        }
    }
}
