using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutObject : MonoBehaviour
{
    //初期設定
    Image image;
    Text text;

    float alpha;
    [SerializeField]
    public enum Comp {Image, Text }
    [SerializeField]
    Comp comp;


    enum Fadetype {FadeIn, FadeOut, Repeat};

    Fadetype fadetype;
    [SerializeField]
    bool Repeat;

    bool RepeatMode = false;

    [Range(0f, 1f)]
    [SerializeField]
    float StartFade = 1, EndFade = 0;
    
    [SerializeField]
    float FadeTime = 3;
    float NowTime, OneFalpha;
    
    // Start is called before the first frame update
    void Start()
    {
        //どちらがおっきいか
        if(StartFade > EndFade)
        {
            fadetype = Fadetype.FadeOut;
        } else
        {
            fadetype = Fadetype.FadeIn;
        }
        if (Repeat == true) fadetype = Fadetype.Repeat;
        OneFalpha = 255 / (60 / FadeTime);
        switch(comp)
        {
            case Comp.Image:
                image = GetComponent<Image>();
                break;
            case Comp.Text:
                text = GetComponent<Text>();
                break;
        }

        switch (fadetype)
        {
            case Fadetype.FadeIn:
                NowTime = 0;
                break;
            case Fadetype.FadeOut:
                NowTime = FadeTime;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadetype == Fadetype.Repeat) {
            RepeatFade();
        }
        else {
            Fade();
            ApplyFade();
        }
    }

    //一回限りの方
    void Fade()
    {
        switch(fadetype)
        {
            case Fadetype.FadeIn:
                NowTime += Time.deltaTime;
                break;

            case Fadetype.FadeOut:
                NowTime -= Time.deltaTime;
                break;
        }
    }

    //出力
    void ApplyFade()
    {
        if (StartFade >= EndFade)
        {
            alpha = (NowTime / FadeTime) * StartFade;
        } else
        {
            alpha = (NowTime / FadeTime) * EndFade;
        }
        switch(comp)
        {
            case Comp.Image:
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
                break;

            case Comp.Text:
                text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
                break;
        }
    }

    public void ChangeFade()
    {
        if(fadetype == Fadetype.FadeIn)
        {
            fadetype = Fadetype.FadeOut;
        } else if(fadetype == Fadetype.FadeOut)
        {
            fadetype = Fadetype.FadeIn;
        }
    }

    void RepeatFade()
    {
        if (RepeatMode)
        {
            NowTime -= Time.deltaTime;
            if (NowTime <= 0) RepeatMode = !RepeatMode;
        }
        else
        {
            NowTime += Time.deltaTime;
            if (NowTime / FadeTime >= 1) RepeatMode = !RepeatMode;
        }
        ApplyFade();
    }

    public void OutsideInControl(Comp objtype, float StartAlpha, float EndAlpha, float Timespan)
    {
        switch(objtype)
        {
            case Comp.Image:
                comp = Comp.Image;
                image = GetComponent<Image>();
                break;

            case Comp.Text:
                comp = Comp.Text;
                break;
        }
        StartFade = StartAlpha;
        EndFade = EndAlpha;
        FadeTime = Timespan;
        Start();
    }

}
