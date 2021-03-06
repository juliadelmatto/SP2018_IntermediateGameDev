﻿using System;
using UnityEngine;

namespace Timing
{
    /// <inheritdoc />
    /// <summary>
    /// SharpTimers are handled by the TimeLord, or some other object that makes the timers run
    /// </summary>
    public class SharpTimer : ITimer
    {
        private float _timer;
        private float _timerInit;
        private bool _timerLoop;
        private Action _onTimerEndDelegate;

        /// <inheritdoc />
        public bool RunTimer()
        {
            if (_timer <= 0)
            {
                _onTimerEndDelegate();
                if (_timerLoop) ResetTimer();
                return true;
            }
            _timer -= Time.deltaTime;
//            Debug.Log(_timer);
            return false;
        }

        public void StartTimer(float timerLength, Action onTimerEnd, bool loop = false)
        {
            _timerInit = timerLength;
            _timer = timerLength;
            _timerLoop = loop;
            if (onTimerEnd != null)
                _onTimerEndDelegate = onTimerEnd;
        }

        public void ResetTimer()
        {
            _timer = _timerInit;
        }
    }
}