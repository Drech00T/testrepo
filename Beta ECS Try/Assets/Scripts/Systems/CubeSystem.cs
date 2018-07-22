using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class CubeSystem : ComponentSystem {

    private struct Filter
    {
        public Rigidbody rb;
        public CubeComponent cubeComp;
        public Transform trans;
        public OrbitComp orbitComp;
    }

	protected override void OnUpdate () {
        foreach (var entity in GetEntities<Filter>())
        {
            Debug.Log(entity.rb.gameObject.name);
            entity.trans.RotateAround(entity.orbitComp.rotationPivotPoint,Vector3.up,10);
        }
	}
}
