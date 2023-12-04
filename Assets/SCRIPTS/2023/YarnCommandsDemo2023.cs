using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class YarnCommandsDemo2023 : MonoBehaviour
{
    public InMemoryVariableStorage yarnInMemoryVariableStorage;

    public GameObject[] NPCGameObjects;

    public Material blue, red, orange;


    // Start is called before the first frame update
    void Start()
    {
        yarnInMemoryVariableStorage.SetValue("$numberOfNPCs", NPCGameObjects.Length);
        Debug.Log(NPCGameObjects.Length);
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
