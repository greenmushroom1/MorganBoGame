using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace PrototypeGame
{
    public class CharacterStat
    {
        public float Basevalue;
        protected bool isDirty = true;
        protected float _value;
        protected readonly List<StatModifier> statModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;

        public float Value
        {
            get
            {
                if (isDirty)
                {
                    _value = CalculateFinalvalue();
                    isDirty = false;
                }
                return _value;
            }
        }

        public CharacterStat()
        {
            statModifiers = new List<StatModifier>();
            StatModifiers = statModifiers.AsReadOnly();
        }

        public CharacterStat(float baseValue) : this()
        {
            Basevalue = baseValue;
        }

        public void AddModifier(StatModifier mod)
        {
            isDirty = true;
            statModifiers.Add(mod);
            statModifiers.Sort(CompareModifierOrder);
        }

        protected int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.Order < b.Order)
                return -1;
            else if (a.Order > b.Order)
                return 1;

            return 0;
        }
        public void RemoveModifier(StatModifier mod)
        {
            isDirty = true;
            statModifiers.Remove(mod);
        }

        public bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;
            for (int i = statModifiers.Count - 1; i >= 0; i--)
            {
                if (statModifiers[i].Source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    statModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }
        protected float CalculateFinalvalue()
        {
            float finalValue = Basevalue;
            float sumPercentAdd = 0;

            for (int i = 0; i < statModifiers.Count; i++)
            {
                StatModifier mod = statModifiers[i];
                if (mod.Type == StatModType.Flat)
                {
                    finalValue += mod.Value;
                }
                else if (mod.Type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.Value;
                    if (statModifiers[i + 1].Type != StatModType.PercentAdd || i + 1 >= statModifiers.Count)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.Type == StatModType.PercentMult)
                {
                    finalValue *= 1 + mod.Value;
                }
            }
            // 12.001f !=12f
            return (float)Math.Round(finalValue, 0);
        }
    }
}
