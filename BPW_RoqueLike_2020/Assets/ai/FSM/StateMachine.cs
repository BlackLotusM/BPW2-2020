namespace RayWenderlich.Unity.StatePatternInUnity
{
	public class StateMachine
	{
		public State CurrentState { get; private set; }

		public void Initialize(State startingState)
		{
			CurrentState = startingState;
			startingState.Enter();
		}

		public void ChangeState(State newState)
		{
			if (CurrentState != null)
			{
				CurrentState.Exit();
			}

			CurrentState = newState;
			newState.Enter();
		}
	}
}