using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGameEntityComponent<T> : MonoBehaviour, IGameEntityComponent
    where T : BaseGameEntity
{
    private bool isFoundEntity;
    private T cacheEntity;
    public T Entity
    {
        get
        {
            if (!isFoundEntity)
            {
                cacheEntity = GetComponent<T>();
                isFoundEntity = cacheEntity != null;
            }

            return cacheEntity;
        }
    }

    public T CacheEntity
    {
        get { return Entity; }
    }

    private bool isEnabled;

    public bool Enabled
    {
        get { return isEnabled; }
        set
        {
            if (isEnabled == value)
                return;
            isEnabled = value;
            if (isEnabled)
                ComponentOnEnable();
            else
                ComponentOnDisable();
        }
    }

    public virtual void EntityAwake()
    {
    }

    public virtual void EntityStart()
    {
    }

    public virtual void EntityUpdate()
    {
    }

    public virtual void EntityLateUpdate()
    {
    }

    public virtual void EntityFixedUpdate()
    {
    }

    public virtual void EntityOnDestroy()
    {
    }

    public virtual void ComponentOnEnable()
    {
    }

    public virtual void ComponentOnDisable()
    {
    }
}