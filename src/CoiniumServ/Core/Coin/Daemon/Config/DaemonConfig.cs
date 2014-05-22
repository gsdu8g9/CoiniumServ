﻿/*
 *   CoiniumServ - crypto currency pool software - https://github.com/CoiniumServ/CoiniumServ
 *   Copyright (C) 2013 - 2014, Coinium Project - http://www.coinium.org
 *
 *   This program is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *
 *   This program is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *   GNU General Public License for more details.
 *
 *   You should have received a copy of the GNU General Public License
 *   along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;

namespace Coinium.Core.Coin.Daemon.Config
{
    public class DaemonConfig:IDaemonConfig
    {
        public bool Valid { get; private set; }
        public string Host { get; private set; }
        public int Port { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }

        public string Url
        {
            get { return string.Format("http://{0}:{1}", this.Host, this.Port); }
        }

        public DaemonConfig(dynamic config)
        {
            if (config == null)
            {
                this.Valid = false;
                return;
            }

            this.Host = !string.IsNullOrEmpty(config.Host) ? config.Host : "0.0.0.0";
            this.Port = config.Port;
            this.Username = config.Username;
            this.Password = config.Password;

            this.Valid = true;
        }
    }
}