﻿using UnityEngine;
using System.Collections;

namespace Architecture.Eqquipables{
	public interface IEqquipable{
		void Use();
		void Upgrade();
		string Name { get; }
	}
}