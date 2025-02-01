using System;
using System.Collections.Generic;

public class StateMachine<T> where T : IState
{
    private Dictionary<Type, T> _states = new Dictionary<Type, T>();
    private T _state;
    public T State => _state;

    public void StartSetting(Dictionary<Type, T> states)
    {
        _states = states;
    }

    public void ChangeState(Type key)
    {
        if (!_states.ContainsKey(key))
            return;

        T newState = _states[key];

        if (Equals(_state, newState))
            return;

        _state?.Stop();
        _state=newState;
        _state?.Start();
    }
}
