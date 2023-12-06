using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using static UnityEngine.GraphicsBuffer;


public class NPC3D : MonoBehaviour
{
    [Header("Character")]
    public string characterName = "";

    [Header("Yarn Specific")]
    public string talkToNode = "";
    public YarnProject scriptToLoad;
    public DialogueRunner dialogueRunner; //refernce to the dialogue control
    public GameObject dialogueCanvas; //refernce to the canvas

    [Header("Dialogue Canvas")]
    public Vector3 PostionSpeachBubble = new Vector3(0.0f, 2.0f, 0.0f);
    private float canvasTurnSpeed = 2;
    private bool canvasActive;
    private GameObject playerGameObject;


    /// </summary>
    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas = GameObject.FindGameObjectWithTag("Dialogue Canvas"); 
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        playerGameObject = GameObject.FindGameObjectWithTag("Player");


        if (scriptToLoad == null)
        {
            Debug.LogError("NPC3D not set up with yarn scriptToLoad ", this);
        }

        if (string.IsNullOrEmpty(characterName))
        {
            Debug.LogWarning("NPC3D not set up with characterName", this);
        }

        if (string.IsNullOrEmpty(talkToNode))
        {
            Debug.LogError("NPC3D not set up with talkToNode", this);
        }

        if (dialogueRunner == null)
        {
            Debug.LogError("dialogueRunner not set up", this);
        }
        
        if (dialogueCanvas == null)
        {
            Debug.LogError("Dialogue Canvas not set up", this);
        }

        if(playerGameObject == null)
        {
            Debug.LogError("Player Game Object not set up", this);
        }

        if (scriptToLoad != null && dialogueRunner != null && dialogueRunner != null)
        {
            dialogueRunner.yarnProject = scriptToLoad; //adds the script to the dialogue system
        }
    }
    void Update()
    {
        if (canvasActive)
        {
            Vector3 lookDir = dialogueCanvas.transform.position - playerGameObject.transform.position;
            float radians = Mathf.Atan2(lookDir.x, lookDir.z);
            float degrees = radians * Mathf.Rad2Deg;

            float str = Mathf.Min(canvasTurnSpeed * Time.deltaTime, 1);
            Quaternion targetRotation = Quaternion.Euler(0, degrees, 0);
            dialogueCanvas.transform.rotation = Quaternion.Slerp(dialogueCanvas.transform.rotation, targetRotation, str);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if other is player
        if (other.gameObject.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(talkToNode))
            {
                if (dialogueCanvas != null)
                {
                    // Adjust the PositionSpeachBubble vector
                    Vector3 adjustedPosition = PostionSpeachBubble;
                    adjustedPosition.y -= 0.2f;
                    // adjustedPosition.z += 0.0f;

                    // Move the Canvas to the object and offset
                    canvasActive = true;
                    dialogueCanvas.transform.SetParent(transform); // use the root to prevent scaling
                    dialogueCanvas.GetComponent<RectTransform>().anchoredPosition3D = transform.TransformVector(adjustedPosition);
                }

                if (dialogueRunner.IsDialogueRunning)
                {
                    dialogueRunner.Stop();
                }
                Debug.Log("start dialogue");
                dialogueRunner.StartDialogue(talkToNode);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasActive = false;
        }
    }
}

