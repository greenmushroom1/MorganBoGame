using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrototypeGame
{
    public class PlayerStats : MonoBehaviour
    {
        public HealthBar healthBar;
        public AnimationHandler animationHandler;

        [Header("Player Stats")]
        public float _strength=10;
        public float _vitality=10;
        public float _dexterity=10;
        public float _intellgence=10;
        public float _luck=10;
        public float _stamina = 10;

        [Header("For View Only")]
        public int maxHealth;
        public int currentHealth;

        CharacterStat Strength;
        CharacterStat Vitality;
        CharacterStat Dexterity;
        CharacterStat Luck;
        CharacterStat Intellgence;
        CharacterStat Stamina;
        CharacterStat Defense;

        private void Awake()
        {
            Strength = new CharacterStat(_strength);
            Vitality = new CharacterStat(_vitality);
            Stamina = new CharacterStat(_stamina);
            Luck = new CharacterStat(_luck);
            Intellgence = new CharacterStat(_intellgence);
            Dexterity = new CharacterStat(_dexterity);            
        }

        // Start is called before the first frame update
        void Start()
        {
            animationHandler = GetComponent<AnimationHandler>();
            maxHealth = SetMaxHealthFromHleathLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHleathLevel()
        {
            maxHealth = (int)Vitality.Value * 10;
            return maxHealth;
        }

        private int SetBaseDefense()
        {
            return 1;
        }

        public void TakeDamage(int damange)
        {
            currentHealth -= damange;
            healthBar.SetCurrentHealth(currentHealth);

            if (currentHealth <= 0)
            {
                PlayerManager.instance.playerState = "dead";
                animationHandler.PlayTargetAnimation("SwordAndShieldDeath");
            }
        }
    }
}

