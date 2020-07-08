using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CustomImageLoader : MonoBehaviour
{
    public List<CustomImage> customImages;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(I_LoadImages());
    }

    IEnumerator I_LoadImages()
    {
        for (int i = 0; i < customImages.Count; i++)
        {
            UnityWebRequest downloadImageRequest = UnityWebRequestTexture.GetTexture(customImages[i].URL);
            yield return downloadImageRequest.SendWebRequest();
            if (!downloadImageRequest.isNetworkError && !downloadImageRequest.isHttpError)
            {
                var downloadtexture = DownloadHandlerTexture.GetContent(downloadImageRequest);
                if (downloadtexture!= null )
                {
                    customImages[i].image.sprite = Sprite.Create(downloadtexture, new Rect(0, 0, downloadtexture.width, downloadtexture.height), new Vector2(0.5f, 0.5f), 100, 0, SpriteMeshType.FullRect);
                    customImages[i].image.preserveAspect = true;
                    //customImages[i].image.SetNativeSize();
                    customImages[i].image.gameObject.SetActive(true);
                    yield return new WaitForEndOfFrame();
                }

            }
            else
            {
                Debug.LogError("Error Happend");
            }
        }
    }
   
}

[System.Serializable]
public class CustomImage
{
    public Image image;
    public string URL;

}