using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "SOData", menuName = "SO/SOData", order = 1)]
public class SOData : ScriptableObject
{
    public int Score = 0;
    public int LocalScore = 0;
    public string str = "0";

    public int NumSize = 1;

    public List<ActionNum> ListTask = new List<ActionNum>();

    public bool Subtraction=true;
    public bool Addition = false;
    public bool Multiplication = false;
    public bool Division = false;
}