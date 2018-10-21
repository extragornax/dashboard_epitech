/*
** EPITECH PROJECT, 2018
** dashboard
** File description:
** About
*/

using System;
using System.Collections.Generic;

namespace Dashboard.Models
{

    public class AboutClient { public string Host { get; set; } }

    public class AboutServer
    {
        public Int32 current_time { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }

    public class About
    {
        public AboutClient Client;
        public AboutServer Server;

        public About()
        {
            Client = new AboutClient();
            Server = new AboutServer();
        }
    }
}
