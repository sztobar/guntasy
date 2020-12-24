namespace Kite {
  public class StateMachine {

    private IState currentState = new EmptyState();

    public void TransitionToState(IState newState) {
      if (currentState == newState) {
        return;
      }
      currentState.ExitState();
      currentState = newState;
      currentState.StartState();
    }

    public void UpdateState() {
      currentState.UpdateState();
    }

    public void ExitState() {
      currentState.ExitState();
    }

    public void Reset() {
      TransitionToState(new EmptyState());
    }
  }
}
