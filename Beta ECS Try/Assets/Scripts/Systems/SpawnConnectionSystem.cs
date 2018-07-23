using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class SpawnConnectionSystem :ComponentSystem {

    private struct Filter
    {
        public ComponentDataArray <OnConnecting> onConnecting;
        public EntityArray entity;
        public readonly int Length;
    }

    [Inject] Filter group;

    // Update is called once per frame
    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            Debug.Log("connectionEstablished");
            PostUpdateCommands.RemoveComponent<OnConnecting>(group.entity[i]);
        }  
    }
}

