using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D hoverCursor;
    public Texture2D startCursor;

    void Start()
    {
        if(startCursor != null)
            Cursor.SetCursor(startCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseEnter()
    {
        if(hoverCursor!=null)
            Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    void OnMouseExit()
    {
        if(defaultCursor != null)
            Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
