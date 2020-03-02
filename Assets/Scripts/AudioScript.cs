using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    private static AudioScript _instance;

    public static AudioScript Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            PlayerPrefs.SetFloat("Volume", 1f);
            DontDestroyOnLoad(gameObject);
        }
    }
}
