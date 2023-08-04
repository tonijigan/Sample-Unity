using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    private int _value = 100;

    public event UnityAction<Health> OnDeaded;

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            int minValue = 0;
            _value = value;

            if (_value <= minValue)
            {
                Destroy(gameObject);
                OnDeaded?.Invoke(this);
            }
        }
    }
}
