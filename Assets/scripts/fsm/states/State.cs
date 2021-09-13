using UnityEngine;

namespace game.package.fsm
{
    [CreateAssetMenu(menuName = "FSM/State")]
    public class State : ScriptableObject
    {
        public Action[] Actions;
        public Transition[] Transitions;

        public void UpdateState(StateController controller)
        {
            DoActions(controller);
            CheckTransitions(controller);
        }

        private void DoActions(StateController controller)
        {
            for (int i = 0; i < Actions.Length; i++)
            {
                Actions[i].Act(controller);
            }
        }

        private void CheckTransitions(StateController controller)
        {
            for (int i = 0; i < Transitions.Length; i++)
            {
                controller.TransitionToState(Transitions[i].Decision.Decide(controller)
                    ? Transitions[i].TrueState
                    : Transitions[i].FalseState);
            }
        }
    }
}