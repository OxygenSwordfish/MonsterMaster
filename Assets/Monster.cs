using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        /*DMN*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*AQU*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*FLR*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*CEL*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*ELD*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*DRA*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*ABR*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f },
        /*FEY*/ new float[] {1f,  1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f }

    };
}
