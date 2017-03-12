using System.Collections;
using System.Collections.Generic;

public class Health{

	public int DamageHealth (int health, int damage)
	{
		health -= damage;
		int newHealth = health;
		return newHealth;
	}

	public int HealHealth (int health, int healAmount, int maxHealth)
	{
		health += healAmount;
		if (health > maxHealth) {
			health = maxHealth;
		}
		int newHealth = health;
		return newHealth;
	}

}
