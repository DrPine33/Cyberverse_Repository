using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInputs playerInputs;

    public DialogueManager dialogueManager;
    

    private void Awake()
    {
        playerInputs = GetComponent<PlayerInputs>();
    }
    private void Update()
    {

        if (playerInputs.interact)
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out NPCInteractable npcInteractable))
                {
                    npcInteractable.NPCInteract();
                }
            }
            playerInputs.interact = false;
        }

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            dialogueManager.NextMessage(); // Trigger next message
        }
    }
}
