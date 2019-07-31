using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorRange : MonoBehaviour
{
    [SerializeField]
    private Color MaxColor, MinColor;
    private Color ThisColor;
    private Image image;
    private Outline outline;
    private Text text;

    [SerializeField]
    private float ChangeFrame = 60; //変更間隔
    private float ChangeRSec, ChangeGSec, ChangeBSec, ChangeASec;

    [SerializeField]
    enum CompType {Image, Text, Outline}
    [SerializeField]
    CompType compType;

    enum UpDown {UP, DOWN};
    private UpDown upDown;

    // Start is called before the first frame update
    void Start()
    {
        switch(compType)
        {
            case CompType.Image:
                image = GetComponent<Image>();
                break;

            case CompType.Text:
                text = GetComponent<Text>();
                break;

            case CompType.Outline:
                outline = GetComponent<Outline>();
                break;
        }
        ThisColor = MinColor;
        upDown = UpDown.UP;

        ChangeRSec = (MaxColor.r - MinColor.r) / ChangeFrame;// / 255f; // 一間隔あたりのR色変更数（以下G,B,Aと続く）
        ChangeGSec = (MaxColor.g - MinColor.g) / ChangeFrame;// / 255f; 
        ChangeBSec = (MaxColor.b - MinColor.b) / ChangeFrame;// / 255f; 
        ChangeASec = (MaxColor.a - MinColor.a) / ChangeFrame;// / 255f; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ChangeColor();
        switch(compType)
        {
            case CompType.Image:
                image.color = ThisColor;
                break;

            case CompType.Text:
                text.color = ThisColor;
                break;

            case CompType.Outline:
                outline.effectColor = ThisColor;
                break;
        }
    }

    void ChangeColor()
    {
        switch(upDown)
        {
            case UpDown.UP:
                Debug.Log("UP");
                ThisColor = new Color
                    (ThisColor.r + ChangeRSec,
                     ThisColor.g + ChangeGSec,
                     ThisColor.b + ChangeBSec,
                     ThisColor.a + ChangeASec);

                if(ThisColor == MaxColor)
                {
                    upDown = UpDown.DOWN;
                }
                break;

            case UpDown.DOWN:
                Debug.Log("DOWN");
                ThisColor = new Color
                    (ThisColor.r - ChangeRSec,
                     ThisColor.g - ChangeGSec,
                     ThisColor.b - ChangeBSec,
                     ThisColor.a - ChangeASec);

                if (ThisColor == MinColor)
                {
                    upDown = UpDown.UP;
                }
                break;
        }
    }
    //仮
}
