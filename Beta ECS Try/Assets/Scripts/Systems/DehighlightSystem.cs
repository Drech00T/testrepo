using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class DeHighlightSystem : ComponentSystem
{

    private struct Filter
    {
        public ComponentDataArray<IsHighlighted> isHighlighted;
        public ComponentArray<MeshRenderer> renderer;
        public EntityArray entity;
        public SubtractiveComponent<MouseOver> mouseOver;
        public readonly int Length;
    }

    [Inject] Filter group;

    Material newMat = Resources.Load("NotHighlighted", typeof(Material)) as Material;

    protected override void OnUpdate()
    {
        for (int i = 0; i < group.Length; i++)
        {
            //Debug.Log("should be green now");
            group.renderer[i].material = newMat;
            //PostUpdateCommands.AddComponent(group.entity[i], new IsNotHighlighted());

            PostUpdateCommands.RemoveComponent<IsHighlighted>(group.entity[i]);
        }

    }


}
//public struct IsNotHighlighted : IComponentData
//{
//}