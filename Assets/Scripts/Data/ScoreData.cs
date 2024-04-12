using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData {
    public string playerName;
    public int score;
    
    public ScoreData(string playerName, int score) {
        this.playerName = playerName;
        this.score = score;
    }
}

[Serializable]
public class ScoreDataList {
    public List<ScoreData> scoreList = new List<ScoreData>();
}
