using UnityEngine;

public class Square : MonoBehaviour
{
    /// <summary>
    /// 各マスが自身の座標を持つ
    /// </summary>
    public int X {  get; private set; }
    public int Y { get; private set; }

    public void SetCoordainates(int x, int y)
    {
        X = x; Y = y;
    }
}
