using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] Texture2D m_idle, m_click;
    private void OnEnable()
    {
        DontDestroyOnLoad(this.gameObject);
        Cursor.visible = false;
        SetIdle();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            SetClick();
        }
    }

    private void SetIdle()
    {

    }

    private void SetClick()
    {

    }
}