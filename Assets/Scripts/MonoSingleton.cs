using UnityEngine;
using System.Collections.Generic;
using System.Reflection;


public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    protected static T obj;
    protected string Id;
    protected bool isDestroy;
    static protected bool isQuit = false;

    /*public static T Get()
    {
        return Instance;
    }*/

    public static T Instance
    {
        get
        {
            if (!obj)
            {
                if (isQuit) //���� �״���..
                    return null;

                // �ϴ� ���� ��ü�� �ִٶ�� �����ϰ� ó���� ã�´�~     
                // ���ٸ� ���ӿ�����Ʈ �����ϰ� T�� Add�ؼ� �̱��� ��ü�� �����.
                obj = (T)FindObjectOfType(typeof(T));

                if (!obj)
                {
                    //if( ResourceDB.IsApplicationQuit == true )
                    //{
                    //	TODebug.LogWarning( string.Format( "[{0}]Application ���� �� MonoSingleton�� ������ �õ��߽��ϴ�.", typeof( T ) ) );
                    //	return null;
                    //}

                    obj = new GameObject(typeof(T).Name).AddComponent<T>();
                    obj.Init();
                }
                else
                    obj.Init();
            }

            return obj;
        }

        protected set { }
    }

    protected virtual void Awake()
    {
        if (obj != null)
        {
            Debug.LogError("obj != null " + this.gameObject.name);
            return;
        }

        obj = this as T;
        Instance.gameObject.name = typeof(T).Name;
        DontDestroyOnLoad(Instance);
        Debug.Log("Singleton : " + Instance.gameObject.name);
    }

    public static void DestroySingleton()
    {
        if (obj == null)
            obj = (T)FindObjectOfType(typeof(T));

        if (obj != null)
            GameObject.DestroyImmediate(obj.gameObject);
        obj = null;
    }

    public static bool isDestroyed()
    {
        return (obj == null);
    }

    void OnApplicationQuit()
    {
        obj = null;
        Instance = null;
        isQuit = true;
    }

    protected virtual void Init()
    {
    }

}