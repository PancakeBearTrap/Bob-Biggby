//System
using System;

//Discord

//Usings not used

namespace CustomReactions
{
    //Last updated 9/28/22
    //Added "test string"

    public class NadekoLCR
    {
        readonly String[] CommandsToAdd =
        {
            //Alpha Bob
            
        };

        readonly String[] CommandsAdded =
        {
            //**
            "*eyeroll*", ":(", ":frowning:", 
            //A
            "a great day",
            //B
            "backup checklist", "be gone vile man", "becky", "big head", "big stupid jellyfish", "bitch", "bitch", "bones day", "boss man", "brittney",
            //C
            "can it wait for a bit?", "castle", "check the handbook", "chloe price", "custodian",
            //D
            "dab", "dan",
            "dan w", "dan w",
            "daniel", "dann", "darth maul", "deal with it", "dennis",
            "dew it", "dew it",
            "do it", "do it", "do it", "do it", "do it",
            //E
            "eat a chode", "eat a dick", "escalate", "ess", "ew", "excellent", "extended it alignments",
            //F
            "fresh prince",
            "fuck", "fuck",
            "fuck off", "fuck that",
            "fuck you", "fuck you", "fuck you",
            "fc3 fuck you",
            //G
            "general kenobi", "great day",
            //H
            "haha good one", "have you checked your butthole", "hehe", "hello there", "help desk", "help desk main line", "help desk mating ritual", "help me", "hmm no",
            "how dare you", "'https://tenor.com/view/balls-sucking-cherry-lick-his-nuts-gif-15332077'",
            //I
            "I am untethered", "I am untethered and my rage knows no bounds",
            "I can do this all day", "I have spoken", "I know some of those words", "I know where it is", "I own you", "I quit",
            "I understand that reference", "I understand that reference",
            "I understood that reference", "I understood that reference",
            "I'll allow it", "I'll just leave", "I'm disappointed", "I'm fine", "I'm totally working", "I'm watching you", "it is decided",
            "it is done", "it is done", "it is done",
            "it's friday", "it's friday losers", "it's monday", "it's time to press buttons",
            //J
            "jake", "jks", "joe", 
            //K
            "kaseya", "kikki", "kikko", "know your place",
            //L
            "larson", "loveall", 
            //M
            "martin", "marty", "mild shock",
            //N
            "noc",
            //O
            "on site", "onsite",
            "oops", "oopsie",
            //P
            "panda rage", "pebcac", "praise the beheaded", "praise the sun", 
            //R
            "rob",
            //S
            "self burn", "shame", "shhh", "signal flags", "slap chris", "stfu", "suck it",
            //T
            "thank you bob", "that's fucking it", "that's rough, buddy", "that's what she said", "the beheaded", "the discord purge", "the worst", "this is the way", "time to work", "tlj",
            //U
            "ugh", "unacceptable", "unlimited power",
            //V
            "vsa",
            //W
            "wait...", "who gives a fuck", "who the hell cares", "winston",
            "wtf", "wtf", "wtf", "wtf", 
            //Y
            "yes, my liege", "you have no power here", "you're a bitch",
            //Z
            "zuko",
        };

        public static string Frown()
        {
            string msg = "https://tenor.com/view/egg-frank-can-i-offer-you-a-nice-egg-in-this-trying-time-gif-13802522";
            return msg;
        }

        public static string AGreatDay()
        {
            //index: 58
            string msg = "https://youtu.be/WRu_-9MBpd4";
            return msg;
        }

        public static string Becky()
        {
            //index: 5v
            string msg = "https://tenor.com/view/artangels-grimes-knight-warrior-sword-gif-4985799";
            return msg;
        }

        //In Pumphouse DB
        public static string BigHead()
        {
            //index: 7h
            string bigHead = "https://cdn.discordapp.com/attachments/989223734781018112/992102167370530836/bigHead.jpg";
            return bigHead;
        }

