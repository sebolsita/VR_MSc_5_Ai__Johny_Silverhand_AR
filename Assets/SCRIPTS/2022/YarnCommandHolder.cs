using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandHolder : MonoBehaviour
{
    public InMemoryVariableStorage yarnInMemoryStorage;

    public Material redMat, yellowMat, greenMat, blueMat;
    public GameObject cube;


    // Start is called before the first frame update
    void Start()
    {
        cube.GetComponent<MeshRenderer>().material = blueMat;
    }

    [YarnCommand("set_cube_colour")]
    public void SetCubeColour()
    {
        float monthsOfUseFromYarn;
        yarnInMemoryStorage.TryGetValue("$monthsOfUse", out monthsOfUseFromYarn);
        Debug.Log(monthsOfUseFromYarn);
        if(monthsOfUseFromYarn < 6)
        {
            cube.GetComponent<MeshRenderer>().material = redMat;
        }
        if(monthsOfUseFromYarn >= 6 && monthsOfUseFromYarn < 12)
        {
            cube.GetComponent<MeshRenderer>().material = yellowMat;
        }
        if(monthsOfUseFromYarn >= 12)
        {
            cube.GetComponent<MeshRenderer>().material = greenMat;
        }
    }
}
