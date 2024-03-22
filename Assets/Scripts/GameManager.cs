using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{

    [SerializeField]PlayerController player;
    TextMeshProUGUI Balas;
    [SerializeField] Slider vida;
    int maxVida;

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
        //maxVida = player.health
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //vida.value = math.clamp(vida/5)
    }
    public void cambioDeEscena(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }
}
