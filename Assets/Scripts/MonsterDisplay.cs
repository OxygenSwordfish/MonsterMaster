using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDisplay : MonoBehaviour
{
    public Monster monster; // Which monster scriptable object to use.
    public Text monsterName; 
    public Text monsterLevel;
    public GameObject go_;
    void Start()
    {
        if(go_.tag == "player") // Check if the monster is the players, if it is use the back sprite.
            this.GetComponent<SpriteRenderer>().sprite = monster.getBackSprite();
        else                    // If it isnt the players monster use the front sprite.
            this.GetComponent<SpriteRenderer>().sprite = monster.getFrontSprite();
        monsterName.text = monster.getMonsterName();
        monsterLevel.text = "Lv: " + monster.getMonsterLevel().ToString();
    }
}


/*
This class is for displaying a monster using the scriptable object.
The getters can be removed they are just there for testing.
-CJ-
*/