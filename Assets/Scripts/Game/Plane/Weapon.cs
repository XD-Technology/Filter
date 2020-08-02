using System;
using UnityEngine;

namespace LastPlayer.Filter.Plane
{
    public abstract class Weapon : ScriptableObject
    {
        [Header("Reference")]
        public GameObject Prefab;
        [Header("Setting")]
        public float RateOfFire;
        public float Damage;
        public float Velocity;

        public GameObject CreateInstance(Transform plane, Transform parent, Transform startPoint)
        {
            if (Prefab == null) throw new Exception("Prefab was null");
            else if (plane == null) throw new Exception("Plane was null");
            else if (parent == null) throw new Exception("Parent was null");
            else if (startPoint == null) throw new Exception("Start point was null");
            else
            {
                var obj = Instantiate(Prefab, parent);
                obj.layer = 10;
                try
                {
                    var rb = obj.GetComponent<Rigidbody>();
                    if (rb == null) throw new Exception("No rigidbody was found on prefab");
                    rb.transform.position = startPoint.transform.position;
                    rb.transform.rotation = plane.transform.rotation;
                    rb.velocity = plane.transform.forward * Velocity;
                    Initialize(obj);
                    return obj;
                }
                catch (Exception ex)
                {
                    Destroy(obj);
                    throw ex;
                }
            }
        }

        protected virtual void Initialize(GameObject obj) { }
    }
}