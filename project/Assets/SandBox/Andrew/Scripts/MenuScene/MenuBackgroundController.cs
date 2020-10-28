using UnityEngine;

public class MenuBackgroundController : MonoBehaviour
{
    [SerializeField] MenuCarLogic m_carObject;
    [SerializeField] float m_X;
    [SerializeField] float m_Z;



    private void Update()
    {
        if(m_carObject.gameObject.activeInHierarchy == false)
        {
            InitializeCar();
        }
    }
    private void InitializeCar()
    {
        Vector3 start = Vector3.one;
        Vector3 end = Vector3.one;

        switch(Random.Range(0,4))
        {
            case 0:
                //right
                start = new Vector3(m_Z, 0, GetPos(m_X));
                end = new Vector3(-m_Z, 0, GetPos(m_X));
                break;
            case 1:
                //left
                start = new Vector3(-m_Z, 0, GetPos(m_X));
                end = new Vector3(m_Z, 0, GetPos(m_X));
                break;
            case 2:
                //top
                start = new Vector3(GetPos(m_Z), 0, m_X);
                end = new Vector3(GetPos(m_Z), 0, -m_X);
                break;
            case 3:
                //bottom
                start = new Vector3(GetPos(m_Z), 0, -m_X);
                end = new Vector3(GetPos(m_Z), 0, m_X);
                break;
        }

        m_carObject.InitializeCar(start, end);
    }

    private float GetPos(float f)
    {
        return Random.Range(-f, f);
    }
}
