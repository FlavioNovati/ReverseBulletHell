using UnityEngine;

public static class CameraBounds
{
    private static float _deadZone;
    private static Color _color;

    /// <summary>
    /// X min => x
    /// X max => y
    /// Y min => z
    /// Y max => w
    /// </summary>
    private static Vector4 _bounds;

    static CameraBounds()
    {
        _deadZone = 3f;
        _color = Color.magenta;
        UpdateCameraBounds();
    }

    public static void UpdateCameraBounds()
    {
        float ortographicSize = Camera.main.orthographicSize;
        float aspectRation = (float)Screen.width / (float)Screen.height;

        float viewHeight = 2 * ortographicSize;
        float viewWidth = viewHeight * aspectRation;

        Vector3 camPos = Camera.main.transform.position;

        _bounds.x = camPos.x - (viewWidth / 2 + _deadZone);
        _bounds.y = camPos.x + (viewWidth / 2 + _deadZone);

        _bounds.z = camPos.y - (viewHeight / 2 + _deadZone);
        _bounds.w = camPos.y + (viewHeight / 2 + _deadZone);

        Debug.DrawLine(new Vector3(_bounds.x, _bounds.z, 0f), new Vector3(_bounds.y, _bounds.z, 0f), _color, Time.deltaTime);
        Debug.DrawLine(new Vector3(_bounds.x, _bounds.z, 0f), new Vector3(_bounds.x, _bounds.w, 0f), _color, Time.deltaTime);
        Debug.DrawLine(new Vector3(_bounds.x, _bounds.w, 0f), new Vector3(_bounds.y, _bounds.w, 0f), _color, Time.deltaTime);
        Debug.DrawLine(new Vector3(_bounds.y, _bounds.w, 0f), new Vector3(_bounds.y, _bounds.z, 0f), _color, Time.deltaTime);
    }

    public static bool VectorInBounds(Vector3 position)
    {
        bool inX = position.x >= _bounds.x && position.x <= _bounds.y;
        bool inY = position.y >= _bounds.z && position.y <= _bounds.w;

        return inX && inY;
    }

    public static Vector4 GetBounds() => _bounds;
}
