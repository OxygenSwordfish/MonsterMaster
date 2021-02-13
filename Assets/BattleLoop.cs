using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum battleStates { BEGIN, PLAYERTURN, ENEMYTURN, VICTORY, LOSS }
public class BattleLoop : MonoBehaviour
{
    

    public battleStates bState;
    public GameObject playerZone;
    public GameObject enemyZone;

    // Start is called before the first frame update
    void Start()
    {
        bState = battleStates.BEGIN;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
