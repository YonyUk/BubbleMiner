using UnityEngine;
using Architecture.Resource;
using Resources = Architecture.Resource.Resources;

namespace Architecture.Structures{
    public interface IStructure
    {
        Resources Material{get; }
		void Produce(System.Action<Resources,int> action);
        void AddResource(IResource resource);
    }
}
