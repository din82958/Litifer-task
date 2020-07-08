using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{
    public string URL;
    public Image image;

    [System.Obsolete]
    private void Start()
    {
        StartCoroutine(DownloadImage());
    }

    [System.Obsolete]
    IEnumerator DownloadImage()
    {
        Debug.Log("Loading");
        WWW wwwloader = new WWW(URL);
        yield return wwwloader;
        Debug.Log("Loaded");
        image.sprite = Sprite.Create(wwwloader.texture, new Rect(0, 0, wwwloader.texture.width, wwwloader.texture.height), new Vector2(0, 0));
    }



}
