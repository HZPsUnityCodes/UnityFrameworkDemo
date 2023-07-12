using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgkContoller : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;


    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;

        lastCameraPosition = cameraTransform.position;

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;

        Texture2D texture = sprite.texture;
        textureUnitSizeX = (texture.width / sprite.pixelsPerUnit);//sprite不可以被拉伸过

        Debug.Log(textureUnitSizeX);
    }

    // Update is called once per frame
    void LateUpdate()
    {

    
        Vector3 deltamovement = cameraTransform.position-lastCameraPosition  ;
        

        transform.position += new Vector3(deltamovement.x * parallaxEffectMultiplier.x, deltamovement.y* parallaxEffectMultiplier.y, deltamovement.z)  ;
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) {
            float offsetPositionX = (cameraTransform.position.x- transform.position.x ) %textureUnitSizeX;
            transform.position = new Vector3(cameraTransform.position.x - offsetPositionX, transform.position.y, transform.position.z);
        }
    }
}



