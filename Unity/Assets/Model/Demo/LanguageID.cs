﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace ETModel
{
    [RequireComponent(typeof(Text))]
    public class LanguageID : MonoBehaviour
    {
        private string _chinese;
        public string Chinese
        {
            get => _chinese;
            set
            {
                _chinese = value;
                OnTangleChanged();
            }
        }

        Text text;

        private void Awake()
        {
            text = GetComponent<Text>();
            LanguageManager.Instance.onTableChanged += OnTangleChanged;
        }

        private void Start()
        {
            Chinese = text.text;
        }

        void OnTangleChanged()
        {
            text.text = LanguageManager.Instance.GetWord(_chinese);
        }

        private void OnDestroy()
        {
            LanguageManager.Instance.onTableChanged -= OnTangleChanged;
        }
    }
}
