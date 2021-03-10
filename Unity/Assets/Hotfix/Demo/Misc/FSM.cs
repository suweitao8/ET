using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ETHotfix
{
    public enum FSMState
    {
        None,
    }

    /// <summary>
    /// 简单状态机，会有enter和exit
    /// </summary>
    public class FSM
    {
        FSMState _value;
        public FSMState Value
        {
            get { return _value; }
            set
            {
                if (_value == value) return;
                onStateExit?.Invoke(_value);
                _value = value;
                onStateEnter?.Invoke(_value);
            }
        }

        public Action<FSMState> onStateEnter;
        public Action<FSMState> onStateExit;
    }
}