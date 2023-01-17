using Discord.WebSocket;

namespace GlobalShortcuts
{
    public class DiscordIDs
    {
        public ulong channel;

        #region Permissions
        //Public bools for command perms
        public static bool IsMod(SocketUser user)
        {
            //use IsMod(message.Author)
            return
                //Larson
                user.Id == 894987795058290688 ||
                //Joe
                user.Id == 382192994683715584;
        }

        public static bool IsProactive(SocketUser user)
        {
            return
                //Brittney
                user.Id == 784888461076987994 ||
                //Dennis
                user.Id == 388322924295356416 ||
                //Jake
                user.Id == 186277061084577804 ||
                //Larson
                user.Id == 382192994683715584 ||
                //Joe
                user.Id == 894987795058290688;
        }

        public static bool IsDegen(SocketUser user)
        {
            return
                //Becky 
                user.Id == 789985474600763412 ||
                //Dan
                user.Id == 146412531890651136 ||
                //Dan B
                user.Id == 625899912118140948 ||
                //Deon
                user.Id == 768935364945117245 ||
                //Kikko
                user.Id == 407685801535733760 ||
                //Marty
                user.Id == 294263524555751425 ||
                //Timm
                user.Id == 159463326286479360 ||
                //Will
                user.Id == 427291522472345600;
        }

        public static bool IsNotMod(SocketUser user)
        {
            return
                //Becky 
                user.Id == 789985474600763412 ||
                //Brittney
                user.Id == 784888461076987994 ||
                //Dan
                user.Id == 146412531890651136 ||
                //Dan B
                user.Id == 625899912118140948 ||
                //Dennis
                user.Id == 388322924295356416 ||
                //Deon
                user.Id == 768935364945117245 ||
                //Jake
                user.Id == 186277061084577804 ||
                //Kikko
                user.Id == 407685801535733760 ||
                //Marty
                user.Id == 294263524555751425 ||
                //Rob
                user.Id == 134445703169703936 ||
                //Timm
                user.Id == 159463326286479360 ||
                //Will
                user.Id == 427291522472345600;
        }
        #endregion Permissions

        #region User IDs
        //Everyone
        public static bool Everybody(SocketUser user)
        {
            return
                // Mods
                //Larson
                user.Id == 894987795058290688 ||
                //Joe
                user.Id == 382192994683715584 ||

                //Non mods
                //Becky
                user.Id == 789985474600763412 ||
                //Brittney
                user.Id == 784888461076987994 ||
                //Dan
                user.Id == 146412531890651136 ||
                //Dan B
                user.Id == 625899912118140948 ||
                //Dennis
                user.Id == 388322924295356416 ||
                //Deon
                user.Id == 768935364945117245 ||
                //Jake
                user.Id == 186277061084577804 ||
                //Kikko
                user.Id == 407685801535733760 ||
                //Marty
                user.Id == 294263524555751425 ||
                //Rob
                user.Id == 134445703169703936 ||
                //Timm
                user.Id == 159463326286479360 ||
                //Will
                user.Id == 427291522472345600;
        }

        //Everyone minus Will
        public static bool AllButWill(SocketUser user)
        {
            return
                // Mods
                //Larson
                user.Id == 894987795058290688 ||
                //Joe
                user.Id == 382192994683715584 ||

                //Pleb minus Will
                //Becky
                user.Id == 789985474600763412 ||
                //Brittney
                user.Id == 784888461076987994 ||
                //Dan
                user.Id == 146412531890651136 ||
                //Dan B
                user.Id == 625899912118140948 ||
                //Dennis
                user.Id == 388322924295356416 ||
                //Deon
                user.Id == 768935364945117245 ||
                //Jake
                user.Id == 186277061084577804 ||
                //Kikko
                user.Id == 407685801535733760 ||
                //Marty
                user.Id == 294263524555751425 ||
                //Rob
                user.Id == 134445703169703936 ||
                //Timm
                user.Id == 159463326286479360;
        }

        //Just Will
        public static bool WillTheJew(SocketUser user)
        {
            return
                //Will
                user.Id == 427291522472345600;
        }

        //Bots
        public static bool IsBob(SocketUser user)
        {
            return
                user.Id == 895393051982307349;
        }

        public static bool IsRobsBestFriend(SocketUser user)
        {
            return
                user.Id == 897566501454872616;
        }

        public static bool IsAllBots(SocketUser user)
        {
            return
                //Bob
                user.Id == 895393051982307349 ||
                //Rob's bot
                user.Id == 897566501454872616;
        }
        #endregion User IDs

        #region Channel IDs
        //Announcements
        public static bool IsAnnouncements(ISocketMessageChannel channel)
        {
            return
                channel.Id == 892119171159179276;
        }

        public static bool IsProactiveAnnouncements(ISocketMessageChannel channel)
        {
            return
                channel.Id == 922896349836488724;
        }


        //Work Chats
        public static bool IsProactiveChat(ISocketMessageChannel channel)
        {
            return
                channel.Id == 892114358803513364;
        }

        //Version 6
        public static bool IsHelpDesk(ISocketMessageChannel channel)
        {
            return
                channel.Id == 1037109157750374482;
        }


        // Fun Zone
        // Version 6
        public static bool IsChillChat(ISocketMessageChannel channel)
        {
            return
                channel.Id == 1037109287874474014;
        }

        public static bool IsMemes(ISocketMessageChannel channel)
        {
            return
                channel.Id == 1037109396657946725;
        }

        public static bool IsPolitics(ISocketMessageChannel channel)
        {
            return
                channel.Id == 1037109501842698320;
        }

        //Bot testing
        public static bool IsIBSTesting(ISocketMessageChannel channel)
        {
            return
                channel.Id == 895367300390211634;
        }

        #endregion Channel IDs

    }
}
