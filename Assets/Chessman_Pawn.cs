﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman_Pawn : Chessman
{
    public override bool[,] PossibleMove()
    {
        valueChessman = 1;
        bool[,] r = new bool[8, 8];
        int[] e = BoardManager.Instance.EnPassantMove;
        Chessman c, c2;

        //white
        if (isWhite)
        {
            //diagonal left
            if (CurrentX != 0 && CurrentY != 7)
            {
                
                if (e[0] == CurrentX -1 &&e[1] ==CurrentY+1)
                {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }

                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                {
                    r[CurrentX - 1, CurrentY + 1] = true;
                }
            }

            //diagonal right
            if (CurrentX != 7 && CurrentY != 7)
            {

                if (e[0] == CurrentX + 1 && e[1] == CurrentY + 1)
                {
                    r[CurrentX + 1, CurrentY + 1] = true;
                }

                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY + 1];
                if (c != null && !c.isWhite)
                {
                    r[CurrentX + 1, CurrentY + 1] = true;
                }
            }
            //middle
            if(CurrentY != 7 )
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                if (c == null)
                    r[CurrentX, CurrentY + 1] = true;
            }

            //middle on first move

            if (CurrentY == 1)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY + 2];
                if (c == null &&c2 == null)
                    r[CurrentX, CurrentY + 2] = true;
            }
        }
        //black
        else
        {
            //diagonal left
            if (CurrentX != 7 && CurrentY != 0)
            {

                if (e[0] == CurrentX + 1 && e[1] == CurrentY - 1)
                {
                    r[CurrentX + 1, CurrentY - 1] = true;
                }

                c = BoardManager.Instance.Chessmans[CurrentX + 1, CurrentY - 1];
                if (c != null && c.isWhite)
                {
                    r[CurrentX + 1, CurrentY - 1] = true;
                }
            }

            //diagonal right
            if (CurrentX != 0 && CurrentY != 0)
            {

                if (e[0] == CurrentX - 1 && e[1] == CurrentY - 1)
                {
                    r[CurrentX - 1, CurrentY - 1] = true;
                }

                c = BoardManager.Instance.Chessmans[CurrentX - 1, CurrentY - 1];
                if (c != null && c.isWhite)
                {
                    r[CurrentX - 1, CurrentY - 1] = true;
                }
            }
            //middle
            if (CurrentY != 0)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                if (c == null)
                    r[CurrentX, CurrentY - 1] = true;
            }

            //middle on first move

            if (CurrentY == 6)
            {
                c = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 1];
                c2 = BoardManager.Instance.Chessmans[CurrentX, CurrentY - 2];
                if (c == null && c2 == null)
                    r[CurrentX, CurrentY - 2] = true;
            }
        }
        return r;

    }

}