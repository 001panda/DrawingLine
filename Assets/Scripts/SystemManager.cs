using UnityEngine;

public class SystemManager : MonoBehaviour
{
    //设置为单例模式，后期可以直接调用这个类,避免操作不一样的对象
    public static SystemManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        }
    }
    //方便后期管理
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
    //泛型，可自定义自己所需的参数类型
    public T GetInfo<T>(object obj)
    {
        return (T) obj;
    }
    /// <summary>
    /// 清楚所有的存储
    /// </summary>
    //public void ClaerAll()
    //{
    //    PlayerPrefs.DeleteAll();
    //}
    
}
