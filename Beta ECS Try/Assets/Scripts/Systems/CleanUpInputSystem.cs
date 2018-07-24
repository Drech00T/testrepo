using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;


[UpdateAfter(typeof(HighlightMouseOver))]
public class CleanUpInputSystem : ComponentSystem
{

    public struct Filter
    {
        public ComponentArray<BoxCollider> collider;
        //[ReadOnly] public ComponentDataArray<MouseOverTarget> mouseOverTarget;
        public EntityArray Entity;
        public readonly int Length;
    }

    [Inject] Filter group;

    protected override void OnUpdate()
    {
      

        for (int i = 0; i < group.Length; i++)
        {
            if (EntityManager.HasComponent<MouseOver>(group.Entity[i]))
                {
                PostUpdateCommands.RemoveComponent<MouseOver>(group.Entity[i]);
            }
        }
    }
}
