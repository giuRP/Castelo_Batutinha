using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisibilityUtil : MonoBehaviour
{
    private void Awake()
    {
        MakeCursorVisible();
    }

    public void MakeCursorVisible()
    {
        Cursor.visible = true;
    }

    public void MakeCursorInvisible()
    {
        Cursor.visible = false;
    }
}
