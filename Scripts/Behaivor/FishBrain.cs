using UnityEngine;
using System.Collections;
using Variables;

public class FishBrain : Animals {

	Vector3 attack_target { get; set; }
	float explore_range { get; set; }
	float counter { get; set; }
	bool time_to_attack { get; set; }
	Vector3 static_position { get; set; }
	Vector3 temporal_point { get; set; }
	System.Random random { get; set; }

	void Start(){
		time_to_attack = true;
		random = new System.Random ();
		static_position = transform.position;
		temporal_point = static_position;
		attack_target = new Vector3 (2, 0, 2);
		counter = 1;
	}

	public void LookAroundStaticPoint(){
		if ((transform.position - temporal_point).magnitude < Globals.min_distance_to_contact && time_to_attack)
			temporal_point = static_position + new Vector3 (random.Next (-1 * Globals.explore_range, Globals.explore_range), 0f, random.Next (-1 * Globals.explore_range, Globals.explore_range));
		Vector3 move_direction = temporal_point - transform.position;
		transform.Translate (move_direction.normalized * Speed * Globals.explore_speed_factor);
	}

	public void Attack(Vector3 target){
		Vector3 move_direction = new Vector3();
		if (time_to_attack) {
			move_direction = target - transform.position;
			transform.Translate (move_direction.normalized * Speed * Globals.attack_speed_factor);
		} else {
			move_direction = transform.position - target;
			transform.Translate(move_direction.normalized * Speed);
		}
		if ((transform.position - target).magnitude < Globals.min_distance_to_contact)
			time_to_attack = false;
	}
	void Update(){
		if (counter >= Globals.time_bettwen_attack) {
			counter = 0;
			time_to_attack = true;
		}
		counter ++;
		if (Attaking)
			Attack (attack_target);
		else
			LookAroundStaticPoint ();
	}
}
