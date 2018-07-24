using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class LinkRotationSystem : ComponentSystem
{
    private struct Filter
    {
        public LinkComp linkComp;
        public Transform transform;
    }

    protected override void OnUpdate()
    {
        foreach (var entity in GetEntities<Filter>())
        {
            for (int i = 0; i < entity.linkComp.connectedNodes.Count; i++)
            {   
                //TODO nur eine Rotation anwenden. hier nur zur sicherheit der loop
                entity.transform.LookAt(entity.linkComp.connectedNodes[0].transform.position);
            }
        }
    }
}
