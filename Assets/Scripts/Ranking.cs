using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    /*
    public GameObject score_object = null;//Textオブジェクト
    public int score_num = 0;//スコア変数
    */
    //表示用テキスト
    public Text[] ScoreText;
    //仮の変数
    int Provisional;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Ranking"))
        {
            for (int i = 0; i < ScoreText.Length; i++)
            {
                ScoreText[i].text = PlayerPrefs.GetInt("Ranking", i).ToString();
            }
        }
        else
        {
            Provisional = ScoreText.Length * 10000;
            for(int i = 0;i < ScoreText.Length; i++)
            {
                ScoreText[i].text = Provisional.ToString();
                Provisional -= 10000;               
            }
        }

        //スコアのロード
        //score_num = PlayerPrefs.GetInt("SCORE", 0);
    }

    //削除時の処理
    private void OnDestroy()
    {
        /*
        //スコアの保存
        PlayerPrefs.SetInt("SCORE", score_num);
        PlayerPrefs.Save();
        */
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
