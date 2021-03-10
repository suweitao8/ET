using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ETHotfix
{
    public class BasePrefs
    {
        protected string key;

        public BasePrefs(string key)
        {
            this.key = key;
        }
    }

    public class StringPrefs : BasePrefs
    {
        private string _value;
        public string Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                onValueChanged?.Invoke(value);
                PlayerPrefs.SetString(key, _value);
            }
        }

        public Action<string> onValueChanged;

        public StringPrefs(string key, string defaultValue = "") : base(key)
        {
            Value = PlayerPrefs.GetString(key, defaultValue);
        }
    }

    public class IntPrefs : BasePrefs
    {
        private int _value;
        public int Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                onValueChanged?.Invoke(value);
                PlayerPrefs.SetInt(key, _value);
            }
        }

        public Action<int> onValueChanged;

        public IntPrefs(string key, int defaultValue = 0) : base(key)
        {
            Value = PlayerPrefs.GetInt(key, defaultValue);
        }
    }

    public class FloatPrefs : BasePrefs
    {
        private float _value;
        public float Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = value;
                onValueChanged?.Invoke(value);
                PlayerPrefs.SetFloat(key, _value);
            }
        }

        public Action<float> onValueChanged;

        public FloatPrefs(string key, float defaultValue = 0f) : base(key)
        {
            Value = PlayerPrefs.GetFloat(key, defaultValue);
        }
    }
}
