﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;

namespace ConsoleClient
{
    class Program
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        public Program()
        {
            try
            {
                // Your query goes below; "KeyPath" is the key in the registry that you
                // want to monitor for changes. Make sure you escape the \ character.
                WqlEventQuery query = new WqlEventQuery(
                     "SELECT * FROM RegistryValueChangeEvent WHERE " +
                     "Hive = 'HKEY_LOCAL_MACHINE'" +
                     @"AND KeyPath = 'SOFTWARE\\Microsoft\\.NETFramework' AND ValueName='InstallRoot'");

                ManagementEventWatcher watcher = new ManagementEventWatcher(query);
                Console.WriteLine("Waiting for an event...");

                // Set up the delegate that will handle the change event.
                watcher.EventArrived += new EventArrivedEventHandler(HandleEvent);

                // Start listening for events.
                watcher.Start();

                // Do something while waiting for events. In your application,
                // this would just be continuing business as usual.
                System.Threading.Thread.Sleep(100000000);

                // Stop listening for events.
                watcher.Stop();
            }
            catch (ManagementException managementException)
            {
                Console.WriteLine("An error occurred: " + managementException.Message);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void HandleEvent(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("Received an event.");
            // RegistryKeyChangeEvent occurs here; do something.
        }

        /// <summary>
        /// </summary>
        public static void Main()
        {
            // Just calls the class above to check for events...
            WmiChangeEventTester receiveEvent = new WmiChangeEventTester();
        }
    }
}
