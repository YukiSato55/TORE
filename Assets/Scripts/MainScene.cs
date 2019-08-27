using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
	public GameObject BGM;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void GoMaingame()
	{
		SceneManager.LoadScene("MainGame");
	}
	public void Config()
	{
		BGM.SetActive(true);
	}
	public void Ranking()
	{
		SceneManager.LoadScene("MainGame");
	}
}
