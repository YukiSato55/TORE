using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SEManager : MonoBehaviour {
	
    private AudioSource GetSE;
	private float bgm;
	UnityEngine.Audio.AudioMixer mixer;
	private Slider slider;

	void Awake(){
		if (SceneManager.GetActiveScene ().name == "Menu") {
		}
		if (PlayerPrefs.HasKey ("BGM")) // セーブデータ存在
		{
			bgm = PlayerPrefs.GetFloat ("BGM");
		} else         // セーブデータ無
		{
			bgm = 10;
			PlayerPrefs.SetFloat ("BGM", bgm);
		}
		gameObject.GetComponent<AudioSource> ().volume = bgm/10;


	}
	// Use this for initialization
	void Start () {
        GetSE = GetComponent<AudioSource>();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        //Debug.Log("音なるで");
        GetSE.PlayOneShot(GetSE.clip);
    }
		
    public void GiveOnClick(AudioClip SE)
    {
        GetSE.PlayOneShot(SE);
    }

	public void SliderChange() {
		GameObject.Find ("BGMSlider").GetComponent<Slider> ().value = bgm;
	}

	public void ChangeMusicVolume(float vol){
		Debug.Log (vol);
		gameObject.GetComponent<AudioSource> ().volume = vol/10;
		//mixer.SetFloat ("MusicVolume", vol);
		PlayerPrefs.SetFloat("BGM",vol);
	}

	public void ChangeSfxVolume(float voll){
		Debug.Log (voll);
		gameObject.GetComponent<AudioSource> ().volume = voll/10;
		//mixer.SetFloat ("SfxVolume", vol);
	}
    // BGM,SEの音量数値を保存して、他のシーンでも使える様に

	public float masterVolume {
		set {
			mixer.SetFloat ("MasterVolume", Mathf.Lerp (-80, 0, value));
		}
	}
}