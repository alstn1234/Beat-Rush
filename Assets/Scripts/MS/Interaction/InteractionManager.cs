using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IInteractable
{
    string GetInteractPrompt();

    void OnInteract();

}

public class InteractionManager : MonoBehaviour
{
    public float CheckRate = 0.05f;
    public float RayDistance;
    private float lastCheckTime;

    private IInteractable currentInteractable;
    public LayerMask TargetLayerMask;

    public TextMeshProUGUI promptText; 
    private Camera _camera;

    private Player _player;

    private void Start()
    {
        _camera = Camera.main;
        _player = GetComponent<Player>();

        _player.Input.PlayerActions.Interaction.started += OnInteractInput;
    }

    private void Update()
    {
        if(Time.time - lastCheckTime > CheckRate)
        {
            lastCheckTime = Time.time;

            Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width /2, Screen.height /2));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, RayDistance, TargetLayerMask))
            {
                if(currentInteractable == null)
                {
                    currentInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                promptText.gameObject.SetActive(false);
                currentInteractable = null;
            }
        }
    }
    
    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = string.Format($"<b>[E]</b> {currentInteractable.GetInteractPrompt()}");
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (currentInteractable == null) return;
        currentInteractable.OnInteract();
    }
}
