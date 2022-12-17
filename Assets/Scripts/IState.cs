public interface IState 
{
    public void OnEnter()
    {
        // code that runs when we first enter the state
    }

    public void OnUpdate()
    {
        // per-frame logic, include condition to transition to a new state
    }

    public void OnExit()
    {
        // code that runs when we exit the state
    }
}