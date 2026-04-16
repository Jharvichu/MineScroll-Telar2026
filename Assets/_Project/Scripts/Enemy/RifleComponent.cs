using UnityEngine;

namespace Enemy
{
    public class RifleComponent : MonoBehaviour, IAttackComponent
    {
        public void Attack()
        {
            Debug.Log("Atacado con Rifle");
        }
    }
}