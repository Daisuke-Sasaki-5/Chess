using UnityEngine;
using UnityEngine.InputSystem;

public class SquareClickHandler : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        if(Mouse.current == null) {  return; }

        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            // カメラのマウスに向かってRayを飛ばす
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);

            // Rayが当たったオブジェクトの情報を返す
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Square square = hitInfo.collider.gameObject.GetComponent<Square>();

                if(square != null)
                {
                    Debug.Log($"クリックしたマス:X={square.X}, Y={square.Y})");
                }
            }
        }
    }
}
