using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman_Queen : Chessman
{
    public override bool[,] PossibleMove()
    {
        valueChessman = 9;
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
            if (i >= 8 || j >= 8)
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
            if (i < 0 || j >= 8)
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
            if (i >= 8 || j < 0)
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

        //right
        i = CurrentX;
        while (true)
        {
            i++;
            if (i >= 8)
                break;

            c = BoardManager.Instance.Chessmans[i, CurrentY];
            if (c == null)
            {
                r[i, CurrentY] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY] = true;
                }

                break;
            }
        }

        //left
        i = CurrentX;
        while (true)
        {
            i--;
            if (i < 0)
                break;

            c = BoardManager.Instance.Chessmans[i, CurrentY];
            if (c == null)
            {
                r[i, CurrentY] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[i, CurrentY] = true;
                }

                break;
            }
        }

        //up
        i = CurrentY;
        while (true)
        {
            i++;
            if (i >= 8)
                break;

            c = BoardManager.Instance.Chessmans[CurrentX, i];
            if (c == null)
            {
                r[CurrentX, i] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, i] = true;
                }

                break;
            }
        }

        //down
        i = CurrentY;
        while (true)
        {
            i--;
            if (i < 0)
                break;

            c = BoardManager.Instance.Chessmans[CurrentX, i];
            if (c == null)
            {
                r[CurrentX, i] = true;
            }
            else
            {
                if (c.isWhite != isWhite)
                {
                    r[CurrentX, i] = true;
                }

                break;
            }
        }

        return r;

    }
}
