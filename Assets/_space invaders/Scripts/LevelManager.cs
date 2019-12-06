﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] private InvaderWaveList waveList;
    public static Wave wave;
    [SerializeField] private GameObject enemyHolder;
    public static UnityEvent enemyDead = new UnityEvent();
    private int level;
    private bool noEnemiesLeft = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        enemyDead.AddListener(EnemyDead);
    }

    public void EnemyDead()
    {
        noEnemiesLeft = true;
        foreach (var enemy in wave.enemies)
        {
            if (enemy.activeInHierarchy)
            {
                noEnemiesLeft = false;
                break;
            }
        }

        if (noEnemiesLeft)
        {
            foreach (var enemy in wave.enemies)
            {
                Destroy(enemy.gameObject);
            }

            level++;
            if (level == waveList.invaderWaves.Count)
            {
                level = 1;
            }
            wave = waveList.GetInvaderWave(level);
            wave.Init(enemyHolder);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
      wave = waveList.GetInvaderWave(level);
    wave.Init(enemyHolder);
    }

    // Update is called once per frame
    void Update()
    {
        wave.Update();
    }
}