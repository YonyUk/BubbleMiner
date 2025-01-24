using UnityEngine;
using Architecture.Resource;

public class Plants : MonoBehaviour
{
    public IResource Oxygen;
    public IResource Drop(){
        return Oxygen;
    }
}
