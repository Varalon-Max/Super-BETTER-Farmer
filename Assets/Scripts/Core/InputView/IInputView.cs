namespace Core.InputView
{
    public interface IInputView
    {
        bool RollDice { get; }
        void ResetOneTimeActions();
    }
}
