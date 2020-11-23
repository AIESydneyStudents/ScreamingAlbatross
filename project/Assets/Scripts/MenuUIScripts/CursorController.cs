using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] Texture2D m_idle, m_click;

    bool m_keydown;
    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        Cursor.visible = false;
        m_keydown = false;
        SetIdle();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && !m_keydown)
        {
            m_keydown = true;
            SetClick();
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && m_keydown)
        {
            m_keydown = false;
            SetIdle();
        }
    }

    private void SetIdle()
    {
        Cursor.SetCursor(m_idle, Vector2.zero, CursorMode.Auto);
    }

    private void SetClick()
    {
        Cursor.SetCursor(m_click, Vector2.zero, CursorMode.Auto);
    }
}