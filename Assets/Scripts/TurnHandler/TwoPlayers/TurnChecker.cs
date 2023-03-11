using System;
using System.Collections.Generic;
using UnityEngine;

namespace TurnHandler.TwoPlayers
{
    public class TurnChecker: MonoBehaviour
    {
         public bool _isFirstPlayerTurn;
         public List<GameObject> _spawners;

         private void Start()
         {
             _isFirstPlayerTurn = true;
         }

         private void Update()
         {
             if (_isFirstPlayerTurn)
             {
                 HandleSpawnersForSecondPlayer();
             }
             else
             {
                 HandleSpawnersForFirstPlayer();
             }
         }

         private void HandleSpawnersForFirstPlayer()
         {
             for (int i = 0; i < 5; i++)
             {
                 _spawners[i].SetActive(false);
             }
             for (int i = 5; i < 10; i++)
             {
                 _spawners[i].SetActive(true);
             }
         }

         private void HandleSpawnersForSecondPlayer()
         {
             for (int i = 0; i < 5; i++)
             {
                 _spawners[i].SetActive(true);
             }
             for (int i = 5; i < 10; i++)
             {
                 _spawners[i].SetActive(false);
             }
         }
    }
}