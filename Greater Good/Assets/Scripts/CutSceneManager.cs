using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CutSceneSlide
{
    [SerializeField] Sprite sprite;
    [SerializeField] int slideTime;

	public Sprite Sprite { get => sprite;  }
	public int SlideTime { get => slideTime;  }
}

[System.Serializable]
public class CutScene
{
    [SerializeField] CutSceneSlide[] slides;
    [SerializeField] string cutSceneName;
    int index = 0;

	public string CutSceneName { get => cutSceneName; }
    public int Length() { return slides.Length; }

	public CutSceneSlide GetNextSlide()
	{
        if (index < slides.Length)
        {
            CutSceneSlide slide = slides[index];
            index++;
            return slide;
        }
        return null;
	}
}

public class CutSceneManager : MonoBehaviour
{
    public static bool cutScenePlaying = false;
    public static CutSceneManager instance;

    [SerializeField] CutScene[] cutScenes;
    [SerializeField] Image currentSlide;

	private void Awake()
	{
		if(instance == null) { instance = this; DontDestroyOnLoad(gameObject); }
		else { Destroy(gameObject); }
        currentSlide.gameObject.SetActive(false);
	}

	private void Start()
	{
        PlayCutScene("Opening");
	}

	public void PlayCutScene(string cutSceneName)
	{
        foreach(CutScene cutScene in cutScenes)
		{
            if(cutScene.CutSceneName == cutSceneName) { StartCoroutine(PlaySlideShow(cutScene));break; }
		}
	}

    IEnumerator PlaySlideShow(CutScene cutScene)
	{
        currentSlide.gameObject.SetActive(true);
        cutScenePlaying = true;
        for(int i = 0; i < cutScene.Length(); i++)
		{
            CutSceneSlide slide = cutScene.GetNextSlide();
            currentSlide.sprite = slide.Sprite;
            float colorFade = 0;
            currentSlide.color = new Color(colorFade, colorFade, colorFade, 1);
            while(colorFade < 1)
			{
                yield return new WaitForSeconds(0.1f);
                colorFade += 0.2f;
                currentSlide.color = new Color(colorFade, colorFade, colorFade, 1);
            }
            yield return new WaitForSeconds(slide.SlideTime);
            while (colorFade > 0)
            {
                yield return new WaitForSeconds(0.1f);
                colorFade -= 0.2f;
                currentSlide.color = new Color(colorFade, colorFade, colorFade, 1);
            }
        }
        currentSlide.gameObject.SetActive(false);
        cutScenePlaying = true;
    }
}
