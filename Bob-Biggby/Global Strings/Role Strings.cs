using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalStrings
{
    public class RoleStrings
    {
        public static string CustodianRole()
        {
            var custodian = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.custodian);
            return custodian;
        }

        public static string PumphouseAdmin()
        {
            var admin = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.pumphouseAdmin);
            return admin;
        }

        public static string TeamLeader()
        {
            var teamLeader = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.teamLeader);
            return teamLeader;
        }

        public static string Tier2()
        {
            var tier2 = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.tier2);
            return tier2;
        }

        public static string BetaBob()
        {
            var betaBob = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.betaBob);
            return betaBob;
        }

        public static string Proactive()
        {
            var proactive = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.proactive);
            return proactive;
        }

        public static string Degen()
        {
            var degen = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.degen);
            return degen;
        }

        public static string Granger()
        {
            var granger = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.granger);
            return granger;
        }

        public static string RaidLeader()
        {
            var raidLeader = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.raidLeader);
            return raidLeader;
        }

        public static string RobsBestFriend()
        {
            var noc = GlobalShortcuts.RoleSwitches.DiscordRoles(GlobalEnums.Roles.robsBot);
            return noc;
        }
    }
}
