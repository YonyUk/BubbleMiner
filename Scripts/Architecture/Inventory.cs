using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Architecture.Eqquipables;

namespace Architecture{

	public class Inventory{
		// Capacidad del inventario
		public int Capacity { get ; private set; }
		// Items
		IEqquipable[] items { get; set; }
		// puntero con la siguiente posicion disponible
		int pointer { get; set; }

		public Inventory(int capacity){
			Capacity = capacity;
			items = new IEqquipable[capacity];
			pointer = 0;
		}

		public IEnumerable<IEqquipable> Items {
			get{
				for (int i = 0; i < pointer; i++)
					yield return items[i];
				yield break;
			}
		}

		public bool Add(IEqquipable item){
			if (pointer == Capacity)
				return false;
			items [pointer] = item;
			pointer ++;
			return true;
		}
		// remueve el objeto en la posicion dada
		public bool Remove(int index){
			if (pointer == 0 || 0 > index - 1 || index - 1 > pointer - 1)
				return false;
			IEqquipable temp = items [pointer - 1];
			items [pointer - 1] = null;
			if (index  - 1 < pointer - 1)
				items [index - 1] = temp;
			pointer --;
			return true;
		}
	}
}