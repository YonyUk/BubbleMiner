using UnityEngine;
using System.Collections;

namespace Architecture.Resource{
	public interface IResource{
		Resources Type { get; }
	}
}