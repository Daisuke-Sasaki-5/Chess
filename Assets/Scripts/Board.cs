using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    private const int BoardSize = 8;

    private Piece[,] pieces = new Piece[BoardSize,BoardSize];

    // 指定したマスの駒を取得する
    public Piece GetPiece(int x, int y)
    {
        if(!IsInsideBoard(x, y))
        {
            return null;
        }
        return pieces[x,y];
    }

    // 指定したマスに駒を配置する
    public void SetPiece(int x, int y, Piece piece)
    {
        if(!IsInsideBoard(x, y))
        {
            return;
        }

        pieces[x,y] = piece;
    }

    //座標が盤面の範囲内か確認する
    private bool IsInsideBoard(int x, int y)
    {
        return x >= 0 && x < BoardSize && y >= 0 && y < BoardSize; ;
    }
}
