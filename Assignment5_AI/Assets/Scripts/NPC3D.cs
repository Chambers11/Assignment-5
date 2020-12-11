using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC3D : MonoBehaviour
{
    public string characterName = "";
    public string talkToNode = "";
    public YarnProgram scriptToLoad;
    DialogueRunner dialogueRunner; //refernce to the dialogue control
    private GameObject dialogueCanavas; //refernce to the canvas
    public 
        Vector3 PostionSpeachBubble = new Vector3(0f, 0.0f, -0.6f);


    /// </summary> 
    /// // Start is called before the first frame update   
    void Start()
    {
        if (scriptToLoad == null) Debug.LogError("NPC3D not set up with yarn scriptToLoad ", this);
        if (string.IsNullOrEmpty(characterName)) Debug.LogWarning("NPC3D not set upwith characterName", this);
        if (string.IsNullOrEmpty(talkToNode)) Debug.LogError("NPC3D not set up withtalkToNode", this);

        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>(); //this is bad way to do this but hey we doing this quickly
        if (dialogueRunner == null) Debug.LogError("dialogueRunner not set up", this);
        dialogueCanavas = GameObject.Find("Dialogue Canvas"); //this is bad way to do this but hey we doing this quickly
        if (dialogueCanavas == null) Debug.LogError("Dialogue Canvas not set up", this);
        if (scriptToLoad != null && dialogueRunner != null && dialogueRunner != null)
        {
            dialogueRunner.Add(scriptToLoad); //adds the script to the dialogue system
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if other is player
        if (other.gameObject.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(talkToNode))
            {
                if (dialogueCanavas != null)
                {
                    //move the Canvas to the object and off set
                    dialogueCanavas.transform.SetParent(transform.parent.transform); // use the root toprevent scaling
                    dialogueCanavas.GetComponent<RectTransform>().anchoredPosition3D = transform.parent.TransformVector(PostionSpeachBubble);
                }
                if (dialogueRunner.IsDialogueRunning)
                {
                    dialogueRunner.Stop();
                }
                Debug.Log("start dialouge");
                dialogueRunner.StartDialogue(talkToNode);
            }
        }
    }
}