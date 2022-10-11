using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]


public class Wave
{


    float delayBeforeWave = 1; // secs to delay after the prev wave


    GameObject[] ships;             // array of ships in this wave


    // Delay the next wave until this wave is completely killed?


    bool delayNextWaveUntilThisWaveIsDead = false;


}
