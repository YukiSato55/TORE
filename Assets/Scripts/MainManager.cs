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
    float timer = 0;
    float timer2 = 0;
    //お題用配列
    string[] Thema = {"大きい","小さい"};
    //解答テキスト用配列
    public Text[] Answer = new Text[2];
    //お題用テキスト
    public Text ThemaText;
    //制限時間テキスト
    public Text TimelimitText;
    //正答数関連
    public Text AnswerRateText;
    int Allque = 0;
    int Correctque = 0;
    //問題数
    public Button[] Probrem;
    //解答判定
    int answers = 2;

    enum GAME_MODE
    {
        START,
        PLAY,
        JUDGE,
        FINISH,
    };

    GAME_MODE type = GAME_MODE.START;
    // Start is called before the first frame update
    void Start()
    {
        TimelimitText.text = Timelimit.ToString();
        for (int i = 0; i < Con.Length; i++) Con[i] = 0;
        for (int i = 0; i < Pos.Length; i++) Pos[i] = 0;
        for (int i = 0; i < Answer.Length; i++) Answer[i].gameObject.SetActive(false);
        display();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        switch (type)
        {
            case GAME_MODE.START:
                type = GAME_MODE.PLAY;
                break;
            case GAME_MODE.PLAY:
                timer += Time.deltaTime;
                if(Timelimit != 0)
                {
                    Debug.Log("asdfghjk");
                    //制限時間
                    if (timer >= 1)
                    {
                        
                        Timer();
                    }
                    //-----------------------------------------
                    if (answers != 2)
                    {
                        type = GAME_MODE.JUDGE;
                    }
                }
                else type = GAME_MODE.FINISH;
                
                break;

            case GAME_MODE.JUDGE:
                judge();
                timer2 += Time.deltaTime;
                if (timer2 >= 2)
                {
                    if (Answer[0].isActiveAndEnabled)Answer[0].gameObject.SetActive(false);
                    if (Answer[1].isActiveAndEnabled) Answer[1].gameObject.SetActive(false);
                    AnswerRateText.text = string.Format("正答数：{0}%", Correctque * 100 / Allque);
                    display();
                    answers = 2;
                    answersNumber += 1;
                    type = GAME_MODE.PLAY;
                    timer2 = 0;
                }
                break;

            case GAME_MODE.FINISH:
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
            Debug.Log(Con[0] + " : " + Con[1]);
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
        //Debug.Log(Con[0] + " " + Con[1]);
        ThemaNumber = UnityEngine.Random.Range(0, 2);
        ThemaText.text = string.Format("『{0}』のはどっち？", Thema[ThemaNumber]);
        //Debug.Log("answers : " + answers);
    }

    void Timer()
    {
        Timelimit -= 1;
        TimelimitText.text = Timelimit.ToString();
        timer = 0;
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
            Debug.Log("Pos[answers] : " + Pos[answers] + " Con[0] : " + Con[0]);
            if (Pos[answers] == Con[0])
            {
                Answer[0].gameObject.SetActive(true);
                Correctque += 1;
                Debug.Log("judge : true");
            }
            else
            {
                Answer[1].gameObject.SetActive(true);
                Debug.Log("judge : false");
            }
        }

        if(ThemaNumber == 1)
        {
            Debug.Log("Pos[answers] : " + Pos[answers] + " Con[1] : " + Con[1]);
            if (Pos[answers] == Con[1])
            {
                Answer[0].gameObject.SetActive(true);
                Correctque += 1;
                Debug.Log("judge : true");
            }
            else
            {
                Answer[1].gameObject.SetActive(true);
                Debug.Log("judge : false");
            }
        }
    }
}
