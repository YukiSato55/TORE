using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public class MainManager : MonoBehaviour
{
    //int[] Randam;
    //正解数
    int answersNumber = 0;
    //乱数用
    int r1, r2 = 0;
    //計算結果確認用
    int[] Con = new int[2];
    int[] Pos = new int[2];
    //お題番号
    int ThemaNumber = 0;
    //制限時間
    public int Timelimit;
    //計測タイマー
    float timer1 = 0;
    float timer2 = 0;
    float timer3 = 0;
    float timer4 = 0;
    
    //お題用テキスト
    public Text ThemaUpDownText;
    //制限時間テキスト
    public Text TimelimitText;
    //正答数関連
    //public Text AnswerRateText;
    int Allque = 0;
    int Correctque = 0;

    //解答判定
    int answers = 2;
    //SEフラグ
    bool SEflg1 = true;
    bool SEflg2 = true;

    //リザルト画面
    public GameObject ResultPanel;
    public GameObject RankingPanel;
    public Text AnswerRateText;
    public Text ScoreText;
    [System.NonSerialized]
    public int Score = 0;


    enum GAME_MODE
    {
        START,
        PLAY,
        JUDGE,
        FINISH_BEFORE,
        FINISH,
    };


    //public AudioClip CorrectClip;
    //public AudioClip InCorrectClip;

    GAME_MODE type = GAME_MODE.START;

    //お題用配列
    string[] Thema = { "大きい", "小さい" };
    //解答テキスト用配列
    public Text[] Answer = new Text[2];
    //サウンド関連
    AudioSource audiosource;
    public AudioClip[] Clip;
    //問題数
    public Button[] Probrem;
    //テキスト関連
    public Text[] Texts;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        //TimelimitText.text = string.Format("残り時間：{0}", Timelimit);
        //初期化処理
        for (int i = 0; i < Con.Length; i++) Con[i] = 0;
        for (int i = 0; i < Pos.Length; i++) Pos[i] = 0;
        for (int i = 0; i < Texts.Length; i++) Texts[i].gameObject.SetActive(false);
        for (int i = 0; i < Answer.Length; i++) Answer[i].gameObject.SetActive(false);
        //------------
        //ReadyText.gameObject.SetActive(false);
        //GoText.gameObject.SetActive(false);
        ResultPanel.gameObject.SetActive(false);
        RankingPanel.gameObject.SetActive(false);

        //display();
        

    }

    // Update is called once per frame
    void Update()
    {
        //PlayerPrefs.DeleteKey("Ranking");
        
        switch (type)
        {
            case GAME_MODE.START:
                TimelimitText.text = string.Format("残り時間：{0}", Timelimit);
                timer1 += Time.deltaTime;
                Texts[0].gameObject.SetActive(true);
                Texts[1].gameObject.SetActive(true);
                //ReadyText.gameObject.SetActive(true);
                //GoText.gameObject.SetActive(true);
                if (timer1 > 3f && SEflg2)
                {
                    audiosource.PlayOneShot(Clip[2]);
                    SEflg2 = false;
                }
                if (timer1 > 5)
                {
                    Texts[0].gameObject.SetActive(false);
                    Texts[1].gameObject.SetActive(false);
                    //ReadyText.gameObject.SetActive(false);
                    //GoText.gameObject.SetActive(false);
                    timer1 = 0;
                    display();
                    type = GAME_MODE.PLAY;
                }
                break;
            case GAME_MODE.PLAY:
                timer2 += Time.deltaTime;
                if(Timelimit != 0)
                {
                    //Debug.Log("asdfghjk");
                    //制限時間
                    if (timer2 >= 1)
                    {
                        
                        Timer();
                    }
                    //-----------------------------------------
                    if (answers != 2)
                    {
                        type = GAME_MODE.JUDGE;
                    }
                }
                else type = GAME_MODE.FINISH_BEFORE;
                
                break;

            case GAME_MODE.JUDGE:
                judge();
                timer3 += Time.deltaTime;
                if (timer3 >= 2)
                {
                    if (Answer[0].isActiveAndEnabled)Answer[0].gameObject.SetActive(false);
                    if (Answer[1].isActiveAndEnabled) Answer[1].gameObject.SetActive(false);
                    
                    ////Debug.Log(Correctque * 100 / Allque);
                    display();
                    answers = 2;
                    answersNumber += 1;
                    type = GAME_MODE.PLAY;
                    timer3 = 0;
                    SEflg1 = true;
                }
                break;

            case GAME_MODE.FINISH_BEFORE:
                SEflg2 = true;
                timer4 += Time.deltaTime;           
                if (timer4 < 0.05f && SEflg2)
                {
                    audiosource.PlayOneShot(Clip[3]);
                    SEflg2 = false;
                }
                Texts[2].gameObject.SetActive(true);
                if (timer4 > 3)
                {
                    Texts[2].gameObject.SetActive(false);
                    type = GAME_MODE.FINISH;
                }
                break;

            case GAME_MODE.FINISH:
                
                ThemaUpDownText.gameObject.SetActive(false);
                Score = Correctque * 10000;
                if (Correctque == 0) Score = 0;
                AnswerRateText.text = string.Format("{0}%", Score / Allque);
                ScoreText.text = string.Format("{0}点", Score);
                
                ResultPanel.gameObject.SetActive(true);
                //RankingPanel.gameObject.SetActive(true);
                break;
        }
    }

    void display()
    {

        for (int i = 0; i < Con.Length; i++) Con[i] = 0;
        for (int i = 0; i < Pos.Length; i++) Pos[i] = 0;
        for (int i = 0; i < Probrem.Length; i++)
        {
            //Randam[i] = Random.Range(1, 100);
            r1 = UnityEngine.Random.Range(1, 9);
            r2 = UnityEngine.Random.Range(1, 9);
            //計算結果配列代入
            Con[i] = r1 + r2;
            //Debug.Log(Con[0] + " : " + Con[1]);
            if(Con[0] == Con[1])
            {
                r1 = UnityEngine.Random.Range(1, 9);
                r2 = UnityEngine.Random.Range(1, 9);
                Con[1] = r1 + r2;
            }
            Pos[i] = r1 + r2;
            //----------------
            Probrem[i].GetComponentInChildren<Text>().text = System.String.Format("{0} + {1}  = ", r1, r2);
        }
        //計算結果配列降順ソート処理
        Array.Sort(Con);
        Array.Reverse(Con);
        //----------------------------
        ////Debug.Log(Con[0] + " " + Con[1]);
        //お題用処理
        ThemaNumber = UnityEngine.Random.Range(0, 2);
        //ThemaText.text = string.Format("『{0}』のはどっち？", Thema[ThemaNumber]);
        ThemaUpDownText.text = Thema[ThemaNumber];
        if (ThemaNumber == 0) ThemaUpDownText.color = Color.red;
        else if (ThemaNumber == 1) ThemaUpDownText.color = Color.blue;
        //-------------------------------------------------------------
        ////Debug.Log("answers : " + answers);
    }

    void Timer()
    {
        Timelimit -= 1;
        TimelimitText.text = string.Format("残り時間：{0}",Timelimit);
        //TimelimitText.text = Timelimit.ToString();
        timer2 = 0;
    }

    public void Button(int i)
    {
        answers = i;
    }

    void judge()
    {
        Allque += 1;
        if(ThemaNumber == 0)
        {
            //Debug.Log("Pos[answers] : " + Pos[answers] + " Con[0] : " + Con[0]);
            if (Pos[answers] == Con[0])
            {
                Answer[0].gameObject.SetActive(true);
                if (SEflg1)
                {
                    Correctque += 1;
                    audiosource.PlayOneShot(Clip[0]);
                    SEflg1 = false;
                }
                
                
                //Debug.Log("judge : true");
            }
            else
            {
                Answer[1].gameObject.SetActive(true);
                if (SEflg1)
                {
                    audiosource.PlayOneShot(Clip[1]);
                    SEflg1 = false;
                }
                //Debug.Log("judge : false");
            }
        }

        if(ThemaNumber == 1)
        {
            //Debug.Log("Pos[answers] : " + Pos[answers] + " Con[1] : " + Con[1]);
            if (Pos[answers] == Con[1])
            {
                Answer[0].gameObject.SetActive(true);
                if (SEflg1)
                {
                    Correctque += 1;
                    audiosource.PlayOneShot(Clip[0]);
                    SEflg1 = false;
                }
                
                //Debug.Log("judge : true");
            }
            else
            {
                Answer[1].gameObject.SetActive(true);
                if (SEflg1)
                {
                    audiosource.PlayOneShot(Clip[1]);
                    SEflg1 = false;
                }
                //Debug.Log("judge : false");
            }
        }
    }
}
