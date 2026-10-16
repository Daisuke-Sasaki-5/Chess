using UnityEngine;

public class Board : MonoBehaviour
{
    private const int BoardSize = 8;

    private Piece[,] pieces = new Piece[BoardSize,BoardSize];

    public void Intialize()
    {
        SetupIntialPosition();
    }

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
        return x >= 0 && x < BoardSize && y >= 0 && y < BoardSize;
    }

    public void SetupIntialPosition()
    {
        // 左から順番に並ぶ後列の駒
        PieceType[] backColor =
        {
            PieceType.Rook,
            PieceType.Knight,
            PieceType.Bishop,
            PieceType.Queen,
            PieceType.King,
            PieceType.Bishop,
            PieceType.Knight,
            PieceType.Rook
        };

        for(int x = 0; x < BoardSize; x++)
        {
            // 白のポーンと後列
            SetPiece(x, 1, new Piece(PieceType.Pawn, PieceColor.White));
            SetPiece(x, 0, new Piece(backColor[x], PieceColor.White));

            // 黒のポーンと後列
            SetPiece(x, 6, new Piece(PieceType.Pawn, PieceColor.Black));
            SetPiece(x, 7, new Piece(backColor[x], PieceColor.Black));
        }
    }
}
