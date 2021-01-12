using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chessman : MonoBehaviour
{
    public int CurrentX { get; set; }
    public int CurrentY { get; set; }
    
    public bool isWhite;

    public int valueChessman { get; set; }
    public int countMovesChessman = 0;

    public int CountMovesChessman
    {
        get => countMovesChessman;
        set => countMovesChessman = value;
    }

    public void SetPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    public virtual bool[,] PossibleMove()
    {
        return new bool[8,8];
    }
}
