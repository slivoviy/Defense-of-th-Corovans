using UnityEngine;

namespace Scriptable_Objects {
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy", order = 1)]
    public class Enemy : ScriptableObject {
        public string enemyName;

        public Sprite picture;

        public int health;
        public int moneyForKill;
        public int damage;
        
    }
}