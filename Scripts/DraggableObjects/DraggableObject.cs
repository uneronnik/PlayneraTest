
using System;
using System.Collections.Generic;
using DraggableObjects;
using DraggableObjects.Areas;
using UnityEngine;

public class DraggableObject : MonoBehaviour
{
    private DraggableObjectState _currentState;
    private List<PlacementZone> _zonesUnderObject = new List<PlacementZone>();
    private SpriteRenderer _spriteRenderer;

    public IReadOnlyList<PlacementZone> ZonesUnderObject => _zonesUnderObject;

    private void Start()
    {
        _currentState = new FallingState();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        DraggableObjectState newState = _currentState.Update(this);
        
        //Объекты ниже закрываю собой объекты выше, чтобы была простая иллюзия глубины
        _spriteRenderer.sortingOrder = -(int)(gameObject.transform.position.y * 100);
        
        
        if(newState != null)
        {
            _currentState = newState;
            newState.Enter(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlacementZone>() != null)
        {
            _zonesUnderObject.Add(other.GetComponent<PlacementZone>());
        }
        DraggableObjectState newState = _currentState.OnTriggerEnter(this, other);
        
        if(newState != null)
        {
            _currentState = newState;
            newState.Enter(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlacementZone>() != null)
        {
            _zonesUnderObject.Remove(other.GetComponent<PlacementZone>());
        }
    }
    /// <summary>
    /// Проверяет есть ли зона определенного типа под объектом
    /// </summary>
    public PlacementZone GetZoneUnderObjectByType(Type placementZoneType)
    {
        foreach (var zoneUnderObject in _zonesUnderObject)
        {
            if (zoneUnderObject.GetType() == placementZoneType)
            {
                return zoneUnderObject;
            }
        }
        return null;
    }
}
