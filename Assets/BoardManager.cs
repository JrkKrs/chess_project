﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { set; get; }
    private bool[,] allowedMoves { set; get; }

    public Chessman[,] Chessmans { get; set; }
    private Chessman selectedChessman;

    private const float TILE_SIZE = 1.0f;
    private const float TILE_OFFSET = .5f;

    private int selectionX = -1;
    private int selectionY = -1;


    public List<GameObject> chessmanPrefabs;
    private List<GameObject> activeChessman;

    private Quaternion orientation = Quaternion.Euler(0,180,0);

    public int[] EnPassantMove { get; set; }


    public bool isWhiteTurn = true;
    private bool isCheck = false;

    public string token;


    private void Start()
    {
        Instance = this;
        SpawnAllChessman();
        // SpawnAllChessmanTest();
    }
    private void Update()
    {
        UpdateSelection();
        DrawChessboard();

        if (Input.GetMouseButtonDown(0))
        {
            if (selectionX >= 0 && selectionY >= 0)
            {
                if (selectedChessman == null)
                {
                    SelectChessman(selectionX, selectionY);
                }
                else
                {
                    MoveChessman(selectionX, selectionY);
                }
            }
        }
    }

    private void SelectChessman(int x, int y)
    {
        if (Chessmans[x, y] == null)
        {
            return;
        }

        if (Chessmans[x, y].isWhite != isWhiteTurn)
        {
            return;
        }

        bool hasAtleastOneMove = false;
        
        allowedMoves = Chessmans[x, y].PossibleMove();

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (allowedMoves[i, j])
                    hasAtleastOneMove = true;
            }
        }
        if (!hasAtleastOneMove)
            return;

        selectedChessman = Chessmans[x, y];

        BoardHightlights.Instance.HighlightAllowedMoves(allowedMoves);
    }

    private void MoveChessman(int x, int y)
    {
        if (allowedMoves[x,y])
        {
            Chessman c = Chessmans[x, y];
            if (c != null && c.isWhite != isWhiteTurn)
            {

                if (c.GetType() == typeof(Chessman_King))
                {
                    //end game
                    return;
                }

                activeChessman.Remove(c.gameObject);
                Destroy(c.gameObject);
            }


            if (x == EnPassantMove[0] && y== EnPassantMove[1])
            {
                if (isWhiteTurn)
                    c = Chessmans[x, y - 1];
                else
                     c = Chessmans[x, y + 1];
                activeChessman.Remove(c.gameObject);
                Destroy(c.gameObject);
                
            }


            EnPassantMove[0] = EnPassantMove[1] = -1;
            if (selectedChessman.GetType() == typeof(Chessman_Pawn))
            {
                if (selectedChessman.CurrentY == 1 && y==3)
                {
                    EnPassantMove[0] = x;
                    EnPassantMove[1] = y-1;
                }
                else if (selectedChessman.CurrentY == 6 && y == 4)
                {
                    EnPassantMove[0] = x;
                    EnPassantMove[1] = y+1;
                }
            }



            Chessmans[selectedChessman.CurrentX, selectedChessman.CurrentY] = null;
            selectedChessman.transform.position = GetTitileCenter(x, y);
            selectedChessman.SetPosition(x,y);
            Chessmans[x, y] = selectedChessman;
            isWhiteTurn = !isWhiteTurn;
        }
        BoardHightlights.Instance.Hidehighlights();
        selectedChessman = null;
    }

    private void UpdateSelection()
    {
        if(!Camera.main)
            return;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 25.0f,LayerMask.GetMask("ChessPlane")))
        {
            selectionX = (int) hit.point.x;
            selectionY = (int) hit.point.z;
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }
    }

    private void SpawnChessman(int index, int x, int y)
    {
        GameObject go = Instantiate(chessmanPrefabs [index], GetTitileCenter(x,y), orientation) as GameObject;
        go.transform.SetParent( transform);
        if(index == 4)
            go.transform.Rotate(-90.0f,90.0f,0.0f);
        else
            go.transform.Rotate(-90.0f,-90.0f,0.0f);



        Chessmans[x, y] = go.GetComponent<Chessman>();
        Chessmans[x,y].SetPosition(x,y);
        activeChessman.Add(go);
    }

    private void SpawnAllChessman()
    {
        activeChessman = new List<GameObject>();
        Chessmans = new Chessman[8, 8];

        EnPassantMove = new int[2] {-1,-1};


        //White team
        SpawnChessman(0, 4, 0); //krol
        SpawnChessman(1, 3, 0); //hetman
        SpawnChessman(2, 0, 0); //wieza
        SpawnChessman(2, 7, 0); //wieza
        SpawnChessman(3, 2, 0); //goniec
        SpawnChessman(3, 5, 0); //goniec
        SpawnChessman(4, 1, 0); //skoczek
        SpawnChessman(4, 6, 0); //skoczek
        for (int i = 0; i < 8; i++)
        {
            SpawnChessman(5, i, 1);
        }

        //Black team
        SpawnChessman(6, 4, 7); //krol
        SpawnChessman(7, 3, 7); //hetman
        SpawnChessman(8, 0, 7); //wieza
        SpawnChessman(8, 7, 7); //wieza
        SpawnChessman(9, 2, 7); //goniec
        SpawnChessman(9, 5, 7); //goniec
        SpawnChessman(10, 1, 7); //skoczek
        SpawnChessman(10, 6, 7); //skoczek
        for (int i = 0; i < 8; i++)
        {
            SpawnChessman(11, i, 6);
        }


    }
    private void SpawnAllChessmanTest()
    {
        activeChessman = new List<GameObject>();
        Chessmans = new Chessman[8, 8];

        EnPassantMove = new int[2] { -1, -1 };


        //White team
        SpawnChessman(0, 6, 0); //krol
        SpawnChessman(1, 7, 4); //hetman
        SpawnChessman(2, 4, 0); //wieza
        SpawnChessman(2, 5, 0); //wieza
        SpawnChessman(4, 4, 3); //skoczek
        SpawnChessman(5, 0, 1);
        SpawnChessman(5, 6, 1);
        SpawnChessman(5, 7, 1);
        SpawnChessman(5, 5, 3);
        SpawnChessman(5, 4, 4);

        //Black team
        SpawnChessman(6, 6, 7); //krol
        SpawnChessman(7, 2, 1); //hetman
        SpawnChessman(8, 0, 7); //wieza
        SpawnChessman(8, 5, 7); //wieza
        SpawnChessman(9, 2, 7); //goniec
        SpawnChessman(10, 1, 7); //skoczek
        SpawnChessman(10, 3, 4); //skoczek
        SpawnChessman(11, 0, 6);
        SpawnChessman(11, 1, 6);
        SpawnChessman(11, 3, 6);
        SpawnChessman(11, 5, 6);
        SpawnChessman(11, 6, 6);
        SpawnChessman(11, 3, 3);
        


    }

    private Vector3 GetTitileCenter(int x, int y)
    {
        Vector3 origin = Vector3.zero;
        origin.x += (TILE_SIZE * x) + TILE_OFFSET;
        origin.z += (TILE_SIZE * y) + TILE_OFFSET;
        return origin;
    }
    private void DrawChessboard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heightLine= Vector3.forward *8;

        for (int i = 0; i <=8 ; i++)
        {
            Vector3 start = Vector3.forward *i;
            Debug.DrawLine(start, start+ widthLine);
            for (int j = 0; j <= 8; j++)
            {
                start = Vector3.right * j;
                Debug.DrawLine(start, start + heightLine);
            }
        }

        // Drw selection
        if (selectionX >= 0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward * selectionY+ Vector3.right * selectionX,
                Vector3.forward * (selectionY +1 ) + Vector3.right * (selectionX +1));

            Debug.DrawLine(
                Vector3.forward * (selectionY +1 ) + Vector3.right * selectionX,
                Vector3.forward * (selectionY ) + Vector3.right * (selectionX + 1));
        }
    }
    
}
