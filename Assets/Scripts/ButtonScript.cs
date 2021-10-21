using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Mirror;
using System;

public class ButtonScript : MonoBehaviour
{
    public GameObject clonedGameObject;

    public void SetText()
    {
        GameObject MobilePlayerObj = GameObject.FindWithTag("MobilePlayer");
        MobilePlayer MobileScript = MobilePlayerObj.GetComponent<MobilePlayer>();
        Debug.Log(MobileScript.name);
        MobileScript.Enlarge();
        
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = MobilePlayerObj.name;
    }
}
