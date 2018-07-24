using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class LinkBreakDistanceSystem : ComponentSystem {

    private struct Filter
    {
        public ComponentArray<LinkComp> linkComp;
        public EntityArray entity;
        public readonly int Length;

    }

    [Inject] Filter group;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            if (group.linkComp[i].linkLength >= group.linkComp[i].linkBeakDistance)
            {
                GameObject.Destroy(group.linkComp[i].gameObject);
                PostUpdateCommands.DestroyEntity(group.entity[i]);
            }
        }
    }    
}

