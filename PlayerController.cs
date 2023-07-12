using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horziontal = Input.GetAxis("Horizontal");

        Vector3 dir = new Vector3(horziontal, 0, vertical);
        if (dir != Vector3.zero) {
            transform.Translate(dir * 3 * Time.deltaTime);
        }
    }
}
