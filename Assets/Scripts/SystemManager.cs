using UnityEngine;

public class SystemManager : MonoBehaviour
{
    //����Ϊ����ģʽ�����ڿ���ֱ�ӵ��������,���������һ���Ķ���
    public static SystemManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        }
    }
    //������ڹ���
    public void SetSystem(string name,int value)
    {
        PlayerPrefs.SetInt(name, value);
    }public void SetSystem(string name,float value)
    {
        PlayerPrefs.GetFloat(name, value);
    }public void SetSystem(string name,string value)
    {
        PlayerPrefs.SetString(name, value);
    }
    public int GetSystem(string name)
    {
        return PlayerPrefs.GetInt(name);
    }
    //���ͣ����Զ����Լ�����Ĳ�������
    public T GetInfo<T>(object obj)
    {
        return (T) obj;
    }
    /// <summary>
    /// ������еĴ洢
    /// </summary>
    //public void ClaerAll()
    //{
    //    PlayerPrefs.DeleteAll();
    //}
    
}
