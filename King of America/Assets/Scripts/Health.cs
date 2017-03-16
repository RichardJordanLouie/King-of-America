using System.Collections;
using System.Collections.Generic;

public class Health{

	public static float DamageHealth (float health, float damage)
	{
		health -= damage;
		float newHealth = health;
		return newHealth;
	}

	public static float HealHealth (float health, float healAmount, float maxHealth)
	{
		health += healAmount;
		if (health > maxHealth) {
			health = maxHealth;
		}
		float newHealth = health;
		return newHealth;
	}

}
