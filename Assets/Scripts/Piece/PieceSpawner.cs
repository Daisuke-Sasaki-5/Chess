using System;
using UnityEngine;

public class PieceSpawner : MonoBehaviour
{
    [Header("Board")]
    [SerializeField] private Board board;

    [Header("White Piece Prefab")]
    [SerializeField] private GameObject whitePawnPrefab;
    [SerializeField] private GameObject whiteRookPrefab;
    [SerializeField] private GameObject whiteKnightPrefab;
    [SerializeField] private GameObject whiteBishopPrefab;
    [SerializeField] private GameObject whiteQueenPrefab;
    [SerializeField] private GameObject whiteKingPrefab;

    [Header("Black Piece Prefab")]
    [SerializeField] private GameObject blackPawnPrefab;
    [SerializeField] private GameObject blackRookPrefab;
    [SerializeField] private GameObject blackKnightPrefab;
    [SerializeField] private GameObject blackBishopPrefab;
    [SerializeField] private GameObject blackQueenPrefab;
    [SerializeField] private GameObject blackKingPrefab;

    [Header("Position")]
    [SerializeField] private float heightOffset = 0.5f;

    private void Start()
    {
        board.Intialize();
        SpawnPiece();
    }

    private void SpawnPiece()
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Piece piece = board.GetPiece(x, y);

                // 駒がなければスキップ
                if (piece == null) { continue; }

                // 駒の種類と色からPrefabを取得
                GameObject prefab = GetPiecePrefab(piece.Type, piece.Color);

                // 駒を盤面上に生成
                Vector3 position = new Vector3(x, heightOffset, y);

                Instantiate(prefab, position, prefab.transform.rotation);
            }
        }
    }

    private GameObject GetPiecePrefab(PieceType type, PieceColor color)
    {
        if (color == PieceColor.White)
        {
            switch (type)
            {
                case PieceType.Pawn:
                    return whitePawnPrefab;
                case PieceType.Rook:
                    return whiteRookPrefab;
                case PieceType.Knight:
                    return whiteKnightPrefab;
                case PieceType.Bishop:
                    return whiteBishopPrefab;
                case PieceType.Queen:
                    return whiteQueenPrefab;
                case PieceType.King:
                    return whiteKingPrefab;
                default:
                    return null;
            }
        }
        else
        {
            switch (type)
            {
                case PieceType.Pawn:
                    return blackPawnPrefab;
                case PieceType.Rook:
                    return blackRookPrefab;
                case PieceType.Knight:
                    return blackKnightPrefab;
                case PieceType.Bishop:
                    return blackBishopPrefab;
                case PieceType.Queen:
                    return blackQueenPrefab;
                case PieceType.King:
                    return blackKingPrefab;
                default:
                    return null;
            }
        }
    }
}
