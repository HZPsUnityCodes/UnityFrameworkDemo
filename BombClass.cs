using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombClass 
{

    private string bombId;

    private string bombPrefabsPath;

    private int maxBombCount;

    private string info;

    public BombClass(string initId , string path, int maxBombCount) {
        this.bombId = initId;
        this.bombPrefabsPath = path;
        this.maxBombCount = maxBombCount;
    }

    public string getBombId() {
        return this.bombId;
    }

    public string getPrefabPath() {
        return this.bombPrefabsPath;
    }

    public int getMaxBombCount()
    {
        return this.maxBombCount;
    }

    public string getInfo() {
        return this.info;
    }
}
