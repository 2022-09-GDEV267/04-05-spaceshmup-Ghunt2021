using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Level
{


    Wave[] waves;  // Holder for waves


    float timeLimit = -1; // If -1, there is no time limit


    string name = ""; // The name of the level


}