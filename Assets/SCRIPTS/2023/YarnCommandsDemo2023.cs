using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using static UnityEngine.Rendering.DebugUI.Table;

public class YarnCommandsDemo2023 : MonoBehaviour
{
    public InMemoryVariableStorage yarnInMemoryVariableStorage;

    public GameObject[] NPCGameObjects;

    public Material blue, red, orange;

    public Animator npcAnimator;
    public GameObject guituarObject;
    public GameObject smokeObject;
    public GameObject byeObject;

    public GameObject crowd;
    public GameObject crowd2;
    public GameObject crowd3;
    public GameObject crowd4;
    public GameObject crowd5;
    public GameObject crowd6;
    public GameObject crowd7;
    public GameObject crowd8;
    public GameObject crowd9;
    public GameObject crowd10;

    // Start is called before the first frame update
    void Start()
    {
        yarnInMemoryVariableStorage.SetValue("$numberOfNPCs", NPCGameObjects.Length);
        Debug.Log(NPCGameObjects.Length);
    }

    // Function to handle the custom command
    [YarnCommand("setGuitarState")]
    public void SetGuitarState(/*string state*/)
    {
        // Parse the string to a boolean value
        // bool guitarState = bool.Parse(state);
        bool guitarState = true;

        // Set the "Guitar" boolean parameter in the Animator
        npcAnimator.SetBool("Guitar", guitarState);
        guituarObject.SetActive(true);
    }

    [YarnCommand("setSmokeState")]
    public void SetSmokeState(/*string state*/)
    {
        // Parse the string to a boolean value
        // bool guitarState = bool.Parse(state);
        bool smokeState = true;

        // Set the "Guitar" boolean parameter in the Animator
        npcAnimator.SetBool("Smoke", smokeState);
        smokeObject.SetActive(true);
    }

    [YarnCommand("setByeState")]
    public void SetByeState(/*string state*/)
    {
        // Parse the string to a boolean value
        // bool guitarState = bool.Parse(state);
        bool byeState = true;

        // Set the "Guitar" boolean parameter in the Animator
        npcAnimator.SetBool("Bye", byeState);
        byeObject.SetActive(true);
    }

    [YarnCommand("crowd")]
    public void Crowd()
    {
        crowd.SetActive(true);
        crowd2.SetActive(true);
        crowd3.SetActive(true);
        crowd4.SetActive(true);
        crowd5.SetActive(true);
        crowd6.SetActive(true);
        crowd7.SetActive(true);
        crowd8.SetActive(true);
        crowd9.SetActive(true);
        crowd10.SetActive(true);
    }



    [YarnCommand("change_cube_colour")]
    public void ChangeCubeColour()
    {
        string cubeToChange;
        yarnInMemoryVariableStorage.TryGetValue("$cubeToChange", out cubeToChange);

        string colourToChangeTo;
        yarnInMemoryVariableStorage.TryGetValue("$colourOfCube", out colourToChangeTo);

        Debug.Log("Changing " + cubeToChange + " to " + colourToChangeTo);

        if(cubeToChange == "1")
        {
            if (colourToChangeTo == "Blue")
            {
                NPCGameObjects[0].GetComponent<MeshRenderer>().material = blue;
            }

            if (colourToChangeTo == "Red")
            {
                NPCGameObjects[0].GetComponent<MeshRenderer>().material = red;
            }

            if (colourToChangeTo == "Orange")
            {
                NPCGameObjects[0].GetComponent<MeshRenderer>().material = orange;
            }
        }

        if(cubeToChange == "2")
        {
            if (colourToChangeTo == "Blue")
            {
                NPCGameObjects[1].GetComponent<MeshRenderer>().material = blue;
            }

            if (colourToChangeTo == "Red")
            {
                NPCGameObjects[1].GetComponent<MeshRenderer>().material = red;
            }

            if (colourToChangeTo == "Orange")
            {
                NPCGameObjects[1].GetComponent<MeshRenderer>().material = orange;
            }
        }
    }


}
