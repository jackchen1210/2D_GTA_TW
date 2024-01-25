using System;
using UnityEngine;

public class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
{
    private static T instance;

    public static T GetInstance()
    {
        if(instance == null)
        {
            throw new System.Exception("��ҩ|����l��");
        }

        return instance;
    }

    private void Awake()
    {
        if(instance !=null && this.gameObject != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = (T)this;
        DontDestroyOnLoad(gameObject);
        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }
}
