using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    public static dontDestroy instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            DestroyImmediate(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
