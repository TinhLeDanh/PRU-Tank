using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameEntity : MonoBehaviour
{
    public BaseEntityData data;

    protected IGameEntityComponent[] EntityComponents { get; private set; }

    private void Awake()
    {
        EntityComponents = GetComponents<IGameEntityComponent>();
        foreach (IGameEntityComponent component in EntityComponents)
        {
            component.EntityAwake();
            component.Enabled = true;
        }
        EntityAwake();
    }

    protected virtual void EntityAwake() { }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < EntityComponents.Length; ++i)
        {
            if (EntityComponents[i].Enabled)
                EntityComponents[i].EntityStart();
        }
        EntityStart();
    }

    protected virtual void EntityStart() { }

    private void Update()
    {
        for (int i = 0; i < EntityComponents.Length; ++i)
        {
            if (EntityComponents[i].Enabled)
                EntityComponents[i].EntityUpdate();
        }

        EntityUpdate();
    }

    protected virtual void EntityUpdate()
    {
    }

    private void FixedUpdate()
    {
        EntityFixedUpdate();
    }

    protected virtual void EntityFixedUpdate()
    {
    }
}
