using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public GameObject RankingPanel;
    public GameObject ResultPanel;
    // Start is called before the first frame update
    void Start()
    {
        RankingPanel.SetActive(false);
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
}
