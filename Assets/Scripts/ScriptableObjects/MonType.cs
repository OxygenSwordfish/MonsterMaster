using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Type", menuName = "Types/Make new type")]
public class MonType: ScriptableObject
{
   public string typeName;

   public List<MonType> strongAgainst;
   public List<MonType> weakAgainst;
   public List<MonType> noEffect;
}
