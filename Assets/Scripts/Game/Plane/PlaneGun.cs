using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LastPlayer.Filter.Plane
{
    public class PlaneGun : MonoBehaviour
    {
        [Header("Reference")]
        public Transform machineGun;
        public Transform missileL;
        public Transform missileR;

        private Transform nextMissile;
        private float gunTimer = 0;
        private float missileTimer = 0;
        private bool shootGun = true;
        private bool shootMissile = true;

        [Header("Reference")]
        public Weapon gun;
        public Weapon missile;

        private void Awake()
        {
            nextMissile = missileL;
            gameObject.layer = 9;
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
            }
            else if (shootMissile && Input.GetKey(KeyCode.N))
            {
                shootMissile = false;
                missileTimer = 0;
                if (nextMissile == missileL) nextMissile = missileR;
                else if (nextMissile == missileR) nextMissile = missileL;
                missile.CreateInstance(transform, transform, nextMissile);
            }
        }

        private void FixedUpdate()
        {
            gunTimer += Time.fixedDeltaTime;
            missileTimer += Time.fixedDeltaTime;
        }
    }
}