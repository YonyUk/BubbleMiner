using UnityEngine;
using System.Collections;
using Variables;
using Architecture.Resource;
public class FishBrain : Animals
{

	Vector3 attack_target { get; set; }
	float explore_range { get; set; }
	float counter { get; set; }
	bool time_to_attack { get; set; }
	Vector3 static_position { get; set; }
	Vector3 temporal_point { get; set; }
	System.Random random { get; set; }

	void Start()
	{
		time_to_attack = true;
		random = new System.Random();
		static_position = transform.position;
		temporal_point = static_position;
		attack_target = Movement.mov.transform.position;//player
		counter = 1;
	}
	public void Runaway()
	{
		Vector3 direction = new Vector3((transform.position - attack_target).x, 0, (transform.position - attack_target).z);
		transform.Translate(direction.normalized * Speed);
	}

	void Die()
	{
		Instantiate(food, transform.position, Quaternion.identity, null);
		food.GetComponent<Meat>().unit = Food.Units;
		Destroy(gameObject);
	}
	public void LookAroundStaticPoint()
	{
		if ((transform.position - temporal_point).magnitude < Globals.min_distance_to_contact && time_to_attack)
			temporal_point = static_position + new Vector3(random.Next(-1 * Globals.explore_range, Globals.explore_range), 0f, random.Next(-1 * Globals.explore_range, Globals.explore_range));
		Vector3 move_direction = new Vector3((temporal_point - transform.position).x, 0, (temporal_point - transform.position).z);
		transform.Translate(move_direction.normalized * Speed * Globals.explore_speed_factor);
	}

	public void Attack(Vector3 target)
	{
		Vector3 move_direction = new Vector3();
		if (time_to_attack)
		{
			move_direction = new Vector3((target - transform.position).x, 0, (target - transform.position).z);
			transform.Translate(move_direction.normalized * Speed * Globals.attack_speed_factor);
		}
		else
		{
			move_direction = new Vector3((transform.position - target).x, 0, (transform.position - target).z);
			transform.Translate(move_direction.normalized * Speed);

		}
		if ((transform.position - target).magnitude < Globals.min_distance_to_contact)
			time_to_attack = false;
	}
	void Update()
	{
		attack_target = Movement.mov.transform.position;//player

		if (counter >= Globals.time_bettwen_attack)
		{
			counter = 0;
			time_to_attack = true;
		}
		counter += Time.deltaTime;
		if (Attaking)
			Attack(attack_target);
		else if (Running)
			Runaway();
		else
			LookAroundStaticPoint();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == Globals.playerTag)
			Attaking = true;
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag == Globals.playerTag)
		{
			Attaking = false;
		}
		//Running = false;

	}
}

