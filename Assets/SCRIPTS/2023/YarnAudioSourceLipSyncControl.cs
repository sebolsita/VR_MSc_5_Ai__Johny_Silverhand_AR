using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnAudioSourceLipSyncControl : MonoBehaviour
{
    public VoiceOverView voiceOverView;

    public AudioSource NPCOneAS, NPCTwoAS;

    public void Start()
    {
        voiceOverView = FindAnyObjectByType<VoiceOverView>();
    }


    [YarnCommand("Set_Audio_To_NPC_One")]
    public void SetAudioSourceToNPCOne()
    {
        voiceOverView.audioSource = NPCOneAS;
        Debug.Log("Switching to NPC 1 Audio Source");
    }

    [YarnCommand("Set_Audio_To_NPC_Two")]
    public void SetAudioSourceToNPCTwo()
    {
        voiceOverView.audioSource = NPCTwoAS;
        Debug.Log("Switching to NPC 2 Audio Source");

    }

}
