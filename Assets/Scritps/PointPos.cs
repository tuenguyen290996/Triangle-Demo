using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPos : Singleton<PointPos>
{
    private float posX;
    private float posY;
    private float posZ;

    public override void Awake()
    {
        MakeSingleton(false);
    }
    public float PosX
    {
        get { return posX; }
        set { posX = value; }
    }
    public float PosY
    {
        get { return posY; }
        set { posX = value; }
    }
    public float PosZ
    {
        get { return posZ; }
        set { posX = value; }
    }

    public PointPos(float PosX, float PosY, float PosZ)
    {
        this.PosX = PosX;
        this.PosY = PosY;
        this.PosZ = PosZ;
    }
}
