using System;
using UnityEngine;

namespace Core
{
    public class ProjectUpdater : MonoBehaviour, IProjectUpdater
    {
        public static IProjectUpdater Instance { get; private set; }

        public bool IsPaused
        {
            get => _isPaused;
            set
            {
                if (IsPaused == value)
                {
                    return;
                }
                _isPaused = value;
                Time.timeScale = _isPaused ? 0 : 1;
            }
        }
        private bool _isPaused;
        
        public event Action UpdateCalled;
        public event Action FixedUpdateCalled;
        public event Action LateUpdateCalled;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if (IsPaused)
            {
                return;
            }
            UpdateCalled?.Invoke();
        }

        private void FixedUpdate()
        {
            if (IsPaused)
            {
                return;
            }
            FixedUpdateCalled?.Invoke();
        }

        private void LateUpdate()
        {
            if (IsPaused)
            {
                return;
            }
            LateUpdateCalled?.Invoke();
        }
    }

    public interface IProjectUpdater
    {
        event Action UpdateCalled;
        event Action FixedUpdateCalled;
        event Action LateUpdateCalled;
    }
}