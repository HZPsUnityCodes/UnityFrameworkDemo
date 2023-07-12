using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombList 
{
    private List<BombClass> bomblist;

    private int MaxBombClassCount;

    private int CurrentCount;

    public BombList(int MaxClassCount) {
        CurrentCount = 0;
        MaxBombClassCount = MaxClassCount;
    }

    public void addBombClass() { 
    
    }

    public void deletBombClass() { 
    
    }

    public int Count() {
        return CurrentCount;
    }
}
