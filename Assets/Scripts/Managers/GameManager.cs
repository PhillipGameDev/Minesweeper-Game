﻿using System.Collections.Generic;
using Core;
using DaltonLima.Core;
using UnityEngine;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] public List<FieldSetup> fieldSetups;
        [SerializeField] public List<CellTheme> cellThemes;
        public FieldSetup CurrentFieldSetup;

        private void Awake()
        {
            CurrentFieldSetup = fieldSetups[0];
            
            Field.OnGameStart += HandleGameStart;
            Field.OnGameLost += HandleGameLost;
            Field.OnGameWon += HandleGameWon;
        }

        private void OnDestroy()
        {
            Field.OnGameStart -= HandleGameStart;
            Field.OnGameLost -= HandleGameLost;
            Field.OnGameWon -= HandleGameWon;
        }

        public void BootstrapField()
        {
            //TODO: load up these fieldSetups dynamically
            Field.Instance.Init(CurrentFieldSetup);
            InputManager.Instance.gameObject.SetActive(true);
        }
        
        private static void HandleGameStart()
        {
            InputManager.Instance.gameObject.SetActive(true);
        }
        
        private static void HandleGameLost()
        {
            InputManager.Instance.gameObject.SetActive(false);
        }
        
        private static void HandleGameWon()
        {
            InputManager.Instance.gameObject.SetActive(false);
        }
        
    }
}
