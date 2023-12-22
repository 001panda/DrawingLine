using System;

[Serializable]
public class Response<T>
{
    public int code;
    public string message;
    public T data;
}