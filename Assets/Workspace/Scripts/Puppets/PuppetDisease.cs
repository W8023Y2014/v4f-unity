﻿// <copyright file="PuppetDisease.cs" company="Maxim Mikulski">Copyright (c) 2016 All Rights Reserved</copyright>
// <author>Maxim Mikulski</author>

using UnityEngine;

namespace V4F.Puppets
{

    [System.Serializable]
    public class PuppetDisease : UniqueObject
    {
        #region Fields
        [SerializeField, HideInInspector]
        private string _title = "#BAD_TITLE";

        [SerializeField, HideInInspector]
        private string _description = "#BAD_TITLE";

        [SerializeField, HideInInspector]
        private Resists _resist= Resists.None;

        [SerializeField, HideInInspector]
        private float[] _modifiers = new float[PuppetSpec.StatsCapacity];
        #endregion

        #region Properties
        public string title
        {
            get { return _title; }            
        }

        public string description
        {
            get { return _description; }            
        }

        public Resists resist
        {
            get { return _resist; }
        }
        #endregion

        #region Methods
        public float GetModifier(Stats stat)
        {
            return _modifiers[stat.GetIndex()];
        }
        #endregion
    }

}
