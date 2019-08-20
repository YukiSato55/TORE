using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sample : MonoBehaviour
{

	public Text text;
	bool fe = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Color color = text.material.GetColor("_Color");
		//color.a = color.a <= 0 ? 1 : color.a - 0.01f;
		if(fe == true)
		{
			color.a = color.a - 0.01f;
			if(color.a <= 0.05)
			{
				fe = false;
			}
		}else if(fe == false)
		{
			color.a = color.a + 0.01f;
			if (color.a >= 0.95)
			{
				fe = true;
			}
		}
		text.material.SetColor("_Color", color);
	}
}
