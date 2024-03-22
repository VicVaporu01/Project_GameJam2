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
    public UnityEvent reanudar;
    public UnityEvent pause;
    public UnityEvent finalDelJuego;
    int maxVida;
    int currentHealth;
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
        if(player != null)maxVida = System.Convert.ToInt32(player.health);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (vida != null && player != null)
        {
            currentHealth = System.Convert.ToInt32(player.health);
            vida.value = currentHealth;
            if (currentHealth == 0)
            {
                finDelJuego();
            }
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            pausa();
        }
        
    }
    public void cambioDeEscena(string Escena)
    {
        SceneManager.LoadScene(Escena);
    }
    public void pausa()
    {
        Time.timeScale = 0f;
        pause.Invoke();
    }
    public void regresar()
    {
        Time.timeScale = 1;
        reanudar.Invoke();
    }
    public void finDelJuego()
    {
        Time.timeScale = 0f;
    }
}
