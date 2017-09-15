using UnityEngine;

public class NumberGenerator : MonoBehaviour
{
    public virtual int Next()
    {
        return Random.Range(0, 4);
    }

}
