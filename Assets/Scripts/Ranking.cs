using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class Ranking : MonoBehaviour
{
    /*
    public GameObject score_object = null;//Textオブジェクト
    public int score_num = 0;//スコア変数
    */
    //表示用テキスト
    public Text[] ScoreText;
    int[] ScoreInt;
    //仮の変数
    int Provisional;
    //スコア取得
    [System.NonSerialized]
    public MainManager mainmanager;


    // Start is called before the first frame update
    void Start()
    {
        int Score;
        mainmanager = GameObject.Find("GameManager").GetComponent<MainManager>();
        Score = mainmanager.Score;
        Provisional = ScoreText.Length * 100;
        ScoreInt = new int[ScoreText.Length];
        for (int i = 0; i < ScoreInt.Length; i++) ScoreInt[i] = 0;


        if (PlayerPrefs.HasKey("Ranking"))
        {
            Debug.Log("データあり");
            ScoreInt = PlayerPrefsX.GetIntArray("Ranking");
            for (int i = 0; i < ScoreText.Length; i++)
            {
                ScoreText[i].text = ScoreInt[i].ToString();         
            }

        }
        else
        {
            Debug.Log(ScoreInt);
            for(int i = 0;i < ScoreText.Length; i++)
            {
                ScoreInt[i] = Provisional;
                ScoreText[i].text = ScoreInt[i].ToString();
                Provisional -= 100;               
            }
        }

        if (ScoreInt[ScoreInt.Length - 1] <= Score)
        {
            ScoreInt[ScoreInt.Length - 1] = Score;
            Array.Sort(ScoreInt);
            Array.Reverse(ScoreInt);
            for(int i = 0;i < ScoreInt.Length;i++)ScoreText[i].text = ScoreInt[i].ToString();
        }

    }

    //削除時の処理
    private void OnDestroy()
    {
        /*
        //スコアの保存
        PlayerPrefs.SetInt("SCORE", score_num);
        PlayerPrefs.Save();
        */
        PlayerPrefsX.SetIntArray("Ranking", ScoreInt);
        PlayerPrefs.Save();

        //保存データの削除
        PlayerPrefs.DeleteKey("Ranking");

    }

    // Update is called once per frame
    void Update()
    {
        /*
        //オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        //テキストの表示を入れ替える
        score_text.text = "Score:" + score_num;

        score_num += 1; // とりあえず1加算し続けてみる
        */
    }
}
