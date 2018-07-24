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
        public ComponentArray<BoxCollider> collider;
        public EntityArray entity;
        public readonly int Length;

        //public ComponentDataArray<Position> Position;

    }

    [Inject] Filter group;

    private Collider[] overlapSphereColliders;
    private RaycastHit rayHit;

    protected override void OnUpdate() {


        for (int i = 0; i < group.Length; i++)
        {
            //Debug.Log(entity.GetHashCode());

            //check if in range
            overlapSphereColliders = Physics.OverlapSphere(group.transform[i].position, group.treeNodeComp[i].linkDistance);
            

            foreach (Collider col in overlapSphereColliders) {
                Vector3 rayDirection = col.transform.position - group.transform[i].position;

                if (col.GetComponent<TreeNodeComp>())
                {
                    if (col!= group.collider[i])
                    {

                        //chek if sth in between

                        //Debug.DrawRay(group.transform[i].position, rayDirection, Color.red,0.5f );
                        if (Physics.SphereCast(group.transform[i].position,0.5f, rayDirection, out rayHit, group.treeNodeComp[i].linkDistance))
                        {
                            if (rayHit.collider == col)
                            {
                                Debug.Log("nothing in between");
                                GameObject link = Object.Instantiate(group.treeNodeComp[i].linkPreFab);
                                Vector3 startPoint = group.transform[i].position;
                                Vector3 endPoint = col.transform.position;
                                Vector3 midPoint = (startPoint + endPoint) / 2;
                                link.transform.position = midPoint;
                                link.GetComponent<LinkComp>().connectedNodes.Add(group.transform[i].gameObject);
                                link.GetComponent<LinkComp>().connectedNodes.Add(col.transform.gameObject);
                            }
                            else
                            {
                                //Debug.Log("something in between");
                            }
                        }
                    }
                }
            }

            //PostUpdateCommands.AddComponent(group.entity[i], new OnConnecting() { nodeID = group.entity[i].Index, entity = group.entity[i] });
        }
    }
}

//basically the event Component that gets attached to the entity which has to establish an connection
public struct OnConnecting : IComponentData
{
    public int nodeID;
    public Entity entity;
}
