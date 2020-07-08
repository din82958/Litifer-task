using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public GameObject slid;
    private void Start()
    {
        slid.SetActive(false);
        LoadLevel();
    }
    public void LoadLevel()
    {
        StartCoroutine(LoadAsynchronosly());
       
    }

    IEnumerator LoadAsynchronosly()
    {
        
        AsyncOperation async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
          
            slid.SetActive(true);
            yield return new WaitForSeconds(1);
            float bar = Mathf.Clamp01(async.progress / .9f);
            Debug.Log("async in progress");
            Debug.Log(bar);
            slider.value = bar;
            text.text = bar * 100 + "%";
            if (async.progress < 8)
            {
                slider.value = 1;
                yield return new WaitForSeconds(1.5f);
                async.allowSceneActivation = true;
                break;
            }
            yield return new WaitForEndOfFrame();
            
        }
       
    }
}