using System;
using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private Material whiteMaterial;
    [SerializeField] private Material blackMaterial;

    private const int BoardSize = 8;

    private void Start()
    {
        GenerateBoard();
    }

    private void GenerateBoard()
    {
        for(int y = 0; y < BoardSize; y++)
        {
            for (int x = 0; x < BoardSize; x++)
            {
                Vector3 position = new Vector3(x, 0, y);

                GameObject square = Instantiate(squarePrefab, position, Quaternion.identity);

                Square squareData = square.GetComponent<Square>();
                squareData.SetCoordainates(x, y);

                bool isWhite = (x + y) % 2 == 0;

                Renderer renderer = square.GetComponent<Renderer>();

                if(isWhite)
                {
                    renderer.material = whiteMaterial;
                }
                else
                {
                    renderer.material = blackMaterial;
                }
            }
        }
    }
}
