using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArPaintController : MonoBehaviour
{
    public GameObject paintPrefab;
    GameObject paintInstance;
    
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Vector2 touchPos = Input.GetTouch(0).position;
            Vector3 worldPos = Camera.current.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, 2f));

            if(paintInstance == null)
            {
                paintInstance = Instantiate(paintPrefab, worldPos, Quaternion.identity);
            }

            paintInstance.transform.position = worldPos;
        }
        else
        {
            paintInstance = null;
        }
    }
}