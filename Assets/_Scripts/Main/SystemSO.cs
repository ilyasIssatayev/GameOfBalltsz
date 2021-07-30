
public class SystemSO : SerializedScriptableObject
{
    public virtual void Init()
    {

    }

    // Regular update, called every frame, no matter what.
    public virtual void OnUpdate()
    {
    }


    //Fixed Update, called every fixed time step
    public virtual void OnFixedUpdate()
    {

    }

    // Late Update, called every frame, after all OnUpdates have been called
    public virtual void OnLateUpdate()
    {
    }

    // will be called when e.g. the scene is reloaded
    public virtual void Cleanup()
    {
    }
}
