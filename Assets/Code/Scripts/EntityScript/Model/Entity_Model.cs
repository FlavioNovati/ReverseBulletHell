using System;
using UnityEngine;

public class Entity_Model
{
    public Action<float> OnHpChanged;

    private Vector2 _position;
    private Vector2 _direction;

    private float _hp;
    private float _attack;
    private float _velocity;

    public virtual void Damage(float damage) => HP -= damage;
    public virtual void Heal(float amount) => HP += amount;

    protected float HP
    {
        get => _hp;
        set
        {
            _hp = value;
            OnHpChanged?.Invoke(_hp);
        }
    }

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    public Vector2 Direction
    {
        get => _direction;
        set => _direction = value;
    }
    
    public float Attack
    {
        get => _attack;
        set => _attack = value;
    }

    public float Velocity
    {
        get => _velocity;
        set => _velocity = value;
    }
}