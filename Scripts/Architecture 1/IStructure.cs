using UnityEngine;
using Architecture.Resource;
using Resources = Architecture.Resource.Resources;

namespace Architecture.Structures{
    public interface IStructure<T>
    {
        Resources Material{get; }
        T Produce();
        void AddResource(IResource resource);
    }
}
