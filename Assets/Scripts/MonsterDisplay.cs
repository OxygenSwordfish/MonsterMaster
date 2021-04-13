using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDisplay : MonoBehaviour
{
    public Monster monster;
    void Start()
    {
        monster.DisplayMonsterName();
        monster.getMonsterID();
        monster.getMonsterSex();
        monster.getXP();
        monster.getLevel();
        monster.getLevelRate();
        monster.getMonsterType();
        monster.getMonsterSecondaryType();
        monster.getMonsterCurrentStatus();
        monster.getCurrentHP();
        monster.getATK();
        monster.getDEF();
        monster.getMAT();
        monster.getMDF();
        monster.getAGL();
        monster.getBaseATK();
        monster.getBaseDEF();
        monster.getBaseMAT();
        monster.getBaseMDF();
        monster.getBaseAGL();
        monster.getMoveOne();
        monster.getMoveTwo();
        monster.getMoveThree();
        monster.getMoveFour();
        monster.getHeldItem();
        this.GetComponent<SpriteRenderer>().sprite = monster.getFrontSprite();
    }
}


/*
This class is for displaying a monster using the scriptable object.
The getters can be removed they are just there for testing.
-CJ-
*/