using System;
public interface IState<T> where T : Enum
{//���¸� �߻�ȭ��
    public enum Step
    {
        None,
        Start,
        Casting,
        OnAction,
        Finish
    }
    Step step { get; }
    T MoveNext();// ���� �ܰ�� �Ѿ
    void Reset();

}
