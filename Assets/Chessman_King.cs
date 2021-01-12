using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman_King : Chessman
{
    public override bool[,] PossibleMove()
    {
        bool[,] r = new bool[8,8];
        valueChessman = 99999;

        Chessman c;

        int i, j;

        i = CurrentX;
        j = CurrentY;

        for (int k = -1; k < 2; k++)
        {
            for (int l = -1; l < 2; l++)
            {
                // Debug.Log("x: " + i + " y: " + j + " k: " + k + " l: " + l);
                if ((k == 0 && l == 0) || (i == 0 && k == -1) || (i == 7 && k == 1) || (j == 0 && l == -1) || (j == 7 && l == 1))
                {
                    
                }
                else
                {
                    c = BoardManager.Instance.Chessmans[i + k, j + l];
                    if (c == null)
                        r[i + k, j + l] = true;

                    else if (isWhite != c.isWhite)
                        r[i + k, j + l] = true;
                }
                

            }
        }
        //

        return r;
    }
}
