using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region ΩÃ±€≈Ê
    private static Inventory instance;
    public static Inventory Instance
    {
        get { return instance; }
        set { instance = value; }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Instance = GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
