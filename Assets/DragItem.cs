using UnityEngine;
using UnityEngine.EventSystems;

public class dragItem : MonoBehaviour, IDragHandler
{
    private Vector2 mousePosition = new Vector2();
    private Vector2 startPosition = new Vector2();
    private Vector2 differencePoint = new Vector2();
    private Vector2 screenBounds;

    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if (Input.GetMouseButton(0))
        {
            UpdateMousePosition();
        }
        if (Input.GetMouseButtonDown(0))
        {
            UpdateStartPosition();
            UpdateDifferencePoint();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (transform.parent.GetChild(1).gameObject.activeSelf)
        {

            Vector2 viewPos = mousePosition - differencePoint;

            viewPos.x = Mathf.Clamp(viewPos.x, 0, Screen.width);
            viewPos.y = Mathf.Clamp(viewPos.y, 0, Screen.height);
            transform.parent.position = viewPos;
            // transform.parent.position = mousePosition - differencePoint;
        }
    }

    private void UpdateMousePosition()
    {
        mousePosition = Input.mousePosition;
    }

    private void UpdateStartPosition()
    {
        startPosition = transform.parent.position;
    }

    private void UpdateDifferencePoint()
    {
        differencePoint = mousePosition - startPosition;
    }
}
