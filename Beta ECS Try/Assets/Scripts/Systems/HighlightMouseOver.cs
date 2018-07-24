using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


[UpdateAfter(typeof(MouseOverSystem))]
public class HighlightMouseOver : ComponentSystem {

    private struct Filter
    {
        public readonly ComponentDataArray<MouseOver> mouseOver;
        public ComponentArray<MeshRenderer> renderer;
        public EntityArray entity;
        public ComponentArray<CubeComponent> cubeComp;
        public readonly int Length;
    }

    [Inject] Filter group;

    Material newMat = Resources.Load("DEV_Orange", typeof(Material)) as Material;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            //Debug.Log("should be green now");
            group.renderer[i].material = newMat;

            if (!EntityManager.HasComponent<IsHighlighted>(group.entity[i]))
            {
                PostUpdateCommands.AddComponent(group.entity[i], new IsHighlighted());
            }

        }

    }

    
}
public struct IsHighlighted : IComponentData
{
}