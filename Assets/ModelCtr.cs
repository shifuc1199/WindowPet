using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelCtr : MonoBehaviour
{
    Vector3 offset;
    bool isMouseEnter = false;
    private void Awake()
    {
    }
   
    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z)));

    }
 
    private void OnMouseOver()
    {
       if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            UIManager._instance.SettingMenu.SetActive(true);
        }
        
    }
    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Mathf.Abs(Camera.main.transform.position.z))) +offset;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            transform.Rotate(0, -Input.GetAxis("Mouse X")*10, 0);
        }
        transform.localScale = new Vector3(transform.lossyScale.x + Input.mouseScrollDelta.y * Time.fixedDeltaTime*3, transform.lossyScale.y + Input.mouseScrollDelta.y * Time.fixedDeltaTime*3, transform.lossyScale.z + Input.mouseScrollDelta.y * Time.fixedDeltaTime * 3);
    }
}
