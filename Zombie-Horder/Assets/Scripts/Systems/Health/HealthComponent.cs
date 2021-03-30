using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Systems.Health
{
    public class HealthComponent : MonoBehaviour, IDamagable
    {
        public float Health => CurrentHealth;
        public float MaxHealth => TotalHealth;
    
        [SerializeField]
        private float CurrentHealth;
        [SerializeField]
        private float TotalHealth;
    
        protected virtual void Start()
        {
            CurrentHealth = TotalHealth;

            CurrentHealth = 50;
        }

        public virtual void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
    
            if (CurrentHealth <= 0)
            {
                Destroy();
            }
        }
    
        public virtual void Destroy()
        {
            Destroy(gameObject);
        }

        public void HealPlayer(int effect)
        {
            if (CurrentHealth < MaxHealth)
            {
                CurrentHealth = Mathf.Clamp(CurrentHealth + effect, 0, MaxHealth);
            }
        }
    }
}
