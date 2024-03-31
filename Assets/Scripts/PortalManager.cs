using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PortalManager : MonoBehaviour
{
    private Controls _controls;

    private Dictionary<string, string> portals = new Dictionary<string, string>();

    [SerializeField] private string portalWorld;

    // FeedBack to player
    [SerializeField] private GameObject information;
    private bool playerIsNear = false;

    private void Awake()
    {
        _controls = new Controls();
    }

    private void OnEnable()
    {
        _controls.Enable();
        _controls.Base.Interact.started += Interact;
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void Start()
    {
        portals.Add("RobotWorldPortal", "RobotWorld");
        portals.Add("DinoWorldPortal", "DinoWorld");

        portalWorld = GetPortalWorld(gameObject.name);

        information.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && GameManager.Instance.GetCanChangeWorld())
        {
            Debug.Log("Player is near the portal: " + GetPortalWorld(gameObject.name));
            information.gameObject.SetActive(true);
            playerIsNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            information.gameObject.SetActive(false);
            playerIsNear = false;
        }
    }

    private string GetPortalWorld(string portalName)
    {
        return portals[portalName];
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (GameManager.Instance.GetCanChangeWorld() && playerIsNear)
        {
            Debug.Log("Mundo al que va a viajar: " + portalWorld);
            GameManager.Instance.cambioDeEscena(portalWorld);
        }
    }
}