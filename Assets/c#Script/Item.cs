using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type {Spear, Fire, Bomb};
    public Type type;
    public int value;

    void Update()
    {
        if(value == 0)
        {
            transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        }
    }
    public void ItemDestroy()
    {
        Destroy(gameObject);
    }
}
