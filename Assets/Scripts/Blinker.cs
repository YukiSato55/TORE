using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{
	public GameObject textObject; //点滅させたい文字
	private float nextTime;
	public float interval = 0.1f;   //点滅周期

	public bool flag = true;
    // Start is called before the first frame update
    void Start()
    {
		nextTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if (Time.time > nextTime){
			Debug.Log("check1");
			float alpha = textObject.GetComponent<CanvasRenderer>().GetAlpha();
			if (flag == true)
			{
				Debug.Log("check2");
				textObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);
				alpha =- 0.1f;
				if(alpha <= 0.1f)
				{
					Debug.Log("check3");
					flag = false;
				}
			}
			else if (flag == false)
			{
				Debug.Log("check4");
				textObject.GetComponent<CanvasRenderer>().SetAlpha(alpha);
				alpha += 0.1f;
				if (alpha >= 0.9f)
				{
					Debug.Log("check5");
					flag = true;
				}
			}
			nextTime += interval;
		}
    }
}
