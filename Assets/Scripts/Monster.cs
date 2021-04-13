using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum monType { NONE, BEAST, HUMANOID, AVIAN, UNDEAD, MATERIAL, ETHEREAL, CONSTRUCT, DEMON, AQUATIC, FLORAL, CELESTIAL, ELDRITCH, DRACONIC, ABBERATION, FEY }
public enum monStatus { NORMAL, DEAD, POISONED, ASLEEP, BLIND, PARALYSED }

public enum lvlSpd { VSLOW, SLOW, FAST, VFAST }
[CreateAssetMenu(fileName = "New Monster", menuName = "Monster/Make new monster")]
public class Monster : ScriptableObject
{
    public int monID;
    public string monName;
    public int monSex;
    public int xp;
    public int LVL;
    public lvlSpd lvlRate;
    public monType type1;
    public monType type2;
    public monStatus curStatus;
    public int curHP;
    public int maxHP;
    public int baseHP;
    public int ATK;
    public int baseATK;
    public int DEF;
    public int baseDEF;
    public int MAT;
    public int baseMAT;
    public int MDF;
    public int baseMDF;
    public int AGL;
    public int baseAGL;
    public int move1;
    public int mEn1;
    public int move2;
    public int mEn2;
    public int move3;
    public int mEn3;
    public int move4;
    public int mEn4;
    public int itemHeld;
    public int status;
    public Sprite icon;
    public Sprite bFront;
    public Sprite bBack;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string DisplayMonsterName()
    {
        Debug.Log(monName);
        return monName;
    }

    public int getMonsterID()
    {
        Debug.Log(monID);
        return monID;
    }

    public int getMonsterSex()
    {
        Debug.Log(monSex);
        return monSex;
    }

    public int getXP()
    {
        Debug.Log(xp);
        return xp;
    }

    public int getLevel()
    {
        Debug.Log(LVL);
        return LVL;
    }

    public lvlSpd getLevelRate()
    {
        Debug.Log(lvlRate);
        return lvlRate;
    }

    public monType getMonsterType()
    {
        Debug.Log(type1);
        return type1;
    }

    public monType getMonsterSecondaryType()
    {
        Debug.Log(type2);
        return type2;
    }

    public monStatus getMonsterCurrentStatus()
    {
        Debug.Log(curStatus);
        return curStatus;
    }

    public int getCurrentHP()
    {
        Debug.Log(curHP);
        return curHP;
    }

    public int getMaxHP()
    {
        Debug.Log(maxHP);
        return maxHP;
    }

    public int getBaseATK()
    {
        Debug.Log(baseATK);
        return baseATK;
    }

    public int getBaseDEF()
    {
        Debug.Log(baseDEF);
        return baseDEF;
    }

    public int getBaseMAT()
    {
        Debug.Log(baseMAT);
        return baseMAT;
    }

    public int getBaseMDF()
    {
        Debug.Log(baseMDF);
        return baseMDF;
    }

    public int getBaseAGL()
    {
        Debug.Log(baseAGL);
        return baseAGL;
    }

    public int getATK()
    {
        Debug.Log(ATK);
        return ATK;
    }

    public int getDEF()
    {
        Debug.Log(DEF);
        return DEF;
    }

    public int getMAT()
    {
        Debug.Log(MAT);
        return MAT;
    }

    public int getMDF()
    {
        Debug.Log(MDF);
        return MDF;
    }

    public int getAGL()
    {
        Debug.Log(AGL);
        return AGL;
    }

    public int getMoveOne()
    {
        Debug.Log(move1);
        return move1;
    }

    public int getMoveTwo()
    {
        Debug.Log(move2);
        return move2;
    }

    public int getMoveThree()
    {
        Debug.Log(move3);
        return move3;
    }

    public int getMoveFour()
    {
        Debug.Log(move4);
        return move4;
    }

    public int getHeldItem()
    {
        Debug.Log(itemHeld);
        return itemHeld;
    }

    public Sprite getFrontSprite()
    {
        return bFront;
    }

