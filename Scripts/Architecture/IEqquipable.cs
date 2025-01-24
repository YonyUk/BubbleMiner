using UnityEngine;
using System.Collections;

namespace Architecture.Eqquipables{
	public interface IEqquipable{
		void Use();
		string Name { get; }
	}
}