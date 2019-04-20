﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xiaoyisi_MarkPoint : MonoBehaviour {

    public Xiaoyisi_InteractiveObj _Obj;

    public Manager _manager;

    public int addSafeNumber;
    public int addMoneyNumber;


    private void OnEnable()
    {
        _Obj.Activated += activated;
    }

    private void OnDisable()
    {
        _Obj.Activated -= activated;
    }



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    private void activated()
    {

        _manager.AddMoneyPoints(addMoneyNumber);
        _manager.AddSafePoints(addSafeNumber);


    }
}
