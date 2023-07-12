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
            Debug.Log("Íæ¼ÒÅöµ½ÁË²ÝÝ®£¡£¡ ");
            Dispatch(AreaCode.Character, CharacterEventCode.Change_Player_health, 1);
            Debug.Log("²ÝÝ®±»³ÔÁË£¡£¡ ");
            Destroy(this.gameObject);

        }
    }
}
