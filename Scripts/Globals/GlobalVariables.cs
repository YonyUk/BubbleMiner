using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Variables
{

    public static class Globals
    {
        public static string playerTag = "Player";
        public static string plantsTag = "OxigenPlants";
        public static string animalTag = "Animal";
        public static string harpoonlTag = "Harpoon";
        public static string harpoonlBarTag = "HarpoonBar";
        public static string mineTag = "Mine";
        public static string foodTag = "food";
        public static int bubbleStorageCapacity = 100;
        public static int foodStorageCapacity = 10;
        public static int drillStorageCapacity = 10;
        public static int BubblesProduceControler = 2;
        public static int FoodProduceControler = 2;
        public static float attack_speed_factor = 4;
        public static float explore_speed_factor = 0.5f;
        public static int explore_range = 25;
        public static float min_distance_to_contact = 5f;
        public static float max_distance_to_contact = 5f;

        public static int time_bettwen_attack = 5;
    }

}
