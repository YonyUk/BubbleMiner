using UnityEngine;
using Architecture.Resource;

namespace Architecture.Structures{
    public interface IStructure
    {
        IResource Material{get; }
        T Produce<T>();
        void AddResource(IResource resource);
    }
}
