using System;
using UnityEngine;

namespace Core.InputView
{
    public class ExternalDeviceInputView : IInputView, IDisposable
    {
        public bool RollDice { get; private set; }

        public ExternalDeviceInputView()
        {
            ProjectUpdater.Instance.UpdateCaller += OnUpdate;
        }
    
        public void ResetOneTimeActions()
        {
            RollDice = false;
        }

        private void OnUpdate()
        {
            RollDice = Input.GetKeyDown(KeyCode.Space);
        }

        public void Dispose()
        {
            ProjectUpdater.Instance.UpdateCaller -= OnUpdate;
        }
    }
}