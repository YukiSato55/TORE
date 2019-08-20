using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SEManager : MonoBehaviour {
	
    private AudioSource GetSE;
	private float Volume;
    AudioMixer mixer;
	private Slider slider;

    [SerializeField]
    enum AudioType { BGM, SE }
    [SerializeField]
    AudioType audioType;

    [SerializeField]
    bool ChangeVolScene;
    [SerializeField]
    AudioMixer audiomixer;

    void Awake() {
        slider = GetComponent<Slider>();
        switch (audioType)
        {
            case AudioType.BGM:

                if (PlayerPrefs.HasKey("BGMVol")) // セーブデータ存在
                {
                    Volume = PlayerPrefs.GetFloat("BGMVol");
                }
                else         // セーブデータ無
                {
                    Volume = 0;
                    PlayerPrefs.SetFloat("BGMVol", Volume);
                }
                Debug.Log("BGM" + Volume);
                audiomixer.SetFloat("BGMVol", Volume);
                break;

            case AudioType.SE:
                if (PlayerPrefs.HasKey("SEVol")) // セーブデータ存在
                {
                    Volume = PlayerPrefs.GetFloat("SEVol");
                }
                else         // セーブデータ無
                {
                    Volume = 0;
                    PlayerPrefs.SetFloat("SEVol", Volume);
                }
                audiomixer.SetFloat("SEVol", Volume);
                break;
        }
        slider.value = Volume;

    }

    // Use this for initialization
    void Start()
    {
        switch (audioType)
        {
            case AudioType.BGM:
                audiomixer.SetFloat("BGMVol", slider.value);
                break;

            case AudioType.SE:
                audiomixer.SetFloat("SEVol", slider.value);
                break;
        }
    }


        // Update is called once per frame

    void Update () {

	}

	public float masterVolume {
		set {
			mixer.SetFloat ("MasterVolume", Mathf.Lerp (-80, 0, value));
		}
	}

    public void ChangeSlider()
    {
        switch (audioType)
        {
            case AudioType.BGM:
                audiomixer.SetFloat("BGMVol", slider.value);
                break;

            case AudioType.SE:
                audiomixer.SetFloat("SEVol", slider.value);
                break;
        }
        Volume = slider.value;
    }

    public void SaveVolume()
    {
        switch(audioType)
        {
            case AudioType.BGM:
                PlayerPrefs.SetFloat("BGMVol", Volume);
                break;

            case AudioType.SE:
                PlayerPrefs.SetFloat("SEVol", Volume);
                break;
        }
    }
}