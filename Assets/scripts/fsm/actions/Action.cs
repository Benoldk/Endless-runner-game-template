﻿using UnityEngine;

namespace game.package.fsm
{
    public abstract class Action : ScriptableObject
    {
        public abstract void Act(StateController controller);

        protected virtual void UpdatePosition(StateController controller)
        {
            controller.transform.position += controller.direction * controller.localStats.Speed * Time.deltaTime;
            if (controller.localStats.Speed < controller.localStats.MaxSpeed)
                controller.localStats.Speed += controller.localStats.Acceleration * Time.deltaTime;
        }
    }
}