using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private PlayerInputs playerInputs;

    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public bool isActive = false;

    HashSet<int> talkedToNPCs = new HashSet<int>();
    bool conversationEnded = false;

    public GameObject[] questMarkers;

    private void Awake()
    {
        playerInputs = GetComponent<PlayerInputs>();
    }

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        conversationEnded = false;

        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorsToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorsToDisplay.name;
        actorImage.sprite = actorsToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation Ended");
            isActive = false;
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            conversationEnded = true;
            AddTalkedNPC();
        }
    }

    void AddTalkedNPC()
    {
        if (!conversationEnded) return; // Ensure the conversation has ended
        Message lastMessage = currentMessages[currentMessages.Length - 1];
        Actor lastActor = currentActors[lastMessage.actorID];
        if (SceneManager.GetActiveScene().name == "Level-1")
        {
            if (!talkedToNPCs.Contains(lastActor.ID))
            {
                // Increment level 1 score if it's a new NPC
                ScoreScript.levelOneScore++;
                // Add NPC to the set of talked NPCs for level 1
                talkedToNPCs.Add(lastActor.ID);
                // Destroy the quest marker associated with this NPC
                DestroyQuestMarker(lastActor.ID);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level-2")
        {
            if (!talkedToNPCs.Contains(lastActor.ID))
            {
                // Increment level 2 score if it's a new NPC
                ScoreScript.levelTwoScore++;
                // Add NPC to the set of talked NPCs for level 2
                talkedToNPCs.Add(lastActor.ID);
                // Destroy the quest marker associated with this NPC
                DestroyQuestMarker(lastActor.ID);
            }
        }

        void DestroyQuestMarker(int actorID)
        {
            // Find the NPC GameObject by actorID
            GameObject npcObject = GameObject.Find("NPC_" + actorID); // Assuming your NPCs have a naming convention like "NPC_1", "NPC_2", etc.

            if (npcObject != null)
            {
                // Get the quest marker associated with the NPC
                Transform questMarker = npcObject.transform.Find("QuestMarker");

                if (questMarker != null)
                {
                    // Destroy the quest marker GameObject
                    Destroy(questMarker.gameObject);
                }
                else
                {
                    Debug.LogWarning("Quest marker not found for NPC with ID: " + actorID);
                }
            }
            else
            {
                Debug.LogWarning("NPC GameObject not found with ID: " + actorID);
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
