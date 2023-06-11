using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveImageBetweenScenes : MonoBehaviour
{
    private static MoveImageBetweenScenes _instance;
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
            _instance = this;
        DontDestroyOnLoad(this.gameObject);
        //this.gameObject.SetActive (false);
    }
}