    void GainXP(int gainedXP)
    {


        if (this.LVL < 100)
        {
            this.xp += gainedXP;
            int threshold;
            switch (this.lvlRate)
            {
                case lvlSpd.VSLOW:
                    threshold = (int)((5 * (Mathf.Pow(LVL, 3))) / 4);
                    if (this.xp > threshold) this.LevelUp();
                    break;
                case lvlSpd.SLOW:
                    threshold = (int)(((6/5)*Mathf.Pow(this.LVL,3))-(15*(Mathf.Pow(this.LVL,2)))+(100*this.LVL)-140);
                    if (this.xp > threshold) this.LevelUp();
                    break;
                case lvlSpd.FAST:
                    threshold = (int)(Mathf.Pow(this.LVL,3));
                    if (this.xp > threshold) this.LevelUp();
                    break;
                case lvlSpd.VFAST:
                    threshold = (int)((4*(Mathf.Pow(this.LVL, 3)))/5);
                    if (this.xp > threshold) this.LevelUp();
                    break;


            }
        }
    }

    void LevelUp()
    {
        this.LVL += 1;                                  //Increase level
        int hpGain = (this.baseHP / 50);            //Raise HP
        Mathf.Clamp(hpGain, 1, hpGain);
        this.maxHP += hpGain;
        this.curHP += hpGain;

        this.ATK += (int)Mathf.Clamp((this.baseATK / 50), 1, (this.baseATK / 50));  //Raise all base stats
        this.MAT += (int)Mathf.Clamp((this.baseMAT / 50), 1, (this.baseMAT / 50));
        this.DEF += (int)Mathf.Clamp((this.baseDEF / 50), 1, (this.baseDEF / 50));
        this.MDF += (int)Mathf.Clamp((this.baseMDF / 50), 1, (this.baseMDF / 50));
        this.AGL += (int)Mathf.Clamp((this.baseAGL / 50), 1, (this.baseAGL / 50));

    }
}

public class TypeMatch
{
    static float[][] typeChart =
    {                       /*NON BST HMN AVN UND MTR ETH CON DMN AQU FLR CEL ELD DRA ABR FEY*/
        /*NON*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*BST*/ new float[] {1f,  1f, 1f, 1f, 1f,0.5f,0f, 0.5f,1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*HMN*/ new float[] {1f,  2f, 1f,0.5f,0.5f,2f, 0f, 2f, 1f, 1f, 1f, 1f,0.5f, 1f, 1f,0.5f },
        /*AVN*/ new float[] {1f,  1f, 2f, 1f, 1f,0.5f, 1f, 1f, 1f, 2f, 2f,0.5f, 1f, 1f, 1f, 1f },
        /*UND*/ new float[] {1f,  1f, 1f, 1f,0.5f,0.5f, 1f,0.5f, 1f, 0.5f,0.5f,1f,1f,1f,2f,2f },
        /*MTR*/ new float[] {1f,  1f, 1f, 2f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 2f,0.5f,0.5f, 1f },
        /*ETH*/ new float[] {1f,  0f, 1f, 1f, 2f, 1f, 2f,0.5f,0.5f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*CON*/ new float[] {1f,  1f, 1f, 1f, 1f, 2f, 1f, 0.5f, 1f,0.5f,2f, 1f, 1f, 1f, 1f, 2f },
        /*DMN*/ new float[] {1f,  1f, 1f, 1f, 0.5f, 1f,2f,2f, 1f, 1f, 1f, 0.5f, 2f, 1f, 1f,0.5f },
        /*AQU*/ new float[] {1f,  1f, 1f,0.5f, 1f, 2f, 1f, 1f,2f, 1f, 0.5f, 1f, 1f, 1f, 2f, 1f },
        /*FLR*/ new float[] {1f,  1f, 1f, 1f, 1f, 2f, 1f, 0.5f, 1f,2f,0.5f, 1f, 1f,0.5f, 1f, 1f },
        /*CEL*/ new float[] {1f,  1f, 1f, 1f, 2f, 1f,0.5f,0.5f,2f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f },
        /*ELD*/ new float[] {1f,  2f, 1f, 2f, 1f, 1f, 1f, 0.5f,0f, 1f, 1f, 2f, 0.5f, 1f, 1f, 1f },
        /*DRA*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 0.5f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 0f },
        /*ABR*/ new float[] {1f,  1f,0.5f,0.5f, 2f, 1f,0.5f, 1f, 1f, 1f, 2f, 1f, 2f, 1f,0.5f,1f },
        /*FEY*/ new float[] {1f,  2f, 1f,0.5f, 1f, 1f,0.5f,0.5f, 1f, 1f, 1f, 1f, 1f, 2f, 2f, 1f }

    };
}
