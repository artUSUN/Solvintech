using UnityEngine;

public abstract class State : ScriptableObject
{
    public bool IsFinished { get; protected set; }
    public Character Character { get; set; }

    public virtual void Init() { }

    public abstract void Run();
}
