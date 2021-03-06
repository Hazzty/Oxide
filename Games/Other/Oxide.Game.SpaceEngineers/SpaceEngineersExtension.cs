﻿using System;

using Sandbox;
using Sandbox.Engine.Multiplayer;
using Sandbox.Game;

using Oxide.Core;
using Oxide.Core.Extensions;

namespace Oxide.Game.SpaceEngineers
{
    /// <summary>
    /// The extension class that represents this extension
    /// </summary>
    public class SpaceEngineersExtension : Extension
    {
        /// <summary>
        /// Gets the name of this extension
        /// </summary>
        public override string Name => "SpaceEngineers";

        /// <summary>
        /// Gets the version of this extension
        /// </summary>
        public override VersionNumber Version => new VersionNumber(1, 0, 0);

        /// <summary>
        /// Gets the author of this extension
        /// </summary>
        public override string Author => "Oxide Team";

        public override string[] WhitelistAssemblies => new[]
        {
            "mscorlib", "Oxide.Core", "System", "System.Core"
        };
        public override string[] WhitelistNamespaces => new[]
        {
            "System.Collections", "System.Security.Cryptography", "System.Text"
        };

        public static string[] Filter =
        {
        };

        /// <summary>
        /// Initializes a new instance of the SpaceEngineersExtension class
        /// </summary>
        /// <param name="manager"></param>
        public SpaceEngineersExtension(ExtensionManager manager) : base(manager)
        {
        }

        /// <summary>
        /// Loads this extension
        /// </summary>
        public override void Load()
        {
            // Register our loader
            Manager.RegisterPluginLoader(new SpaceEngineersPluginLoader());

            // Register our libraries
            Manager.RegisterLibrary("SpaceEng", new Libraries.SpaceEngineers());
        }

        /// <summary>
        /// Loads plugin watchers used by this extension
        /// </summary>
        /// <param name="directory"></param>
        public override void LoadPluginWatchers(string directory)
        {
        }

        /// <summary>
        /// Called when all other extensions have been loaded
        /// </summary>
        public override void OnModLoad()
        {
            if (!Interface.Oxide.EnableConsole()) return;

            // TODO: Add console log handling

            Interface.Oxide.ServerConsole.Input += ServerConsoleOnInput;
        }

        internal static void ServerConsole()
        {
            if (Interface.Oxide.ServerConsole == null) return;

            Interface.Oxide.ServerConsole.Title = () => $"{MyMultiplayer.Static?.MemberCount} | {MySandboxGame.ConfigDedicated.ServerName}";
            Interface.Oxide.ServerConsole.Status1Left = () => $" {MySandboxGame.ConfigDedicated.ServerName}";
            /*Interface.Oxide.ServerConsole.Status1Right = () =>
            {
                var fps = Sandbox.Engine.Utils.MyFpsManager.GetFps();
                var seconds = TimeSpan.FromSeconds(??);
                var uptime = $"{seconds.TotalHours:00}h{seconds.Minutes:00}m{seconds.Seconds:00}s".TrimStart(' ', 'd', 'h', 'm', 's', '0');
                return string.Concat(fps, "fps, ", uptime); // MySession.Static.ElapsedGameTime // MySandboxGame.TotalTimeInMilliseconds
            };*/
            Interface.Oxide.ServerConsole.Status2Left = () => $" {MyMultiplayer.Static?.MemberCount}/{MyMultiplayer.Static?.MemberLimit}";
            /*Interface.Oxide.ServerConsole.Status2Right = () =>
            {
                var bytesReceived = Utility.FormatBytes(Main.rxData);
                var bytesSent = Utility.FormatBytes(Main.txData);
                return Main.time <= 0 ? "0b/s in, 0b/s out" : string.Concat(bytesReceived, "/s in, ", bytesSent, "/s out");
            };*/
            /*Interface.Oxide.ServerConsole.Status3Left = () =>
            {
                var time = DateTime.Today.Add(TimeSpan.FromSeconds(Main.mapTime)).ToString("h:mm tt").ToLower();
                return string.Concat(" ", time); // TODO: More info
            };*/
            Interface.Oxide.ServerConsole.Status3Right = () => $"Oxide {OxideMod.Version} for {MyPerGameSettings.BasicGameInfo.GameVersion}";
            Interface.Oxide.ServerConsole.Status3RightColor = ConsoleColor.Yellow;
        }

        private static void ServerConsoleOnInput(string input)
        {
            // TODO: Handle console input
        }
    }
}
