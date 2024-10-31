using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CustomCursorManager : MonoBehaviour
{
    public Texture2D defaultCursor;  // First custom cursor sprite
    public Texture2D hoverCursor;    // Second custom cursor sprite when hovering over buttons
    public Vector2 cursorHotspot = Vector2.zero; // Adjust the cursor hotspot if needed

    private void Update()
    {
        // Raycast to see if the mouse is hovering over a UI element
        if (IsPointerOverUIElement())
        {
            Cursor.SetCursor(hoverCursor, cursorHotspot, CursorMode.Auto); // Set hover cursor
        }
        else
        {
            Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto); // Set default cursor
        }
    }

    private bool IsPointerOverUIElement()
    {
        // Raycast to check if pointer is over any UI element with Button component
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        // Store Raycast result
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);

        // Check if the raycast hit any UI object with a Button component
        foreach (var result in results)
        {
            if (result.gameObject.GetComponent<Button>() != null)
            {
                return true; // Cursor is over a Button
            }
        }

        return false; // Cursor is not over a Button
    }
}
