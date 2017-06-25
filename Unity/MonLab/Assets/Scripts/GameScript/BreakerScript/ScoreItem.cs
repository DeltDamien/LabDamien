using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : MonoBehaviour {

    public int ScoreToAdd;

    public void AddScore()
    {
        Debug.Log(ScoreToAdd + "  score added");
    }
}
