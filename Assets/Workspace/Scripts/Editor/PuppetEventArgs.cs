﻿// <copyright file="CreatePuppetEventArgs.cs" company="Maxim Mikulski">Copyright (c) 2016 All Rights Reserved</copyright>
// <author>Maxim Mikulski</author>

using UnityEngine;

using V4F.Puppets;

namespace V4F
{

    public class PuppetEventArgs : System.EventArgs
    {
        #region Properties    
        public string path { get; set; }
        public Puppet puppet { get; set; }
        public PuppetSpec spec { get; set; }
        public PuppetResists resists { get; set; }
        public PuppetSkillSet skillSet { get; set; }
        public Sprite icon { get; set; }
        public string properName { get; set; }
        public GameObject prefab { get; set; }
        public PuppetClass puppetClass { get; set; }
        #endregion

        #region Constructors
        public PuppetEventArgs()
        {
            spec = null;
            resists = null;
            skillSet = null;
            icon = null;
            properName = "#BAD_NAME";
            prefab = null;
            puppetClass = PuppetClass.Warrior;
        }
        #endregion
    }

}
