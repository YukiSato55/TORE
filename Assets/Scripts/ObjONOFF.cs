using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjONOFF : MonoBehaviour
{
    [SerializeField]
    GameObject Obj;

    public void ActiveON()
    {
        Obj.SetActive(true);
    }

    public void ActiveOFF()
    {
        Obj.SetActive(false);
    }
}
