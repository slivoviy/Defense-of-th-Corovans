using UnityEngine;

namespace Scriptable_Objects {
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon", order = 0)]
    public class Weapon : ScriptableObject {
        public string weaponName;

        public Sprite hands;
        public Sprite icon;

        public int ammoQuantity;
        public float timeToReload;
        public float bulletForce;
        public int bulletDamage;

    }
}