using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman_Bishop : Chessman
{
    public override bool[,] PossibleMove()
    {
        valueChessman = 3;
        bool[,] r = new bool[8, 8];
        
        Chessman c;

        int i, j;


        // UpRight
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j++;
            if (i >= 8 || j>=8)
                break;

            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = true;
                }

                break;
            }
        }
        // UpLeft
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j++;
            if (i <0 || j >= 8)
                break;

            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = true;
                }

                break;
            }
        }

        // DownLeft
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i--;
            j--;
            if (i < 0 || j < 0)
                break;

            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = true;
                }

                break;
            }
        }

        // DownLeft
        i = CurrentX;
        j = CurrentY;
        while (true)
        {
            i++;
            j--;
            if (i >=8 || j < 0)
                break;

            c = BoardManager.Instance.Chessmans[i, j];
            if (c == null)
            {
                r[i, j] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, j] = true;
                }

                break;
            }
        }

        return r;

    }
}
