using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer.Filter.Plane
{
    public class PlaneGun : MonoBehaviour
    {
        public Transform machineGun;

        public Transform missileL;
        public Transform missileR;

        public GameObject obj;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                var rb = Instantiate(obj).GetComponent<Rigidbody>();
                rb.transform.position = machineGun.transform.position;
                rb.velocity = transform.forward * 1000;
            }
            else if (Input.GetKey(KeyCode.N))
            {

            }
        }
    }
}