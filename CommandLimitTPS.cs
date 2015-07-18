﻿using System;
using System.Collections.Generic;
using Rocket.Unturned.Commands;
using Rocket.Unturned;
using UnityEngine;
using Rocket.Unturned.Player;

namespace FPSCap
{
    public class CommandLimitTPS : IRocketCommand
    {
        public List<string> Aliases
        {
            get { return new List<string>() { "ltps" }; }
        }

        public void Execute(RocketPlayer caller, string[] command)
        {
            if (command.Length == 0)
            {
                RocketChat.Say(caller, this.Syntax + " - " + this.Help);
                return;
            }
            int limitTPS;
            if (command.Length == 1 && int.TryParse(command[0], out limitTPS))
            {
                //limit the minimum tps that can be used above a value of 0, but less than 10, to 10.
                if (limitTPS > 0 && limitTPS < 10)
                {
                    Application.targetFrameRate = 10;
                }
                else
                {
                    Application.targetFrameRate = limitTPS;
                }
            }
            else
            {
                RocketChat.Say(caller, "Invalid arguments.");
                return;
            }
        }

        public string Help
        {
            get { return "Limits the server tps/fps to the value set in the command. 0 disables the TPS cap."; }
        }

        public string Name
        {
            get { return "limittps"; }
        }

        public bool RunFromConsole
        {
            get { return true; }
        }

        public string Syntax
        {
            get { return "<TPS>"; }
        }
    }
}
