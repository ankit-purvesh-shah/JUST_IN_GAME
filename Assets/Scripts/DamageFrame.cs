using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Texture2D;

public class DamageFrame : MonoBehaviour
{
    [SerializeField]
    public Texture2D textureImage;

    void OnGUI() { GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textureImage); }


}
