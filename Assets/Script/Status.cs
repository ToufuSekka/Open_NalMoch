using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour{
    public Dictionary<string,bool> StatusChecker;

    public Dictionary<string, int> SpecStat = new Dictionary<string, int>();
    public int Life;
    public int Armor;
    public int Damage;
}
