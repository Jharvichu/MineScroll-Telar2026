using UnityEngine;

namespace Enemy
{
    public class MeleeComponent : MonoBehaviour, IAttackComponent
    {
        public void Attack()
        {
            Debug.Log("Atacado con Melee");
        }
    }
}