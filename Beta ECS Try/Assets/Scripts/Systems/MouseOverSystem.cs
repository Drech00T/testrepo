using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Collections;

public class MouseOverSystem : ComponentSystem
{
    Ray ray;
    RaycastHit hit;

    public struct MouseOverTargetGroup
    {
        public ComponentArray<BoxCollider> collider;
        //[ReadOnly] public ComponentDataArray<MouseOverTarget> mouseOverTarget;
        public EntityArray Entity;
        public readonly int Length;
    }

    [Inject] MouseOverTargetGroup group;

    protected override void OnUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        for (int i = 0; i < group.Length; i++)
        {
            if (group.collider[i].Raycast(ray, out hit, 1000.0f))
            {
                PostUpdateCommands.AddComponent(group.Entity[i], new MouseOver() { m= 1});
                Debug.Log("added MouseOver to Entity: " + group.Entity[i].Index);
            }
        }
    }
}

public struct MouseOverTarget : IComponentData
{

}

public struct MouseOver : IComponentData
{
    public int m;
}