using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    PlayerController player;
    TextMeshProUGUI Balas;

    public static GameManager Instance {get; private set;}

    private void Awake()
    {
        if (Instance != null && Instance == this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cambioDeEscena(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }
}
