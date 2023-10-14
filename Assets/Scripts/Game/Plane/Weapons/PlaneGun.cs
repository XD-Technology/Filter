using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer.Filter.Plane
{
    public class PlaneGun : MonoBehaviour
    {
        [Header("Values")]
        public int range;

        private Transform nextMissile;
        private float gunTimer = 0;
        private float missileTimer = 0;
        private bool shootGun = true;
        private bool shootMissile = true;

        [Header("Reference")]
        public Transform camTransform;
        public Transform machineGun;
        public Transform missileL;
        public Transform missileR;
        public Weapon gun;
        public Weapon missile;
        public Transform tempBuilding;

        private void Awake()
        {
            //camTransform = Camera.main.transform;
            nextMissile = missileL;
            //gameObject.layer = 9;
        }

        private void Update()
        {
            if (gunTimer >= gun.RateOfFire) shootGun = true;
            if (missileTimer >= missile.RateOfFire) shootMissile = true;

            if (shootGun && Input.GetKey(KeyCode.M))
            {
                shootGun = false;
                gunTimer = 0;
                gun.CreateInstance(transform, transform, machineGun);
                ShootMachineGun();
            }
            else if (shootMissile && Input.GetKey(KeyCode.N))
            {
                shootMissile = false;
                missileTimer = 0;
                if (nextMissile == missileL) nextMissile = missileR;
                else if (nextMissile == missileR) nextMissile = missileL;
                GameObject missileObj = missile.CreateInstance(transform, transform, nextMissile);
                missileObj.GetComponent<HomingMissile>().Init(tempBuilding);
            }
        }

        private void FixedUpdate()
        {
            gunTimer += Time.fixedDeltaTime;
            missileTimer += Time.fixedDeltaTime;
        }

        private void ShootMachineGun()
        {
            Debug.Log("Enemy Hit");
            if (Physics.Raycast(camTransform.position, camTransform.forward, out RaycastHit hit))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}