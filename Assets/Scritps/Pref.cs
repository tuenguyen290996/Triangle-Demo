using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pref
{
    public static int PointId
    {
        set => PlayerPrefs.SetInt(PrefConst.POINT_ID, value);
        get => PlayerPrefs.GetInt(PrefConst.POINT_ID);
    }
    public static void SetBool(string key, bool isOn)
    {
        if (isOn)
        {
            PlayerPrefs.SetInt(key, 1);
        }
        else
        {
            PlayerPrefs.SetInt(key, 0);
        }
    }

    public static bool GetBool(string key)
    {
        return PlayerPrefs.GetInt(key) == 1 ? true : false;
    }
}
