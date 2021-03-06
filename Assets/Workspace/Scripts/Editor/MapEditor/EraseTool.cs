﻿// <copyright file="EraseTool.cs" company="Maxim Mikulski">Copyright (c) 2016 All Rights Reserved</copyright>
// <author>Maxim Mikulski</author>

namespace V4F.MapEditor
{

    public class EraseTool : BaseTool
    {
        private bool _capture;

        public EraseTool(Tools tool) : base(tool)
        {
            _capture = false;
        }

        public override void Enable(Form sender)
        {
            sender.hoverRoomEnabled = true;
            sender.hoverTransitionEnabled = true;
            sender.closestEnabled = false;
        }

        public override bool OnMouseDown(Form sender, ModKey key, int button)
        {
            if (!_capture && (button == 0))
            {
                sender.TryRemoveHall();
                _capture = true;

                return true;
            }

            return false;
        }

        public override bool OnMouseUp(Form sender, ModKey key, int button)
        {
            if (_capture && (button == 0))
            {
                _capture = false;
                return true;
            }

            return false;
        }

    }
	
}