        //2 responses
        public static string Bitch()
        {
            String[] msg =
            {
                //Suction Cup Korea gif, index: #37
                "https://tenor.com/view/youre-a-bitch-jopstoffels-suctioncupman-gif-11942465",
                //Suction Cup you're a bitch song, index: #38
                "https://www.youtube.com/watch?v=f9zpxWEweWc",
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var bitch = ($"{msg[value]}");

            return bitch;
        }

        public static string BonesDay()
        {
            //index: u
            var bonesDay = "https://www.youtube.com/watch?v=tVOzsA7BaME&ab_channel=JoshuaRegier";
            return bonesDay;
        }

        public static string BossMan()
        {
            //index: 3i
            var bossMan = "https://tenor.com/view/yay-arte-gif-19715102";
            return bossMan;
        }

        public static string Brittney()
        {
            //index: 5f
            string msg = "https://tenor.com/view/ricky-trailer-park-boys-my-brains-shor-circulating-gif-14045185";
            return msg;
        }

        public static string Castle()
        {
            //index: 6b
            var castle = "https://cdn.discordapp.com/attachments/412068411451899925/930925559805005924/IMG_2947.gif";
            return castle;
        }

        public static string CheckTheHandbook()
        {
            //index: 4k
            var Handbook = "https://cdn.discordapp.com/attachments/920025341341351947/941416879505936414/unknown.png";
            return Handbook;

        }

        public static string Dab()
        {
            //index: 74
            string dab = "https://tenor.com/view/dab-slide-slippery-gif-14299663";
            return dab;
        }

        public static string Dan()
        {
            //index: 6g
            string dan = "https://media.discordapp.net/attachments/894991535542788137/966007090491555962/unknown.png";
            return dan;
        }

        //2 responses
        public static string DanW()
        {
            String[] msg =
            {
                //forest gump, index: j
                "https://tenor.com/view/forrest-gump-forrest-gump-wave-hello-gif-13288735", 
                //panda being a dick, index: 3s
                "https://tenor.com/view/panda-cart-shopping-grocery-push-gif-17715527"
            };
            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var danW = ($"{msg[value]}");
            return danW;
        }

        public static string DealWithIt()
        {
            //index: 6s
            string msg = "https://cdn.discordapp.com/attachments/989223734781018112/1017139934282391633/giphy_2.gif";
            return msg;
        }

        public static string Dennis()
        {
            //index: 5d
            string msg = "https://tenor.com/view/help-gif-7380459";
            return msg;
        }

        //2 response
        public static string DewIt()
        {
            String[] msg =
            {
                //Dew it #1, index: f
                "https://cdn.discordapp.com/attachments/895367300390211634/920741002120167514/viddit_d1c084fe.mp4",
                //Dew it #2, index: #4n
                "https://cdn.discordapp.com/attachments/895367300390211634/941708551120887838/tiktok_1644336462238.mp4",
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var dewIt = ($"{msg[value]}");

            return dewIt;
        }

        //5 responses. includes dew it
        public static string DoIt()
        {
            //String in order: dew it, palpatine, Shia "Do it", Shia "What are you waiting for"
            String[] msg =
            {
                //Dew it, #1, index: e
                "https://cdn.discordapp.com/attachments/895367300390211634/920741002120167514/viddit_d1c084fe.mp4",
                //Dew it #2, index: #4m
                "https://cdn.discordapp.com/attachments/895367300390211634/941708551120887838/tiktok_1644336462238.mp4",
                //Sheev, index: #g
                "https://tenor.com/view/do-it-star-wars-gif-4928619",
                //Shia, do it, index: h
                "https://tenor.com/view/do-it-shia-la-beouf-flame-gif-4445204",
                //Shia, what are you waiting for, index: #i
                "https://tenor.com/view/do-it-what-are-you-waiting-for-determined-angry-gif-5247874",
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var doIt = ($"{msg[value]}");

            return doIt;

        }

        public static string EatAChode()
        {
            var eatAChode = "https://youtube.com/shorts/WZjENfDvNsE?feature=share";
            return eatAChode;
        }

        public static string EatADick()
        {
            var eatADick = "https://www.youtube.com/watch?v=zffma5Py92c&list=PLrvVfo9ufJZcj9YjUJx8AagyhBHFpZjgV&index=36";
            return eatADick;
        }

        public static string Escalate()
        {
            //index: y
            var escalate = "https://cdn.discordapp.com/attachments/894991535542788137/896063241095098448/9k.png";
            return escalate;
        }

        public static string ESS()
        {
            //index: 4r
            var ess = "https://cdn.discordapp.com/attachments/920025341341351947/943939768734089287/unknown.png";
            return ess;
        }

        public static string Ew()
        {
            //index: 9
            var ew = "https://cdn.discordapp.com/attachments/895367300390211634/925134245238820914/the_oc_ew.gif";
            return ew;
        }

        public static string Excellent()
        {
            //index: 6p
            string excellent = "https://tenor.com/view/excellent-bill-and-ted-happy-gif-14318181";
            return excellent;
        }

        public static string ExtendedITAlignments()
        {
            //index: 3w
            var itAlignments = "https://cdn.discordapp.com/attachments/895367300390211634/930516339334987836/Extra_Alignment_color.png";
            return itAlignments;
        }

        public static string FreshPrince()
        {
            //index: 3m
            var freshPrince = "fresh prince of bel air was just pretty okay and did not age well";
            return freshPrince;
        }

        public static string Fuck()
        {
            String[] msg =
            {
                //AoE2 Fuck Not Censored, index: 43
                "https://media.discordapp.net/attachments/895367300390211634/931645134691516446/RDT_20220114_1524178313261399590404924.jpg",
                //Witcher, index: 6q
                "https://media.discordapp.net/attachments/895367300390211634/972388680033513563/443f76a3-466c-4063-80f3-926ee124bb06.gif",
            };


            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var fuck = ($"{msg[value]}");

            return fuck;

        }

        public static string FuckOff()
        {
            //index: 59
            //Connor4Real fuck off song
            string msg = "https://youtu.be/t3jKtjgRZQY";
            return msg;
        }

        public static string FuckThat()
        {
            //index: 5r
            string msg = "https://cdn.discordapp.com/attachments/895367300390211634/955910174835613807/viddit_83f62cfb.gif";
            return msg;
        }

        //3 Responses
        public static string FuckYou()
        {
            String[] msg =
            {
                //Suction Cup Man, fuck you song, index: #r
                "https://www.youtube.com/watch?v=jEXjhGJg1Jk",
                //Suction cup man every time he says fuck you, index: #6i
                "https://youtu.be/7V22OCLqovA",
                //Dead Cells the bird
                "https://tenor.com/view/dead-cells-middle-finger-fuck-you-gif-15761204",
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var fuckYou = ($"{msg[value]}");
            return fuckYou;
        }

        public static string GeneralKenobi()
        {
            //index: 32
            var Grevious = "https://tenor.com/view/hello-there-general-kenobi-star-wars-grevious-gif-17774326";
            return Grevious;
        }

        public static string GreatDay()
        {
            //index: 57
            var greatDay = "https://youtu.be/WRu_-9MBpd4";
            return greatDay;
        }

        public static string HahaGoodOne()
        {
            //index: p
            var goodOne = "https://tenor.com/view/jim-carrey-look-hint-allusion-eyes-gif-15443059";
            return goodOne;
        }

        //I know where it is
        public static string HaveYouCheckedYourButthole()
        {
            //index: 54
            var butthole = "https://youtu.be/6IjuSycXjqM";
            return butthole;
        }

        public static string HelloThere()
        {
            //index: z
            var HelloThere = "https://tenor.com/view/hello-there-hi-there-greetings-gif-9442662";
            return HelloThere;
        }

        public static string HelpDesk()
        {
            //index: 6m
            string helpDesk = "https://tenor.com/view/scum-wretched-villany-tattooine-gif-10985312";
            return helpDesk;
        }

        public static string HelpDeskMainLine()
        {
            //index: 3v
            var mainLine = "Help Desk Main Line: (517) 978-3025";
            return mainLine;
        }

        public static string HelpDeskMatingRitual()
        {
            //index: 47
            var matingRitual = "https://www.reddit.com/r/StrangeAndFunny/comments/ntkg35/this_is_how_i_attract_mates/?utm_medium=android_app&utm_source=share";
            return matingRitual;
        }

        public static string HelpMe()
        {
            //index: 3c
            var helpMe = "https://tenor.com/view/new-girl-help-help-me-yelling-shouting-gif-3568504";
            return helpMe;
        }

        public static string HmmNo()
        {
            //index: c
            var hmmNo = "https://cdn.discordapp.com/attachments/895367300390211634/925134529553911828/IckyBossyHarvestmen-size_restricted.gif";
            return hmmNo;
        }

        public static string HowDareYou()
        {
            //index: d
            var howDareYou = "https://tenor.com/view/how-dare-you-greta-thunberg-gif-15130785";
            return howDareYou;
        }

        public static string InappropriateGif()
        {
            //Gif in question: "https://tenor.com/view/balls-sucking-cherry-lick-his-nuts-gif-15332077"
            var stopIt = "https://tenor.com/view/stop-it-get-some-help-gif-15058124";
            return stopIt;
        }

        public static string ICanDoThisAllDay()
        {
            //5e
            string msg = "https://tenor.com/view/captain-america-i-can-do-this-all-day-avengers-endgame-marvel-gif-15551087";
            return msg;
        }

        public static string IHaveSpoken()
        {
            //index: 6k
            string iHaveSpoken = "https://tenor.com/view/kuiil-have-spoken-mandalorian-star-wars-gif-15566834";
            return iHaveSpoken;
        }

        //have you checked your butthole
        public static string IKnowWhereItIs()
        {
            var butthole = "https://youtu.be/6IjuSycXjqM";
            return butthole;
        }

        public static string IQuit()
        {
            var quit = "https://tenor.com/view/get-out-of-here-throw-trash-garbage-gif-16402986";
            return quit;
        }

        //2 respoonses
        public static string IUnderstandThatReference()
        {
            String[] msg =
            {
                //Captain America gif, index: #5a
                "https://tenor.com/view/captain-america-i-understood-that-reference-look-back-gif-14556485",
                //Captain America jpeg, index: 5b
                "https://media.discordapp.net/attachments/895367300390211634/949012494561718282/IMG_4229.jpg",
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var CaptainAmerica = ($"{msg[value]}");

            return CaptainAmerica;
        }

        //2 responses
        public static string IUnderstoodThatReference()
        {
            String[] msg =
            {
                //Captain America gif, index: #4u
                "https://tenor.com/view/captain-america-i-understood-that-reference-look-back-gif-14556485",
                //Captain America jpeg, index: #5c
                "https://media.discordapp.net/attachments/895367300390211634/949012494561718282/IMG_4229.jpg",
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var CaptainAmerica = ($"{msg[value]}");

            return CaptainAmerica;
        }

        public static string IllAllowIt()
        {
            //index: 7
            var SenorChang = "https://cdn.discordapp.com/attachments/895367300390211634/925133422911975445/giphy-1.gif";
            return SenorChang;
        }

        public static string ImDissapointed()
        {
            //index: 5m
            var disappointed = "https://tenor.com/view/disappointment-disappointed-food-review-meme-gif-16003613";
            return disappointed;
        }

        public static string ImTotallyWorking()
        {
            //index: 3b
            var working = "https://www.youtube.com/watch?v=lNxjZ9XLzV0&ab_channel=JackStauber";
            return working;
        }

        public static string ImWatchingYou()
        {
            //index: 56
            string msg = "https://tenor.com/view/mike-wazowski-watchingyou-gif-5352035";
            return msg;
        }

        public static string ItIsDecided()
        {
            //index: 6
            var decided = "https://cdn.discordapp.com/attachments/895367300390211634/925133251109064714/IMG_3198.gif";
            return decided;
        }

        public static string ItsFriday()
        {
            //index: 46
            var friday = "https://www.youtube.com/watch?v=kfVsfOSbJY0";
            return friday;
        }

        public static string ItsMonday()
        {
            //index: 4f
            var monday = "https://cdn.discordapp.com/attachments/902629594564296725/938487641895223406/RDT_20220131_2331024689813064455587372.jpg";
            return monday;
        }

        public static string ItsTimeToPressButtons()
        {
            //index: 34
            var buttons = "https://www.youtube.com/watch?v=OYHwCuGn_x0";
            return buttons;
        }

        public static string Jake()
        {
            //index: 7i
            string jake = "https://cdn.discordapp.com/attachments/989223734781018112/997213547547332690/jake1.jpg";
            return jake;
        }

        public static string JKS()
        {
            //index: 5q
            string msg = "https://cdn.discordapp.com/attachments/895367300390211634/955910177608073276/viddit_b996e3f8.gif";
            return msg;
        }

        public static string Joe()
        {
            //index: 3y
            var joe = "https://tenor.com/view/hacker-typing-hacking-computer-codes-gif-17417874";
            return joe;
        }

        public static string JustinK()
        {
            //index: 78
            string justinK = "https://cdn.discordapp.com/attachments/894991535542788137/981981904603582504/unknown.png";
            return justinK;
        }

        //same as vsa
        public static string Kaseya()
        {
            string kaseya = "https://cdn.discordapp.com/attachments/989223734781018112/1031964250702368838/kaseya.jpg";
            return kaseya;
        }

        //same as kikko
        public static string Kikki()
        {
            //index: q
            var kikki = "https://tenor.com/view/kikis-delivery-service-ghibli-kiki-kiki-the-witch-anime-gif-16933631";
            return kikki;
        }

        //same as kikki
        public static string Kikko()
        {
            //index: s
            var kikko = "https://tenor.com/view/kikis-delivery-service-ghibli-kiki-kiki-the-witch-anime-gif-16933631";
            return kikko;
        }

        public static string KnowYourPlace()
        {
            //index: 35
            var trash = "https://tenor.com/view/trash-know-your-place-gif-12886026";
            return trash;
        }

        public static string Larson()
        {
            //index: 3h
            var larson = "https://tenor.com/view/no-randy-jackson-dawg-gif-12730917";
            return larson;
        }

        public static string Loveall()
        {
            //index: 6c
            string loveall = "https://tenor.com/view/campesino-farmer-looking-sneaking-gif-14335387";
            return loveall;
        }

        //The DICK
        public static string Martin()
        {
            //index: 4b
            var martin = "You mean the Director of Inclusion, Care, and Kindness? You can call him DICK for short";
            return martin;
        }

        //Fresh Prince gif
        public static string Marty()
        {
            //index: x
            var marty = "https://media.giphy.com/media/UrK4buqejkhK2NTFw9/giphy.gif";
            return marty;
        }

        public static string MildShock()
        {
            //index: 6e
            string mildShock = "https://tenor.com/view/patrick-stewart-mild-shock-shocked-shock-mild-gif-5292523";
            return mildShock;
        }

        //on site
        public static string OnSite1()
        {
            //index: 7k
            string onsite = "https://tenor.com/view/nailed-it-three-pointer-basketball-whoosh-3pointer-gif-16331098";
            return onsite;
        }

        //onsite
        public static string OnSite2()
        {
            //index: 7j
            string onsite = "https://tenor.com/view/nailed-it-three-pointer-basketball-whoosh-3pointer-gif-16331098";
            return onsite;
        }

        public static string Oops()
        {
            //index: 3r
            var oops = "https://tenor.com/view/made-a-huge-tiny-mistake-im-listening-huge-mistake-gif-14364427";
            return oops;
        }

        public static string Oopsie()
        {
            //index: 45
            var oopsie = "https://tenor.com/view/dumb-stupid-stfu-peretti-b99-gif-5120485";
            return oopsie;
        }

        public static string Pebcac()
        {
            //index: 52
            var pebcac = "problem exists between computer and chair";
            return pebcac;
        }

        public static string Rob()
        {
            //index: 4j
            var rob = "https://tenor.com/view/sad-gif-24073087";
            return rob;
        }

        public static string SelfBurn()
        {
            //index: 4q
            string selfBurn = "https://tenor.com/view/self-burn-brooklyn-nine-rare-andy-samberg-detective-jake-peralta-gif-5606998";
            return selfBurn;
        }

        public static string Shamne()
        {
            //index: 3n
            var shame = "https://tenor.com/view/shame-game-of-thrones-gif-11381550";
            return shame;
        }

        public static string Shhh()
        {
            //index: 5p
            string msg = "https://cdn.discordapp.com/attachments/895367300390211634/955910175951294604/x4cHkTBUQHob3cZRWE_1.gif";
            return msg;
        }

        public static string SignalFlags()
        {
            //index: 3d
            var flags = "https://en.wikipedia.org/wiki/International_maritime_signal_flags";
            return flags;
        }

        public static string SlapChris()
        {
            //index: 62
            string slapChris = "https://slapchris.com/";
            return slapChris;
        }

        public static string STFU()
        {
            //index: 3q
            var stfu = "https://www.youtube.com/watch?v=OLpeX4RRo28";
            return stfu;
        }

        public static string SuckIt()
        {
            //index: 4p
            var Ruxin = "https://tenor.com/view/ruxin-the-league-suck-it-commissioner-gif-5003995";
            return Ruxin;
        }

        public static string ThatsFuckingIt()
        {
            //index: 6h
            string thatsFuckingIt = "https://cdn.discordapp.com/attachments/902629594564296725/948207664125599814/61160522_2454260577925971_913587187931414528_n.jpg";
            return thatsFuckingIt;
        }

        //same as Zuko
        public static string ThatsRoughBuddy()
        {
            var Zuko = "https://tenor.com/view/thats-rough-buddy-avatar-the-last-airbender-zuko-gif-17596756";
            return Zuko;
        }

        public static string ThatsWhatSheSaid()
        {
            //index: 6y
            string sheSaid = "https://tenor.com/view/steve-carell-the-office-thats-what-she-said-gif-8356135";
            return sheSaid;
        }

        public static string TheDiscordPurge()
        {
            //index: 4z
            string msg = "https://tenor.com/view/purge-design-weapons-destruction-gif-5999223";
            return msg;
        }

        public static string TheWorst()
        {
            //index: 5n
            string msg = "https://tenor.com/view/the-worst-gif-13248078";
            return msg;
        }

        public static string ThisIsTheWay()
        {
            //index: 73
            string theMandalorian = "https://tenor.com/view/mando-way-this-is-the-way-mandalorian-star-wars-gif-18467370";
            return theMandalorian;
        }

        public static string TimeToWork()
        {
            //index: 6z
            string timeToWork = "https://tenor.com/view/working-work-gif-20073706";
            return timeToWork;
        }

        public static string Ugh()
        {
            //index: 6j
            string ugh = "https://tenor.com/view/ugh-no-why-me-annoyed-gif-12005705";
            return ugh;
        }

        public static string Unacceptable()
        {
            //index: 3p
            var unacceptable = "https://tenor.com/view/unacceptable-adventure-time-lemongrab-freakout-armflail-gif-5515437";
            return unacceptable;
        }

        //same as kaseya
        public static string VSA()
        {
            string vsa = "https://cdn.discordapp.com/attachments/989223734781018112/1031964250702368838/kaseya.jpg";
            return vsa;
        }

        public static string Wait()
        {
            //index: 8
            var wait = "https://cdn.discordapp.com/attachments/895367300390211634/925133556848660550/41020a6.gif";
            return wait;
        }

        public static string WhoGivesAFuck()
        {
            //index: 63
            string chrisPratt = "https://media.discordapp.net/attachments/895367300390211634/958932253596069949/chris-pratt-who-gives-a-fuck.gif";
            return chrisPratt;
        }

        public static string WhoTheHellCares()
        {
            //index: 64
            string whoCares = "https://cdn.discordapp.com/attachments/895367300390211634/959133120970489908/viddit_37b34f8b.gif";
            return whoCares;
        }

        //4 responses
        public static string WTF()
        {
            String[] msg =
            {
                //Colbert, index: #a
                "https://tenor.com/view/who-the-fuck-stephen-colbert-wtf-who-gif-16091360",
                //Spiderman, index: #4e
                "https://cdn.discordapp.com/attachments/989223734781018112/1009941343243599972/wtf_spiderman_4e.jpg",
                //Obama, index: #5w
                "https://tenor.com/view/whatever-shrug-idk-i-dont-know-obama-gif-15684252",
                //yellow shirt guy who mouths "what the fuck"; index: 6f
                "https://tenor.com/view/wtf-is-that-confused-gif-14675917"
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var wtf = ($"{msg[value]}");

            return wtf;
        }

        public static string YouHaveNoPowerHere()
        {
            //index: 6r
            string theoden = "https://media.discordapp.net/attachments/720505313085620286/972737120777171014/L0coY9I1D2BnaKln9a.gif";
            return theoden;
        }

        public static string YoureaABitch()
        {
            //index: 4d
            var bitch = "https://cdn.discordapp.com/attachments/902629594564296725/936617850880286780/A_Special_Song_Just_For_You.webm";
            return bitch;
        }

        //same as "that's rough, buddy"
        public static string Zuko()
        {
            //index: 4i
            var Zuko = "https://tenor.com/view/thats-rough-buddy-avatar-the-last-airbender-zuko-gif-17596756";
            return Zuko;
        }
    }
}
