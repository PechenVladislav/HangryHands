using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private static GameManager _instance;

    [SerializeField] public float minSpeed = 1f;
    [SerializeField] public float minTimeShoot = 1f;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        AudioManager.Instance.PlayBackgroundMusic(AudioManager.Instance.MusicBackground);
    }

}
