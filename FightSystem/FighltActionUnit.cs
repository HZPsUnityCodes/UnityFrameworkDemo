using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FighltActionUnit 
{
    
    public MonoBase attacker;
    public MonoBase victim;

    public ElementTimeCount attackEle;
    public ElementAttachment victimEle;

    public FighltActionUnit(MonoBase a, MonoBase v) {
        attacker = a;
        victim = v;
        attackEle = attacker.oneAttack;
        victimEle = attacker.elementAttachment;
    }
}
