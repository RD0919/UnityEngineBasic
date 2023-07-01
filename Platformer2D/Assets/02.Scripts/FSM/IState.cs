using System;
public interface IState<T> where T : Enum
{//상태를 추상화함
    bool canExecute { get; }

    public enum Step
    {
        None,
        Start,
        Casting,
        OnAction,
        Finish
    }
    Step step { get; }
    T MoveNext();// 다음 단계로 넘어감
    void Reset();

}
