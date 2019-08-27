using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject RankingPanel;
    public GameObject ResultPanel;
    public GameObject PausePanel;
    MainManager mainmanager;
    // Start is called before the first frame update
    void Start()
    {
        mainmanager = GameObject.Find("GameManager").GetComponent<MainManager>();
        RankingPanel.SetActive(false);
        PausePanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Title()
    {
        SceneManager.LoadScene("Title");
    }

    public void MainGame()
    {
        SceneManager.LoadScene("MainGame");
    }


    public void RankingOpen()
    {
        RankingPanel.SetActive(true);
    }

    public void RankingClose()
    {
        RankingPanel.SetActive(false);
    }

    public void RankingOpenResultClose()
    {
        RankingPanel.SetActive(true);
        ResultPanel.SetActive(false);
        Debug.Log("asfddgf");
    }

    public void RankingCloseResultOpen()
    {
        RankingPanel.SetActive(false);
        ResultPanel.SetActive(true);
    }

    public void Pause()
    {
        if (mainmanager.Pauseflg)
        {
            PausePanel.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Resume()
    {
        PausePanel.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void Reload()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }
}
