using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using System.ComponentModel;
using Unity.Transforms;

public class ConnectionSpawnSystem : ComponentSystem {

    private struct Filter
    {
        public ComponentArray<Transform> transform;
        public ComponentArray<TreeNodeComp> treeNodeComp;
        public EntityArray entity;
        public readonly int Length;

        //public ComponentDataArray<Position> Position;

    }

    [Inject] Filter group;

    private Collider[] overlapSphereColliders;

    protected override void OnUpdate() {


        for (int i = 0; i < group.Length; i++)
        {
            //Debug.Log(entity.GetHashCode());

            //check if in range
            overlapSphereColliders = Physics.OverlapSphere(group.transform[i].position, group.treeNodeComp[i].linkDistance);

            foreach (Collider col in overlapSphereColliders) { }

            PostUpdateCommands.AddComponent(group.entity[i], new OnConnecting() { nodeID = 1,   entity = group.entity[i] });
        }
    }
}

//basically the event Component that gets attached to the entity which has to establish an connection
public struct OnConnecting : IComponentData
{
    public int nodeID;
    public Entity entity;
}


