using System;
using System.Windows.Forms;

namespace GlobalShortcuts
{
    //Strings for DateTime.ToString
    public class ClockTower
    {
        //Day of week, mm/dd/yyyy, hh:mm:ss
        public static DateTime fullLongDateTime = DateTime.Now;
        //long time hh:mm:ss
        public static DateTime currentTime = DateTime.Now;
        //dd/mm/yyyy, h:mm:ss
        public static DateTime day_time = DateTime.Now;
        //day of week full (ie "Monday")
        public static DateTime dayofWeek_full = DateTime.Now;
        //month and date
        public static DateTime monthDay = DateTime.Now;
        //month and year
        public static DateTime yearMonth = DateTime.Now;
    }

    //Switch for Clock Tower
    public class TimeSwitch
    {
        public static DateTime TimeKeeper(GlobalEnums.Watch watch)
        {
            var time = DateTime.Now;

            switch (watch)
            {
                case GlobalEnums.Watch.today:
                    time = ClockTower.fullLongDateTime;
                    break;

                case GlobalEnums.Watch.currentTime:
                    time = ClockTower.currentTime;
                    break;

                case GlobalEnums.Watch.day_time:
                    time = ClockTower.day_time;
                    break;

                case GlobalEnums.Watch.day_of_week:
                    time = ClockTower.dayofWeek_full;
                    break;

                case GlobalEnums.Watch.monthDay:
                    time = ClockTower.monthDay;
                    break;

                case GlobalEnums.Watch.yearMonth:
                    time = ClockTower.yearMonth;
                    break;
            }
            return time;
        }
    }

    //Emote switch
    public class EmoteSwitches
    {
        //IBS
        public static String IBSEmotes(GlobalEnums.IBSEmotesEnum emotes)
        {
            var msg = "IBS Emotes";

            switch (emotes)
            {
                case GlobalEnums.IBSEmotesEnum.BravoFlag:
                    msg = "<:BravoFlag:895359299465932832>";
                    break;

                case GlobalEnums.IBSEmotesEnum.facepalm:
                    msg = "<:facepalm:894992483212226571>";
                    break;

                case GlobalEnums.IBSEmotesEnum.facts:
                    msg = "<:facts:898631388658565192>";
                    break;

                case GlobalEnums.IBSEmotesEnum.fake:
                    msg = "<:fake:898249772111110205>";
                    break;

                case GlobalEnums.IBSEmotesEnum.FuckYou:
                    msg = "<:FuckYou:949001139599314984>";
                    break;

                case GlobalEnums.IBSEmotesEnum.goth_heart:
                    msg = "<:goth_heart:895763260819779614>";
                    break;

                case GlobalEnums.IBSEmotesEnum.Hank:
                    msg = "<:Hank:894993144347758633>";
                    break;

                case GlobalEnums.IBSEmotesEnum.larsoneyes:
                    msg = "<:larsoneyes:895358866567610388>";
                    break; 

                case GlobalEnums.IBSEmotesEnum.martin:
                    msg = "<:martin:894997334793003028>";
                    break;

                case GlobalEnums.IBSEmotesEnum.martin_heart:
                    msg = "<:martin_heart:895764241544544317>";
                    break;

                case GlobalEnums.IBSEmotesEnum.monster:
                    msg = "<:monster:897175009167036496>";
                    break;

                case GlobalEnums.IBSEmotesEnum.no:
                    msg = "<:no:897185321366741073>";
                    break;

                case GlobalEnums.IBSEmotesEnum.omegaroll:
                    msg = "<a:omegaroll:894993865457696890>";
                    break;

                case GlobalEnums.IBSEmotesEnum.partyglasses:
                    msg = "<a:PartyGlasses:894993676047114331>";
                    break;

                case GlobalEnums.IBSEmotesEnum.tom:
                    msg = "<:tom:894992132383850497>";
                    break;

                case GlobalEnums.IBSEmotesEnum.Tux:
                    msg = "<:Tux:895755602461069412>";
                    break;

                case GlobalEnums.IBSEmotesEnum.yes:
                    msg = "<:yes:897185308368584734>";
                    break;

                case GlobalEnums.IBSEmotesEnum.ZuluFlag:
                    msg = "<:ZuluFlag:894992700523307008>";
                    break;
            }

            return msg;
        }

        //Pumphouse Emotes
        public static String PumphouseEmotes(GlobalEnums.PumphouseEmotesEnum emotes)
        {
            var msg = "Pumphouse Emotes";

            switch (emotes)
            {


                case GlobalEnums.PumphouseEmotesEnum.EvilZorra:
                    msg = "<:EvilZorra:463540315068956673>";
                    break;

                case GlobalEnums.PumphouseEmotesEnum.SakamotoDab:
                    msg = "<:SakamotoDab:503354360017846272>";
                    break;



                case GlobalEnums.PumphouseEmotesEnum.solaire:
                    msg = "<:PraiseTheSun:424816211315130378>";
                    break;
            }
            return msg;
        }

        //Emote Server Emotes
        public static String EmoteServerEmotes(GlobalEnums.EmoteServerEnum emotes)
        {
            var msg = "Emote Server Emotes";

            switch (emotes)
            {
                case GlobalEnums.EmoteServerEnum.doubt:
                    msg = "<:doubt:934219518220304414>";
                    break;

                case GlobalEnums.EmoteServerEnum.shadowHaunter:
                    msg = "<:shadowHaunter:930578854450454639>";
                    break;
            }
            return msg;
        }

        //Future Emotes
        public static String FutureEmotes(GlobalEnums.FutureEmotesEnum emotes)
        {
            var msg = "Future Emotes";
            switch (emotes)
            {
                case GlobalEnums.FutureEmotesEnum.e_sus:
                    msg = "<:e_sus:759862043821604914>";
                    break;

                case GlobalEnums.FutureEmotesEnum.fingerguns:
                    msg = "<:finger_guns:704531717234491443>";
                    break;
            }
            return msg;
        }

    }//End Emote Switch

    //Role Switch
    public class RoleSwitches
    {
        public static String DiscordRoles(GlobalEnums.Roles roles)
        {
            var msg = "IBS Roles";
            switch (roles)
            {
                case GlobalEnums.Roles.custodian:
                    msg = "<@&892116080590487612>";
                    return msg;

                case GlobalEnums.Roles.pumphouseAdmin:
                    msg = "<@&353353914223165461>";
                    return msg;

                case GlobalEnums.Roles.teamLeader:
                    msg = "<@&892115805641244672>";
                    return msg;

                case GlobalEnums.Roles.tier2:
                    msg = "<@&892145338843004968>";
                    return msg;

                case GlobalEnums.Roles.betaBob:
                    msg = "<@&895418309942575175>";
                    return msg;

                case GlobalEnums.Roles.proactive:
                    msg = "<@&892117393881583636>";
                    return msg;

                case GlobalEnums.Roles.degen:
                    msg = "<@&892149669248000000>";
                    return msg;

                case GlobalEnums.Roles.granger:
                    msg = "<@&894990200701349908>";
                    return msg;

                case GlobalEnums.Roles.raidLeader:
                    msg = "<@&896095626494881822>";
                    return msg;

                case GlobalEnums.Roles.robsBot:
                    msg = "<@&897567735326846978>";
                    return msg;
            }
            return msg;
        }
    }
}
