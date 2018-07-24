using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;


public class OrbitSystem : ComponentSystem {

    private struct Filter
    {
        public CubeComponent cubeComp;
        public Transform transform;
        public OrbitComp orbitComp;
    }

    
    private float velocity;
    private Transform parentTrans;

    protected override void OnUpdate()
    {   
        
        foreach (var entity in GetEntities<Filter>())
        {
            //Debug.Log(entity.rb.gameObject.name);
            //entity.trans.RotateAround(entity.orbitComp.rotationPivotPoint, Vector3.up, 10);
            parentTrans = entity.transform.GetComponentInParent<TreeRootComp>().gameObject.transform;

            entity.orbitComp.orbitRadius = Vector3.Distance(entity.transform.position, parentTrans.position);

            //velocity = √ (gravitational constant * total mass / orbit radius)
            velocity = Mathf.Sqrt(entity.orbitComp.gravConst * entity.orbitComp.combinedMass / entity.orbitComp.orbitRadius) * entity.orbitComp.rotSpeed;
            entity.transform.RotateAround(parentTrans.position, Vector3.up, velocity);
        }
    }
}
