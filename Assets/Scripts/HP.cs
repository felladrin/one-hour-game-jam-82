using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField]
    private int value;

    public void ApplyDamage()
    {
        value--;
        if (value <= 0)
        {
            Destroy(gameObject);
        }
    }
}
