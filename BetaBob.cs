//System
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//Discord
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

//Usings not used
using System.Collections;
using System.Globalization;
using System.Net.Http;
using System.Net;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Timers;
using System.Xml;
using Discord.Net;


namespace Bob_Biggby
{
    class BetaBob
    {
        static void Main(string[] args) => new BetaBob().RunBotAsync().GetAwaiter().GetResult();


        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        List<PeopleList.Person> people = new List<PeopleList.Person>();

        List<PeopleList.Proactive> proactive = new List<PeopleList.Proactive>();

        List<PeopleList.AlphaBob> vanillaBobLCR = new List<PeopleList.AlphaBob>();

        string basePath;
        string peopleDataPath;
        string proactiveDataPath;
        string vanillaBobDataPath;

        public async Task RunBotAsync()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();

            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton(_commands)
                .BuildServiceProvider();

            //Directory where Bob will retrive files
            basePath = Directory.GetParent(Environment.CurrentDirectory).FullName;

            Start();
            StartProactive();
            StartVanillaBob();

            //This makes Bob use token.txt to get the bot token instead of putting the token directly into the code
            var tokenPath = Path.Combine(basePath, "token.txt");
            string token = File.ReadAllText(tokenPath);

            _client.Log += _client_Log;

            await RegisterCommandAsync();

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

            await Task.Delay(-1);

        }

        //Start for People
        void Start()
        {
            peopleDataPath = Path.Combine(basePath, "people.json");

            people.Sort();

            if (File.Exists(peopleDataPath))
                LoadPeople();
            else
                CreatePeople();
        }

        //Start for Proactive
        void StartProactive()
        {
            proactiveDataPath = Path.Combine(basePath, "proactive.json");

            proactive.Sort();

            if (File.Exists(proactiveDataPath))
                LoadProactive();
            else
                CreateProactive();
        }

        //Start for Beta Bob
        void StartVanillaBob()
        {
            vanillaBobDataPath = Path.Combine(basePath, "vanillabob.json");

            if (File.Exists(vanillaBobDataPath))
                LoadVanillaBob();
            else
                CreateVanillaBob();
        }

        //Creates a list of people and their different nicknames
        void CreatePeople()
        {
            people.Add(new PeopleList.Person("Becky"));
            people.Add(new PeopleList.Person("Brittney"));
            people.Add(new PeopleList.Person("Daniel", "Custiodian", "The Custodian", "Pancake"));
            people.Add(new PeopleList.Person("Dan"));
            people.Add(new PeopleList.Person("Dennis"));
            people.Add(new PeopleList.Person("Deon"));
            people.Add(new PeopleList.Person("Jake"));
            people.Add(new PeopleList.Person("Joe"));
            people.Add(new PeopleList.Person("Justin", "Larson"));
            people.Add(new PeopleList.Person("Martin", "Marty"));
            people.Add(new PeopleList.Person("Rob"));
            people.Add(new PeopleList.Person("Timm"));
            people.Add(new PeopleList.Person("Kikendall", "Kikko", "Kikki"));
            people.Add(new PeopleList.Person("Will"));
            people.Add(new PeopleList.Person("Willie", "Willie P"));
            people.Add(new PeopleList.Person("Bob"));
            people.Add(new PeopleList.Person("NOC"));
            people.Sort();
            SavePeople();
        }

        //Proactive list
        void CreateProactive()
        {
            proactive.Add(new PeopleList.Proactive("Brittney"));
            proactive.Add(new PeopleList.Proactive("Daniel"));
            proactive.Add(new PeopleList.Proactive("Dennis"));
            proactive.Add(new PeopleList.Proactive("Jake"));
            proactive.Add(new PeopleList.Proactive("Joe"));
            proactive.Add(new PeopleList.Proactive("Justin", "Larson"));
            proactive.Add(new PeopleList.Proactive("Bob"));
            proactive.Add(new PeopleList.Proactive("NOC"));
            proactive.Sort();
            SaveProactive();
        }

        //VanillaBob list
        void CreateVanillaBob()
        {
            vanillaBobLCR.Add(new PeopleList.AlphaBob("bf"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("bitch"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("bones day"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("boss man"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("comms"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("custodian"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("dan w"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("daniel"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("dew it"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("do it"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("eat a chode"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("eat a dick"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("email the user"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("escalate"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("ew"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("extended it alignments"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("fresh prince"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("fuck"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("fuck you"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("general kenobi"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("haha good one"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("hello there"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("help desk main line"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("help me"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("hmm no"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("how dare you"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("inappropriate gif", $"https://tenor.com/view/balls-sucking-cherry-lick-his-nuts-gif-15332077"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("I own you"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("I'll allow it"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("I'm busy"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("I'm disappointed"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("I'm fine"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("I'm totally working"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("it is decided"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("it is done"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("it's friday"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("it's friday losers"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("it's time to press buttons"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("joe"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("kikki", "kikko"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("know your place"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("larson"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("martin"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("marty"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("oops"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("oopsie"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("praise the sun"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("shame"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("signal flags"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("stfu"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("thank you bob"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("tlj"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("unacceptable"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("wait..."));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("will"));
            vanillaBobLCR.Add(new PeopleList.AlphaBob("wtf"));
            SaveVanillaBob();
        }


        //Saves the list of people to a JSON file titled "people", and same for "proactive"
        void SavePeople()
        {
            File.WriteAllText(peopleDataPath, JsonConvert.SerializeObject(people, Newtonsoft.Json.Formatting.Indented));
        }

        //Saves Poractive peeps
        void SaveProactive()
        {
            File.WriteAllText(proactiveDataPath, JsonConvert.SerializeObject(proactive, Newtonsoft.Json.Formatting.Indented));
        }

        //Saves Vanilla Bob
        void SaveVanillaBob()
        {
            File.WriteAllText(vanillaBobDataPath, JsonConvert.SerializeObject(vanillaBobLCR, Newtonsoft.Json.Formatting.Indented));
        }

        //Loads the "people" and "proactive" JSON files
        void LoadPeople()
        {
            people = JsonConvert.DeserializeObject<List<PeopleList.Person>>(File.ReadAllText(peopleDataPath));
        }

        void LoadProactive()
        {
            proactive = JsonConvert.DeserializeObject<List<PeopleList.Proactive>>(File.ReadAllText(proactiveDataPath));
        }

        void LoadVanillaBob()
        {
            vanillaBobLCR = JsonConvert.DeserializeObject<List<PeopleList.AlphaBob>>(File.ReadAllText(vanillaBobDataPath));
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandAsync()
        {
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        //React with emote
        public async Task ReactWithEmoteAsync(SocketUserMessage userMsg, string escapedEmote)
        {
            if (Emote.TryParse(escapedEmote, out var emote))
            {
                await userMsg.AddReactionAsync(emote);
            }
        }

        #region Readonly Strings

        //When "curse" is the input, Bob will take a word from curse, item, and adjet, string them together, and output them in chat
        //String for curses Bob will use in the curse
        readonly String[] insult =
        {
            "ass", "asshole",
            "ballsack",
            "cunt",
            "dick",
            "fuck",
            "gootch",
            "labia",
            "piss",
            "shit", "smegma",
            "tits", "twat",
            "vagina",
        };

        //String for items Bob will use in the curse
        readonly String[] item =
        {
            "alarm clock", "armoire",
            "backpack", "bedding", "bedspread", "binders", "blankets", "blinds", "bookcase", "books", "broom", "brush", "bucket",
            "calendar", "candles", "carpet", "chair", "chairs", "china", "clock", "coffee table", "comb", "comforter", "computer", "containers", "couch", "credenza", "cup", "curtains", "cushions",
            "desk", "dish towel", "dishwasher", "door stop", "drapes", "dressers", "drill", "dryer", "dust pan", "duvet", "dnd tables",
            "extension cord",
            "fan", "figurine", "file cabinet", "fire extinguisher", "flashlight", "flatware", "flowers", "forks", "furnace",
            "games", "glasses",
            "hammer", "heater", "houseplant",
            "iPhone", "iPod", "iron", "ironing board",
            "jewelry",
            "knives",
            "lamp", "light bulbs", "light switch", "linens",
            "magnets", "markers", "medicine", "mementos", "microwave", "mop", "mugs", "musical instruments",
            "napkins", "nick-knacks", "note paper",
            "oven",
            "paintings", "pans", "pants", "paper", "pen", "pencil", "phones", "photographs", "piano", "pictures", "pillows", "pitcher", "plants", "plastic plates", "plates", "pliers", "pots", "prescriptions",
            "radiator", "radio", "rags", "refrigerator", "rugs",
            "saucer", "saw", "scissors", "screw driver", "settee", "shades", "sheets", "shelf", "shirts", "shoes", "smoke detector", "sneakers", "socks", "sofa", "speakers", "spoons", "suitcases", "supplies", "sweeper",
            "tablecloth", "tables", "telephone", "timers", "tissues", "toaster", "toilet paper", "toothbrush", "toothpaste", "towels", "toys", "TV",
            "vacuum", "vase",
            "washer", "washing machine"
        };

        //String for curse adjectives
        readonly String[] adjit =
        {
            "bitchy", "blue",
            "cocky", "cum",
            "dirty", "druggy",
            "fake", "fuck",
            "green", "grimy",
            "intoxicated",
            "lame", "lying",
            "pretentious", "purple",
            "red",
            "rude",
            "smelly", "slutly", "strangley bent left", "strangely bent right",
            "ugly",
        };

        //Responses to "good morning"
        readonly String[] goodMorning =
        {
            "There's no such thing as a 'good' morning", "unintelligble grunting", "no, thank you",
            "What do you mean? Do you wish me a good morning, or mean that it is a good morning whether I want it or not; or that you feel good this morning; or that it is a morning",
            "https://tenor.com/view/community-troy-and-abed-morning-gif-15331382", "I'd rather be taking a nap",
            "https://tenor.com/view/good-morning-funny-animals-insomnia-cat-tired-crazy-cute-gif-13960492",
        };

        //Responses for "morning"
        readonly String[] morning =
        {
            //exhausted
            "https://tenor.com/view/tired-af-crying-sad-kid-baby-gif-16784052",
            //kid on swing
            "https://tenor.com/view/done-im-so-over-it-gif-21279037", 
            //turtle face
            "https://tenor.com/view/nickmiller-turtleface-newgirl-gif-7391387",
            //grumpy kid
            "https://tenor.com/view/bravo-brabo-chato-grumpy-gif-14645707",
            //no "good" in my mornings
            "https://tenor.com/view/good-morning-funny-animals-insomnia-cat-tired-crazy-cute-gif-13960492",
        };

        //String for people
        readonly String[] peopleNameList = 
        {
            "Becky",
            "Brittney",
            "Daniel", "The Custodian",
            "Dan B",
            "Dan W",
            "Dennis",
            "Jake",
            "Joe",
            "Justin", "Larson",
            "Kikkendall", "Kikko", "Kikki",
            "Martin", "Marty",
            "Rob",
            "Timm",
            "Will",
            "Bob",
            "NOC",
            "Willie P"
        };
        readonly String[] proactiveNameList = 
        {
            "Brittney",
            "Daniel (The Custodian)",
            "Dennis",
            "Jake",
            "Joe",
            "Justin/Larson",
            "Bob",
            "NOC"
        };

        //Strig for sass
        readonly String[] bobSass =
        {
            "can you not?",
            "how about no",
            "I ain't doin' shit", "I'd rather deal with Willie P than deal with you", "I'd rather watch paint dry than listen to you any longer",
            "leave me alone, I'm busy",
            "make me",
            "nah fam", "no thanks", "no u", "nobody asked you", "not until you ask nicely",
            "shouldn't you be working?",
            "up yours",
            "you can't tell me what to do",
        };

        //string for Irish curse
        readonly String[] curse =
        {
            "I hope the Devil uses your backbone as a ladder to pick apples in the garden of Hell",
            "May your friends have a fine day - buring you",
            "May the bad weather leave with you",
            "My cat's curse upon you!",
            "May you leave without returning",
            "May you be badly positioned on a windy day",
            "Stife and stress upon you!",
            "I hope the Devil makes splinters of your legs",
            "May you be burned and severely injured",
            "It serves you right!",
            "I hope you die without a priest"
        };

        //String for Shakspearean insults
        readonly String[] shakespeare1 = { "goatish", "mangled", "puny", "roguish", "reeky", "saucy", "weedy", "yeasty", "vallainous", "gleeking" };
        readonly String[] shakespeare2 = { "beef-witted", "clay-brained", "thin-skinned", "hedge-faced", "milk-livered", "fly-loving", "rump-fed", "toast-spotted", "weather-bitten", "fool-born" };
        readonly String[] shakespeare3 = { "barnacle", "boar-pig", "bum-bailey", "clot-pole", "foot-licker", "horn-beast", "maggot-pie", "malt-worm", "pumpkin", "whey-spiller" };

        //Vanilla Bob Commands
        readonly String[] AlphaBobCommands =
        {
            // bitch x2
            "bitch", "bones day", "boss man",
            "check the handbook", "comms", "custodian",
            //dan w x2
            //dew it x2
            //do it x5
            "dan w", "daniel", "dew it", "do it",
            "eat a chode", "eat a dick", "email the user", "escalate", "ew", "extended it alignments",
            "firefly", "fresh prince", "fuck", "fuck you",
            "general kenobi",
            "haha good one", "hello there", "help desk main line", "help me", "hmm no", "how dare you", "'https://tenor.com/view/balls-sucking-cherry-lick-his-nuts-gif-15332077'",
            //it is done x2
            "I own you", "I'll allow it", "I'm busy", "I'm disappointed", "I'm fine", "I'm totally working", "it is decided", "it is done", "it is done", "it's friday", "it's friday losers", "it's monday", "it's time to press buttons",
            "joe",
            "kikki", "kikko", "know your place",
            "larson",
            "martin", "marty",
            "oops", "oopsie",
            "praise the sun",
            "rob",
            "shame", "signal flags", "stfu",
            "thank you bob", "that's rough, buddy", "tlj",
            "unacceptable",
            //will x2
            //wtf x2
            "wait...", "will", "wtf",
            "you're a bitch",
            "zuko",
        };

        readonly String[] AlphaBobToAdd =
        {
            "ess",
            "help desk mating ritual",
            "I know where it is", "I quit", "I understood that reference",
            "noc",
            "pebcac",
            "suck it",
        };

        readonly String[] namesWithoutReactions =
        {
            "becky",
            "brittney",
            "dan b",
            "dennis",
            "deon",
            "jake",
            "timm",
        };

        //Shit talk for marty
        readonly String[] martyPraise =
        {
            "you are an exquisite specimen and Will's mother wishes she had you instead of him",
            "you are valued and cherished and Timm loves you long time",
        };

        readonly String[] martyInsult =
        {
            "go fuck yourself",
            "stuff your nose in a hobo's ass crack",
        };

        #endregion Readonly Strings

        //Schedule timer thingy

        private async Task HandleCommandAsync(SocketMessage arg) 
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;
            int argPos = 0;

            //converts the input to a string, since it comes in as "socketusermessage"
            string stringmessage = message.ToString();
            //converts string to lowercase so that the message is the same for the sake of the bot
            string lowmess = stringmessage.ToLower();

            var time1 = DateTime.Now;

            #region Shortcuts

            //Channels
            //Announcements
            bool Announcements = GlobalShortcuts.DiscordIDs.IsAnnouncements(message.Channel);
            bool ProactiveAnnouncements = GlobalShortcuts.DiscordIDs.IsProactiveAnnouncements(message.Channel);

            //Work Chats, V2
            bool ProactiveChat = GlobalShortcuts.DiscordIDs.IsProactiveChat(message.Channel);
            bool HelpDeskChat = GlobalShortcuts.DiscordIDs.IsHelpDesk(message.Channel);
            
            //Fun Zone, V2
            bool ChillChat = GlobalShortcuts.DiscordIDs.IsChillChat(message.Channel);
            bool MemesChat = GlobalShortcuts.DiscordIDs.IsMemes(message.Channel);

            //Bot Testing
            bool Testing = GlobalShortcuts.DiscordIDs.IsPlayground(message.Channel);
            bool ibsTesting = GlobalShortcuts.DiscordIDs.IsIBSTesting(message.Channel);
            bool pumphouseTesting = GlobalShortcuts.DiscordIDs.IsPumphouseTesting(message.Channel);

            //User IDs
            bool Mod = GlobalShortcuts.DiscordIDs.IsMod(message.Author);
            bool Custodian = GlobalShortcuts.DiscordIDs.IsCustodian(message.Author);
            bool Proactive = GlobalShortcuts.DiscordIDs.IsProactive(message.Author);
            bool Degen = GlobalShortcuts.DiscordIDs.IsDegen(message.Author);
            bool Pleb = GlobalShortcuts.DiscordIDs.IsNotMod(message.Author);
            bool Will = GlobalShortcuts.DiscordIDs.WillTheJew(message.Author);
            bool AllButWill = GlobalShortcuts.DiscordIDs.AllButWill(message.Author);

            //Roles
            var ServerCustodianRole = GlobalStrings.RoleStrings.CustodianRole();
            var PumphouseAdminRole = GlobalStrings.RoleStrings.PumphouseAdmin();
            var TeamLeaderRole = GlobalStrings.RoleStrings.TeamLeader();
            var Tier2Role = GlobalStrings.RoleStrings.Tier2();
            var BetaBobRole = GlobalStrings.RoleStrings.BetaBob();
            var ProactiveRole = GlobalStrings.RoleStrings.Proactive();
            var DegenRole = GlobalStrings.RoleStrings.Degen();
            var GrangerRole = GlobalStrings.RoleStrings.Granger();
            var RaidLeaderRole = GlobalStrings.RoleStrings.RaidLeader();
            var NOCRole = GlobalStrings.RoleStrings.RobsBestFriend();

            //IDs to string
            string channelID = Convert.ToString(message.Channel.Id);
            bool channel = Convert.ToBoolean(message.Channel.Id);
            var proactivePeeps = Convert.ToSByte(Proactive);

            //Time
            var Today = DateTime.Now;
            var currentTime = DateTime.Now.ToString("T");

            var workStart = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 00, 00);
            var workEnd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 00, 00);

            var martinPraise = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 00, 00);
            var martinInsult = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 00, 00);
            var testTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 29, 00);

            /* Emotes
             * If you wanna send an emote as a message or reaction, Bob has to be apart of that server
             * To send an emote as a message, use $"{emote}" 
             */

            //IBS
            var BravoFlag = Emote.Parse(GlobalStrings.IBSEmoteStrings.BravoFlag());
            var Hank = Emote.Parse(GlobalStrings.IBSEmoteStrings.Hank());
            var ZuluFlag = Emote.Parse(GlobalStrings.IBSEmoteStrings.ZuluFlag());
            var yes = Emote.Parse(GlobalStrings.IBSEmoteStrings.Yes());
            var Tux = Emote.Parse(GlobalStrings.IBSEmoteStrings.Tux());
            var tom = Emote.Parse(GlobalStrings.IBSEmoteStrings.Tom());
            var partyglasses = Emote.Parse(GlobalStrings.IBSEmoteStrings.PartyGlasses());
            var omegaroll = Emote.Parse(GlobalStrings.IBSEmoteStrings.OmegaRoll());
            var no = Emote.Parse(GlobalStrings.IBSEmoteStrings.No());
            var monster = Emote.Parse(GlobalStrings.IBSEmoteStrings.Monster());
            var martin_heart = Emote.Parse(GlobalStrings.IBSEmoteStrings.MartinHeart());
            var martin = Emote.Parse(GlobalStrings.IBSEmoteStrings.Martin());
            var goth_heart = Emote.Parse(GlobalStrings.IBSEmoteStrings.GothHeart());
            var larsoneyes = Emote.Parse(GlobalStrings.IBSEmoteStrings.LarsonEyes());
            var fake = Emote.Parse(GlobalStrings.IBSEmoteStrings.Fake());
            var facts = Emote.Parse(GlobalStrings.IBSEmoteStrings.Facts());
            var facepalm = Emote.Parse(GlobalStrings.IBSEmoteStrings.Facepalm());

            //My Servers
            var Solaire = Emote.Parse(GlobalStrings.PumphouseEmoteStrings.Solaire());
            var shadowHaunter = Emote.Parse(GlobalStrings.PumphouseEmoteStrings.ShadowHaunter());
            var SakamotoDab = Emote.Parse(GlobalStrings.PumphouseEmoteStrings.SakamotoDab());
            var evilZorra = Emote.Parse(GlobalStrings.PumphouseEmoteStrings.EvilZorra());
            var doubt = Emote.Parse(GlobalStrings.PumphouseEmoteStrings.Doubt());

            //GFD Emotes. Not available
            var finger_guns = Emote.Parse(GlobalStrings.FutureEmoteStrings.FingerGuns());

            //Random shit
            string username = message.Author.Username;
            var userID = message.Author.Id;
            var userMention = $"<@{userID}>";

            //Sass
            Random brat = new Random();
            int sass = brat.Next(0, 50);
            var sassVal = brat.Next(0, bobSass.Length);
            //End shortcuts
            #endregion Shortcuts

            /// <summary>
            /// lowmess tips
            /// lowmess.Contains means "if lowercase message contains [input] anywhere in message"
            /// lowmess.Equals is for when you want Bob to do [thing} only if lowmess is *exactly* [input] and nothing more or less
            /// lowmess.StartsWith and lowmess.EndsWith are exactly what you think
            /// </summary>

            //Command prefix for Bob. Bob's version of '.' for Nadeko
            if (message.HasStringPrefix("+", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }

            //Stuff to demonstrate my power
            else if (lowmess.Equals("i am the senate") || lowmess.Equals("i am the custodian") || lowmess.Equals("i am the discord") ||
                lowmess.Equals("i *am* the senate") || lowmess.Equals("i *am* the custodian") || lowmess.Equals("i *am* the discord"))
            {
                var Sheev = "It depends who's talking";

                if (Custodian)
                {
                    Sheev = "https://tenor.com/view/star-wars-i-am-the-senate-gif-10270130";
                }

                else
                {
                    Sheev = $"It's treason then \nhttps://tenor.com/view/darth-sidious-star-wars-spin-lightsaber-rolling-gif-17322873";
                }

                await message.Channel.SendMessageAsync($"{Sheev}");
            }

            //Insult
            else if (lowmess.Contains("insult"))
            {
                Random random = new Random();

                int value = random.Next(0, insult.Length);
                int value1 = random.Next(0, item.Length);
                int value2 = random.Next(0, adjit.Length);
                var text = $"{adjit[value2]} {insult[value]} {item[value1]}";

                if (lowmess.Contains("shakespearean insult"))
                {
                    int swear1 = random.Next(0, shakespeare1.Length);
                    int swear2 = random.Next(0, shakespeare2.Length);
                    int swear3 = random.Next(0, shakespeare3.Length);
                    text = $"{shakespeare1[swear1]} {shakespeare2[swear2]} {shakespeare3[swear3]}";
                }
                await message.Channel.SendMessageAsync(text);
            }

            //Morning
            else if (lowmess.Contains("morning") || lowmess.Contains("mornin"))
            {
                Random random = new Random();
                int value = random.Next(0, morning.Length);
                int value2 = random.Next(0, goodMorning.Length);
                string msg;

                if (lowmess.Equals("morning") || lowmess.Equals("also morning") || lowmess.Equals("mornin"))
                {
                    msg = $"{morning[value]}";
                    await message.Channel.SendMessageAsync(msg);
                }

                else if (lowmess.Equals("good morning") || lowmess.Equals("also good morning"))
                {
                    msg = $"{goodMorning[value2]}";
                    await message.Channel.SendMessageAsync(msg);
                }

                else
                {
                    Console.WriteLine("");
                }
            }

            //You're wrong
            else if (lowmess.Contains("you're wrong"))
            {
                await message.Channel.SendMessageAsync("https://www.youtube.com/watch?v=GM-e46xdcUo&ab_channel=wintermoot");
            }

            //Your Opinion
            else if (lowmess.Contains("that's your opinion"))
            {
                await message.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/894991535542788137/900786985747243038/download_1.png");
            }

            //Jeffery
            else if (lowmess.Contains("get me a jeffery"))
            {
                await message.Channel.SendMessageAsync("https://youtu.be/sEtBDQDkEXc");
            }

            //Shame Corner
            else if (lowmess.Contains("shame corner"))
            {
                var shame = "https://tenor.com/view/taylor-bartley-sad-corner-hungover-dunce-gif-14751671";
                await message.Channel.SendMessageAsync($"{shame}");
            }

            //Going Dark
            else if (lowmess.Equals("going dark") || lowmess.Equals("bob is going offline"))
            {
                await message.Channel.SendMessageAsync("https://tenor.com/view/bravo-six-going-dark-cod-sergeant-mw-modern-warfare-gif-14985183");
            }

            //Willy P and Willie 
            else if (lowmess.Contains("willy p") || lowmess.Contains("willie"))
            {
                await message.Channel.SendMessageAsync("https://tenor.com/view/officer-doofy-salute-goofy-gif-15829687");
            }

            //Bees in my head
            else if (lowmess.Contains("bees in my head"))
            {
                await message.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/895367300390211634/920737168354316378/8fee057.jpg");
            }

            //Deez Nutz, Doze Nutz, and Deez Nuts
            else if (lowmess.Contains("deez nutz") || lowmess.Contains("doze nutz") || lowmess.Contains("deez nuts"))
            {
                await message.Channel.SendMessageAsync("gottem");
            }

            //Rob's Desktop
            else if (lowmess.Equals("rob's desktop") || lowmess.Equals("robs desktop"))
            {
                var desktop = "https://media.discordapp.net/attachments/920025341341351947/943607875325022238/unknown.png";
                await message.Channel.SendMessageAsync(desktop);
            }

            else if (lowmess.Contains("will's spank bank") || lowmess.Contains("wills spank bank") || lowmess.Contains("will's masterbatorium") || lowmess.Contains("wills masterbatorium"))
            {
                string[] spankBank =
                {
                    //Rob's desktop
                    "https://media.discordapp.net/attachments/920025341341351947/943607875325022238/unknown.png", 
                    //Gun Wall
                    "https://cdn.discordapp.com/attachments/920025341341351947/945736559301386300/unknown.png",
                    //Gun wall 2
                    "https://cdn.discordapp.com/attachments/920025341341351947/945739749992329256/modwall-config-front-highres-008-800x630.png",
                };
                
                Random random = new Random();
                var value = random.Next(0, spankBank.Length);
                await message.Channel.SendMessageAsync(spankBank[value]);
            }

            //Irish Curses
            else if (lowmess.Contains("irish curse"))
            {
                Random random = new Random();
                int value = random.Next(0, curse.Length);
                await message.Channel.SendMessageAsync(curse[value]);
            }

            //Quickbooks
            else if (lowmess.Contains("quickbooks"))
            {
                string[] quickbooks = { "https://media.giphy.com/media/QvF8DglKNi3GwG5WIN/giphy-downsized-large.gif", "https://media.giphy.com/media/hTovQQU3dBiE6mmNkJ/giphy.gif" };

                Random random = new Random();
                int value = random.Next(0, quickbooks.Length);

                if (Will)
                {
                    await message.Channel.SendMessageAsync(quickbooks[value]);
                }

                else if (AllButWill && lowmess.Equals("quickbooks"))
                {
                    await message.Channel.SendMessageAsync(quickbooks[value]);
                }
            }

            //Ghost Town
            else if (lowmess.Contains("ghost town"))
            {
                var chernobyl = "https://www.youtube.com/watch?v=XxemwEJDFi0";
                await message.Channel.SendMessageAsync(chernobyl);
            }

            //For when Joe pings the degens in proactive
            else if ((ProactiveChat || ProactiveAnnouncements) && lowmess.Contains(DegenRole))
            {
                var text = $"{DegenRole} doesn't have access to this chat {userMention}";
                await message.Channel.SendMessageAsync($"{text}");
            }

            //Responses from Bob
            else if (lowmess.EndsWith("bob") && !lowmess.Contains("blame") && !lowmess.Contains("fault"))
            {
                string[] commands = AlphaBobToAdd;

                //Bob sass part 1
                if (lowmess.Equals("fuck you bob"))
                {
                    var text = $"well fuck you too {userMention}";
                    await message.Channel.SendMessageAsync(text);
                    await message.Channel.SendMessageAsync($"{shadowHaunter}");
                }

                //Hello Bob
                else if (lowmess.Equals("hello bob"))
                {
                    /* string failsafe = Convert.ToString(message.Author);
                     * var trim = (failsafe.Length - 5);
                     * string username = failsafe.Remove(trim, 5);
                     * var userID = message.Author.Id;
                     */
                    
                    var text = $"hello there {username}";
                    await message.Channel.SendMessageAsync($"{text}");
                }

                //Hey Bob
                else if (lowmess.Equals("hey bob"))
                {
                    //Strings
                    String[] respondOptions = { "polite", "rude", };
                    String[] polite = { "hello there", "yes?", "how can I help you?", };
                    String[] rude = { "the fuck do you want?", $"{shadowHaunter}", };
                    var bobResponse = "hello";

                    //Bob decides how to respond
                    Random random = new Random();
                    int respondChoice = random.Next(0, respondOptions.Length);
                    int politeValue = random.Next(0, polite.Length);
                    int rudeValue = random.Next(0, rude.Length);

                    /* Bob's responses
                     * Polite response
                     */
                    if (respondChoice == 0)
                    {
                        bobResponse = polite[politeValue];
                    }

                    //Rude response
                    else if (respondChoice == 1)
                    {
                        bobResponse = rude[rudeValue];
                    }

                    await message.Channel.SendMessageAsync($"{bobResponse}");
                }

                //Bob's lcr
                else if (lowmess.Equals("lcr bob"))
                {
                    var foundLCR = false;
                    foreach (var reaction in vanillaBobLCR)
                    {
                        foreach (var answer in reaction.lcr)
                        {
                            var msg = "Vanilla Bobs custom reactions:";

                            //LB code
                            for (var i = 0; i < Math.Min(AlphaBobCommands.Length, vanillaBobLCR.Count); i++)
                            {
                                var lcr = new List<String>();
                                vanillaBobLCR = vanillaBobLCR.OrderByDescending(p => p.responses).ToList();
                                //"\n" means a new line. This line will look like e.g. "1) Daniel"
                                msg += $"\n{i + 1}) {vanillaBobLCR[i].lcr[0]}";
                                //var action = $"has {vanillaBobLCR[i].responses} responses";
                            }

                            await message.Channel.SendMessageAsync($"{msg}");
                            foundLCR = true;
                            break;
                        }
                        if (foundLCR)
                            break;
                    }
                    //end bob's lcr
                }
            }


            //Leaderboard
            else if (lowmess.Contains("leaderboard"))
            {
                //Main LBs
                if (lowmess.StartsWith("joe points") || lowmess.StartsWith("blame"))
                {
                    var foundLB = false;
                    foreach (var person in people)
                    {
                        foreach (var name in person.names)
                        {
                            //JP Leaderboard
                            if (lowmess.StartsWith("joe points"))
                            {
                                var msg = "Joe Points Leaderboard:";

                                //show the top 5 people or everyone if there is less than 5
                                for (var i = 0; i < Math.Min(peopleNameList.Length, people.Count); i++)
                                {
                                    var stats = new List<String>();
                                    people = people.OrderByDescending(p => p.joePoints).ToList();
                                    //"\n" means a new line. This line will look like e.g. "1) Daniel"
                                    msg += $"\n{i + 1}) {people[i].names[0]} has {people[i].joePoints} Joe Points";
                                }

                                await message.Channel.SendMessageAsync(msg);
                                foundLB = true;
                                break;
                            }
                            //End JP Leaderboard

                            //Blame Leaderboard
                            else if (lowmess.StartsWith("blame"))
                            {
                                var msg = "Blame Count Leaderboard:";
                                //show the top 5 people or everyone if there is less than 5
                                for (var i = 0; i < Math.Min(peopleNameList.Length, people.Count); i++)
                                {
                                    var stats = new List<String>();
                                    people = people.OrderByDescending(p => p.blameCount).ToList();
                                    //"\n" means a new line. This line will look like e.g. "1) Daniel"
                                    msg += $"\n{i + 1}) {people[i].names[0]} has {people[i].blameCount} Blame Points";
                                }
                                await message.Channel.SendMessageAsync(msg);
                                foundLB = true;
                                break;
                            }
                            //End blame leaderboard

                            //List of leaderboards
                            else
                            {
                                var msg = "Would you like to see the Joe Points Leaderboard (command: `Joe Points leaderboard`) or the Blame Count Leaderboard (command: `Blame Count Leaderboard`). The commands are not case sensitive.";
                                await message.Channel.SendMessageAsync(msg);
                                foundLB = true;
                                break;
                            }
                            //end of leaderboard list
                        } //end of 2nd foreach
                        if (foundLB)
                            break;

                    } //end of 1st foreach
                }
                //End of Main LBs

                //Proactive LB
                else if (lowmess.StartsWith("proactive"))
                {
                    var foundPLB = false;
                    foreach (var ainur in proactive)
                    {
                        foreach (var maia in ainur.maiar)
                        {
                            var msg = "Proactive Points Leaderboard:";
                            //show the top 5 people or everyone if there is less than 5
                            for (var i = 0; i < Math.Min(proactiveNameList.Length, proactive.Count); i++)
                            {
                                var stats = new List<String>();
                                proactive = proactive.OrderByDescending(p => p.proactivePoints).ToList();
                                //"\n" means a new line. This line will look like e.g. "1) Daniel"
                                msg += $"\n{i + 1}) {proactive[i].maiar[0]} has {proactive[i].proactivePoints} Proactive Points";
                            }
                            await message.Channel.SendMessageAsync(msg);
                            foundPLB = true;
                            break;
                        } //End Proactive Leaderboard

                        if (foundPLB)
                            break;
                        //end PLB foreach 2
                    } //end PLB foreach 1

                }
                //End of Proactive LB
            }//End of Leaderboard


            //Practive Points
            else if (lowmess.Contains("proactive point"))
            {
                var foundProactive = false;
                foreach (var ainur in proactive)
                {
                    foreach (var maia in ainur.maiar)
                    {

                        //For manually setting proactive points
                        var ppSetSuccess = Regex.Match(lowmess, @"\b" + Regex.Escape($"set {maia}'s proactive points to".ToLower()) + @"\b").Success;

                        //For viewing Proactive Points
                        var ppCountSuccess = Regex.Match(lowmess, @"\b" + Regex.Escape($"{maia}'s proactive points".ToLower()) + @"\b").Success;

                        //Awarding Proactive Points
                        if (lowmess.IndexOf($"{maia} gets ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"{maia} has been awarded ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"to {maia}", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            int numVal;
                            string MyString = message.Content;
                            Console.WriteLine($"Input string: {MyString}");
                            string proactivePoints = $"gets has been awarded proactive points P {maia}";
                            char[] proactiveTrim = proactivePoints.ToCharArray();
                            string firstTrim = MyString.TrimStart(proactiveTrim);
                            string finalTrim = firstTrim.TrimEnd(proactiveTrim);
                            Console.WriteLine("First trim: {0}", firstTrim);
                            Console.WriteLine("Second trim: {0}", finalTrim);

                            //Start awarding Try
                            try
                            {
                                numVal = Convert.ToInt32(finalTrim);
                                if (numVal < int.MaxValue)
                                {
                                    //adding monthly Proactive Points
                                    try
                                    {
                                        //Tries everything inside its brackets
                                        //checked() checks to see if (person.proactivePoints + numVal) produces an error (usually an under/overflow)
                                        //If there is no error, the equation carrys out as normal
                                        //If there is an error, it goes to "catch"
                                        ainur.proactivePoints = checked(ainur.proactivePoints + numVal);
                                        //calculation worked without overflow
                                    }
                                    catch (OverflowException)
                                    {
                                        //Catch is for anything in "try" that produced an error. In this case it was an overflow
                                        //So here, instead of using the equation in "try", it skips to here and sets ainur.proactivePoints to int.MinValue 
                                        ainur.proactivePoints = int.MaxValue;
                                    }
                                    Console.WriteLine("numval is {0}", numVal);
                                    Console.WriteLine("Total Proactive points is {0}", ainur.proactivePoints);

                                    var text = $"{maia} has been awarded {numVal} Proactive Points. Good job! {maia} has earned a total of {ainur.proactivePoints} Proactive Points. " +
                                        $"You should feel proud of earning these fake internet points. Even tho nobody else is using them. But hey, someone is appreciating your work, so that's nice.";

                                    if (numVal == 1)
                                    {
                                        text = $"{maia} has been awarded 1 (one) Proactive Point. Good job? {maia} has earned a total of {ainur.proactivePoints} Proactive Points. " +
                                        $"You should feel proud of earning this singular fake internet point. Even tho nobody else is using them. But hey, someone is kind of appreciating your work, so that's sort of nice, I suppose.";
                                    }

                                    await message.Channel.SendMessageAsync($"{text}");
                                    SaveProactive();
                                }
                                else
                                {
                                    Console.WriteLine("Proactive Points cannot be incremented beyond its current value");
                                    await message.Channel.SendMessageAsync($"{maia} can't have more than 2,147,483,647 Proactive Points. They currently have {ainur.proactivePoints} Proactive Points");
                                }
                            }
                            //End of "try" for awarding Joe Points
                            catch (FormatException)
                            {
                                Console.WriteLine("Input string '{0}' is not a sequence of digits", finalTrim);
                                await message.Channel.SendMessageAsync($"Input string '{finalTrim}' is not a sequence of digits");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("The number cannot fit in an Int32");
                                await message.Channel.SendMessageAsync("You can't assign more than 2,147,483,647 Proactive Points at a time");
                            }//End awarding Try
                            Console.WriteLine("End of awarding Proactive Points \n");
                            foundProactive = true;
                            break;
                        }//End of awarding Proactive Points

                        //Taking away Proactive Points
                        else if (lowmess.IndexOf($"{maia} loses ", StringComparison.OrdinalIgnoreCase) >= 0 && Mod)
                        {
                            //Strings
                            int numVal;
                            string MyString = message.Content;
                            Console.WriteLine($"Input string: {MyString}");

                            //Trim strings
                            string proactivePoints = $"loses proactive points P {maia.ToLower()}";
                            char[] proactiveTrim = proactivePoints.ToCharArray();
                            string firstTrim = MyString.TrimStart(proactiveTrim);
                            string finalString = firstTrim.TrimEnd(proactiveTrim);

                            //Console lines for errors
                            Console.WriteLine($"First trim: {firstTrim}");
                            Console.WriteLine($"Final trim: {finalString}");

                            //Start losing Try
                            try
                            {
                                numVal = Convert.ToInt32(finalString);
                                if (numVal > int.MinValue)
                                {
                                    try
                                    {
                                        //Tries everything inside its brackets
                                        //checked() checks to see if (person.proactivePoints - numVal) produces an error (usually an under/overflow)
                                        //If there is no error, the equation carrys out as normal
                                        //If there is an error, it goes to "catch"
                                        ainur.proactivePoints = checked(ainur.proactivePoints - numVal);

                                    }
                                    catch (OverflowException)
                                    {
                                        //Catch is for anything in "try" that produced an error. In this case it was an underflow
                                        //So here, instead of using the equation in "try", it skips to here and sets person.joePoints to int.MinValue 
                                        ainur.proactivePoints = int.MinValue;

                                    }
                                    SaveProactive();

                                    Console.WriteLine("numval is {0}", numVal);
                                    Console.WriteLine("Total Proactive Points is {0}", ainur.proactivePoints);

                                    //Message for losing Proactive Points
                                    var text = $"{maia} has lost {numVal} Proactive points. I'd make a big deal out of you losing Proactive Points, but let's face it. Who's really keeping track? " +
                                        $"Well, besides me. {maia} now has {ainur.proactivePoints} Proactive Points";

                                    //Message for if Proactive Points is less than zero but greater than MinValue
                                    if ((ainur.proactivePoints < 0) && (ainur.proactivePoints > int.MinValue))
                                    {
                                        if (lowmess.Contains("noc") || lowmess.Contains("bob"))
                                        {
                                            text = $"Congratulations, {maia}. You just lost {numVal} Proactive Points, which brings your total down to {ainur.proactivePoints} Proactive Points. Good job going negative. Just like your personality. " +
                                                $"You should probably work on that";
                                        }

                                        else
                                        {
                                            text = $"That's a big oof, {maia}. You not only lost {numVal} Proactive Points, but you now have gone negative with {ainur.proactivePoints}. I hope everything is ok with you. I'm sure you'll be back on top" +
                                                $"soon enough";
                                        }
                                    }

                                    //Message if Proactive points equals int.MinValue
                                    else if (ainur.proactivePoints == int.MinValue)
                                    {
                                        text = "Shame";
                                    }

                                    //Sends one of the above messages
                                    await message.Channel.SendMessageAsync($"{text}");
                                }
                                else
                                {
                                    Console.WriteLine("Proactive Points cannot be incremented beyond its current value");
                                    await message.Channel.SendMessageAsync($"Proactive Points cannot be less than 2,147,483,647. {maia} currently has {ainur.proactivePoints} Proactive Points");
                                }
                            }
                            //End of losing Proactive points "try"
                            catch (FormatException)
                            {
                                Console.WriteLine("Input string '{0}' is not a sequence of digits", finalString);
                                await message.Channel.SendMessageAsync($"Input string '{finalString}' is not a sequence of digits");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("The number cannot fit in an Int32");
                                await message.Channel.SendMessageAsync("You can't take away more than 2,147,483,647 Proactive Points at a time");
                            }//End losing Try
                            Console.WriteLine("End of taking away Proactive Points \n");
                            foundProactive = true;
                            break;
                        }//End losing Proactive Points

                        //Clear Proactive Points
                        else if (lowmess.IndexOf($"clear {maia}'s proactive points", StringComparison.OrdinalIgnoreCase) >= 0 && Mod)
                        {
                            ainur.proactivePoints = 0;
                            var text = $"{maia}'s Proactive Points have been reset. {maia}'s Proactive Points have been reset to {ainur.proactivePoints}";
                            await message.Channel.SendMessageAsync(text);
                            SaveProactive();
                            foundProactive = true;
                            break;
                        }//End clear Proactive Points

                        //Proactive Points total
                        else if (lowmess.IndexOf($"{maia}'s proactive points", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            //setting proactive points to a specific amount
                            if (Mod && lowmess.IndexOf($"set {maia}'s proactive points to", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                //Strings
                                int numVal;
                                string MyString = message.Content;
                                Console.WriteLine($"PP manually set on: {Today} \nInput string: {MyString}");

                                //Trim Statements
                                string proactivePoints = $"set proactive points P to {maia.ToLower()}'s";
                                char[] proactiveTrim = proactivePoints.ToCharArray();
                                string firstTrim = MyString.TrimStart(proactiveTrim);
                                string finalString = firstTrim.TrimEnd(proactiveTrim);

                                //Console lines for errors
                                Console.WriteLine($"First trim: {firstTrim}");
                                Console.WriteLine($"Final trim: {finalString}");

                                //start specific PP try
                                try
                                {
                                    numVal = Convert.ToInt32(finalString);
                                    if ((numVal > int.MinValue) && (numVal < int.MaxValue))
                                    {
                                        try
                                        {
                                            //Tries everything inside its brackets
                                            //checked() checks to see if (person.proactivePoints - numVal) produces an error (usually an under/overflow)
                                            //If there is no error, the equation carrys out as normal
                                            //If there is an error, it goes to "catch"
                                            ainur.proactivePoints = numVal;

                                        }
                                        catch (OverflowException)
                                        {
                                            //Catch is for anything in "try" that produced an error.
                                            //So here, instead of using the equation in "try", it skips to here
                                            Console.WriteLine("Operation could not be completed");
                                        }
                                        SaveProactive();

                                        Console.WriteLine("numval is {0}", numVal);
                                        Console.WriteLine("Total Proactive Points is {0}", ainur.proactivePoints);

                                        //Message for setting Proactive Points
                                        var text = $"{maia}'s Proactive points have been set to {ainur.proactivePoints} Proactive Points";
                                        //Sending above message
                                        await message.Channel.SendMessageAsync($"{text}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Proactive Points cannot be incremented beyond its current value");
                                        await message.Channel.SendMessageAsync($"Proactive Points cannot be more than 2,147,483,647, or less than -2,147,483,647. {maia} currently has {ainur.proactivePoints} Proactive Points");
                                    }

                                }
                                //end of try
                                catch (FormatException)
                                {
                                    Console.WriteLine("Input string '{0}' is not a sequence of digits", finalString);
                                    await message.Channel.SendMessageAsync($"Input string '{finalString}' is not a sequence of digits");
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("The number cannot fit in an Int32");
                                    await message.Channel.SendMessageAsync("You can't assign more than 2,147,483,647 or less than -2,147,483,647 Proactive Points at a time");
                                }
                                //End specific PP try

                                Console.WriteLine("End of manual PP set \n");
                                foundProactive = true;
                                break;
                            }//end of manual Proactive Points

                            //PP count
                            else
                            {
                                var text = $"{maia} has {ainur.proactivePoints} Proactive Points";
                                await message.Channel.SendMessageAsync(text);
                                foundProactive = true;
                                break;
                            }//End PP count

                        }//End Proactive Points total
                    }
                    if (foundProactive)
                        break;
                    //end of 2nd foreach

                }//end of 1st foreach

            }//End of Proactive Points


            //Joe Points
            else if (lowmess.Contains("joe point"))
            {
                var foundPoints = false;
                foreach (var person in people)
                {
                    foreach (var name in person.names)
                    {
                        //Awarding Joe Points
                        if (Mod && (lowmess.IndexOf($"{name} gets", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"{name} has been awarded", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"to {name}", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            int numVal;
                            string MyString = message.Content;
                            Console.WriteLine($"Joe Points assigned: {Today} \nInput string: '{MyString}'");

                            //Strings
                            string toTrim = $"has been awarded gets joe points JP to {name}";

                            //Convert strings to char[]
                            char[] trimChar = toTrim.ToCharArray();

                            //Trim OG string to return an int
                            string beginTrim = MyString.TrimStart(trimChar);
                            string endTrim = beginTrim.TrimEnd(trimChar);

                            //Console lines for testing
                            Console.WriteLine("trimmedchar: '{0}'", toTrim);
                            Console.WriteLine("beginTrim: '{0}'", beginTrim);
                            Console.WriteLine("endTrim: '{0}'", endTrim);

                            //Start awarding JP try
                            try
                            {
                                numVal = Convert.ToInt32(endTrim);
                                if (numVal < int.MaxValue)
                                {
                                    try
                                    {
                                        //Tries everything inside its brackets
                                        //checked() checks to see if (person.joePoints + numVal) produces an error (usually an under/overflow)
                                        //If there is no error, the equation carrys out as normal
                                        //If there is an error, it goes to "catch"
                                        person.joePoints = checked(person.joePoints + numVal);
                                        //calculation worked without overflow
                                    }
                                    catch (OverflowException)
                                    {
                                        //Catch is for anything in "try" that produced an error. In this case it was an overflow
                                        //So here, instead of using the equation in "try", it skips to here and sets person.joePoints to int.MinValue 
                                        person.joePoints = int.MaxValue;
                                    }

                                    Console.WriteLine("numval is {0}", numVal);
                                    Console.WriteLine("Joe Points is {0}\n", person.joePoints);

                                    var text = $"{name} has been awarded {numVal} Joe Points. Good job! Take some time to think about why {name} is better than you. {name} has been awarded a total of {person.joePoints} Joe Points.";
                                    //for a singular point
                                    if (numVal == 1)
                                    {
                                        text = $"{name} has been awarded 1 (one) Joe Point. Good job, I guess? Take some time to think about why {name} is ever so slightly better than you. {name} has been awarded a total of {person.joePoints} Joe Points.";
                                    }
                                    //for awarding points as normal
                                    else if (numVal > 1)
                                    {
                                        text = $"{name} has been awarded {numVal} Joe Points. Good job! Take some time to think about why {name} is better than you. {name} has been awarded a total of {person.joePoints} Joe Points.";
                                    }
                                    //for when awarding negative points
                                    else if (numVal < 0)
                                    {
                                        //For losing a singular JP
                                        if (numVal == -1)
                                        {
                                            text = $"{name} has lost 1 (one) Joe Point. {name} should take some time to reflect on what they've done and make amends with Joe. Hopefully it won't be too hard since {name} only lost one Joe Point, " +
                                            $"but we'll see. {name} now has {person.joePoints} Joe Points.";
                                        }
                                        //for losing more than 1 JP
                                        else if (numVal < -1)
                                        {
                                            text = $"{name} has lost {numVal} Joe Points. {name} should take some time to reflect on what they've done and make amends with Joe. {name} now has {person.joePoints} Joe Points.";
                                        }
                                    }
                                    await message.Channel.SendMessageAsync(text);
                                    SavePeople();
                                }
                                //Overflow 
                                else
                                {
                                    Console.WriteLine("Joe Points cannot be incremented beyond its current value");
                                    await message.Channel.SendMessageAsync($"{name} can't have more than 2,147,483,647 Joe Points. They currently have {person.joePoints} Joe Points");
                                }
                            }
                            //End of awarding JP "try"
                            catch (FormatException)
                            {
                                Console.WriteLine("Input string '{0}' is not a sequence of digits", endTrim);
                                await message.Channel.SendMessageAsync($"Input string '{endTrim}' is not a sequence of digits");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("The number cannot fit in an Int32");
                                await message.Channel.SendMessageAsync("You can't assign more than 2,147,483,647 Joe Points at a time");
                            }//End awarding JP try

                            Console.WriteLine("End of awarding Joe Points \n");
                            foundPoints = true;
                            break;
                        }//End of awarding Joe Points

                        //Subtracting Joe Points
                        else if (Mod && (lowmess.IndexOf($"{name} loses", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"from {name}", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            int numVal;
                            string MyString = message.Content;
                            Console.WriteLine($"Joe Points taken away {Today} \nInput string is: '{MyString}'");

                            //strings
                            string toTrim = $"loses from joe points JP {name.ToLower()}";

                            //convert string to char[]
                            char[] trimChar = toTrim.ToCharArray();

                            //Trimming og string
                            string beginTrim = MyString.TrimStart(trimChar);
                            string endTrim = beginTrim.TrimEnd(trimChar);

                            string stringEdit2 = MyString.Remove(0, name.Length + 6);
                            string finalString = stringEdit2.TrimEnd(trimChar);
                            string trimmedString = finalString.Trim();

                            //Console lines
                            Console.WriteLine("toTrim: '{0}'", toTrim);
                            Console.WriteLine("beginTrim: '{0}'", beginTrim);
                            Console.WriteLine("endTrim: '{0}'", endTrim);

                            //Start losing JP try
                            try
                            {
                                numVal = Convert.ToInt32(trimmedString);
                                if (numVal > int.MinValue)
                                {
                                    try
                                    {
                                        //Tries everything inside its brackets
                                        //checked() checks to see if (person.joePoints - numVal) produces an error (usually an under/overflow)
                                        //If there is no error, the equation carrys out as normal
                                        //If there is an error, it goes to "catch"
                                        person.joePoints = checked(person.joePoints - numVal);

                                    }
                                    catch (OverflowException)
                                    {
                                        //Catch is for anything in "try" that produced an error. In this case it was an underflow
                                        //So here, instead of using the equation in "try", it skips to here and sets person.joePoints to int.MinValue 
                                        person.joePoints = int.MinValue;
                                    }
                                    SavePeople();
                                    Console.WriteLine("numval is {0}", numVal);
                                    Console.WriteLine("Joe Points is {0}\n", person.joePoints);

                                    var text = $"{name} has lost {numVal} Joe Points. {name} should take some time to reflect on what they've done and make amends with Joe. {name} now has {person.joePoints} Joe Points.";
                                    //Losing a singular JP
                                    if (numVal == 1)
                                    {
                                        text = $"{name} has lost 1 (one) Joe Point. {name} should take some time to reflect on what they've done and make amends with Joe. Hopefully it won't be too hard since {name} only lost one Joe Point, " +
                                            $"but we'll see. {name} now has {person.joePoints} Joe Points.";
                                    }
                                    //when JP is less than zero
                                    if (person.joePoints < 0)
                                    {
                                        text = $"{name} has done a real dumb. They somehow not only lost *all* their Joe Points, but they now have a negative amount of Joe Points. Looks like {name} has a lot of amends to make with Joe. " +
                                            $"{name} now has {person.joePoints} Joe Points.";
                                        //when JP is at absolute min value
                                        if (person.joePoints == int.MinValue)
                                        {
                                            text = $"Wow. {name} has really messed up. {name} now has {person.joePoints} Joe Points. Which is literally the lowest amount possible with the current system. {name} should be deeply ashamed " +
                                                $"and should start begging for Joe's forgiveness.";
                                        }
                                    }

                                    await message.Channel.SendMessageAsync(text);
                                }
                                else
                                {
                                    Console.WriteLine("Joe Points cannot be incremented beyond its current value");
                                    await message.Channel.SendMessageAsync($"Joe Points cannot be less than 2,147,483,647. {name} currently has {person.joePoints} Joe Points.");
                                }
                            }
                            //End of lose JP "try"
                            catch (FormatException)
                            {
                                Console.WriteLine("Input string '{0}' is not a sequence of digits", trimmedString);
                                await message.Channel.SendMessageAsync($"Input string '{trimmedString}' is not a sequence of digits");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("The number cannot fit in an Int32");
                                await message.Channel.SendMessageAsync("You can't take away more than 2,147,483,647 at a time");
                            }
                            //end losing JP try

                            Console.WriteLine("End of taking away Joe Points \n");
                            foundPoints = true;
                            break;
                        }//End of lose JP

                        //Clear Joe Points
                        else if (Mod && (lowmess.IndexOf($"clear {name}'s joe points", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            person.joePoints = 0;
                            var text = $"{name}'s Joe Points have been reset. Press F to pay respects. {name}'s Joe Points have been reset to {person.joePoints}";
                            await message.Channel.SendMessageAsync(text);
                            SavePeople();
                            foundPoints = true;
                            break;
                        }//End of clearing Joe Points

                        //Joe Points count and manual JP set
                        else if (lowmess.IndexOf($"{name}'s joe points", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            //Manual JP set
                            if (Mod && lowmess.IndexOf($"set {name}'s joe points to", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                //Strings
                                int numVal;
                                string MyString = message.Content;
                                Console.WriteLine($"Joe Points manually set on: {Today} \nInput string: {MyString}");

                                //Trim Statements
                                string joePoints = $"set joe points JP to {name.ToLower()}'s";
                                char[] jpTrim = joePoints.ToCharArray();
                                string firstTrim = MyString.TrimStart(jpTrim);
                                string finalString = firstTrim.TrimEnd(jpTrim);

                                //Console lines for errors
                                Console.WriteLine($"First trim: {firstTrim}");
                                Console.WriteLine($"Final trim: {finalString}");

                                //Start manual JP try
                                try
                                {
                                    numVal = Convert.ToInt32(finalString);
                                    if ((numVal > int.MinValue) && (numVal < int.MaxValue))
                                    {
                                        try
                                        {
                                            //Tries everything inside its brackets
                                            //checked() checks to see if (person.proactivePoints - numVal) produces an error (usually an under/overflow)
                                            //If there is no error, the equation carrys out as normal
                                            //If there is an error, it goes to "catch"
                                            person.joePoints = numVal;

                                        }
                                        catch (OverflowException)
                                        {
                                            //Catch is for anything in "try" that produced an error.
                                            //So here, instead of using the equation in "try", it skips to here
                                            var msg = "Could not carry out request";

                                            Console.WriteLine($"{msg}");
                                            await message.Channel.SendMessageAsync($"{msg}");
                                        }
                                        SaveProactive();

                                        Console.WriteLine("numval is {0}", numVal);
                                        Console.WriteLine("Total Joe Points is {0}", person.joePoints);

                                        //Message for setting Proactive Points
                                        var text = $"{name}'s Joe Points have been set to {person.joePoints} Joe Points";
                                        //Sending above message
                                        await message.Channel.SendMessageAsync($"{text}");
                                    }
                                    else
                                    {
                                        int difference = numVal - int.MaxValue;
                                        Console.WriteLine("Joe Points cannot be incremented beyond its current value");
                                        var text = $"Joe Points cannot be more than 2,147,483,647, or less than -2,147,483,647. {name} currently has {person.joePoints} Joe Points " +
                                            $"and you tried to set their Joe Points to {numVal}, which is {difference} more points than currently possible. ";
                                        await message.Channel.SendMessageAsync($"{text}");
                                    }

                                }
                                //end of try
                                catch (FormatException)
                                {
                                    Console.WriteLine("Input string '{0}' is not a sequence of digits", finalString);
                                    await message.Channel.SendMessageAsync($"Input string '{finalString}' is not a sequence of digits");
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine($"The number cannot fit in an Int32");
                                    await message.Channel.SendMessageAsync("You can't assign more than 2,147,483,647 or less than -2,147,483,647 Joe Points at a time");
                                }//End manual JP try
                                Console.WriteLine("End of manual JP set \n");
                                foundPoints = true;
                                break;
                            }
                            //end manual JP set

                            //JP count
                            else
                            {
                                var text = $"{name} has {person.joePoints} Joe Points";
                                await message.Channel.SendMessageAsync(text);
                                foundPoints = true;
                                break;
                            }
                            //end JP count and manual JP set
                        }//End of JP Count

                        //Degen failsafe
                        else if (Pleb && lowmess.IndexOf($"{name} gets", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            var nope = "You are not authorized to hand out Joe Points. Nice try tho";
                            var magicWord = "https://cdn.discordapp.com/attachments/895367300390211634/929138766248022107/the-magic-word.gif";
                            var msg = $"{nope} \n{magicWord}";

                            if (Degen)
                            {
                                Random random = new Random();
                                int value = random.Next(0, bobSass.Length);
                                var suckIt = bobSass[value];
                                msg = $"{nope} \n{magicWord} \n{bobSass[value]}";
                            }

                            await message.Channel.SendMessageAsync($"{msg}");
                            foundPoints = true;
                            break;
                        }//End of degen failsafe
                    }
                    //End of 2nd "foreach"
                    if (foundPoints)
                        break;
                }
                //End of 1st "foreach"
            }//End of Joe Points

            /// <summary>
            /// Points Count
            /// Responds with joe points and Proactive Points in one message
            /// separate command for blame count
            /// </summary>
            else if (lowmess.Contains("count"))
            {
                var foundCount = false;
                var jpCount = "undefined";
                var ppCount = "undefined";

                //PP Count
                foreach (var ainur in proactive)
                {
                    foreach (var maia in ainur.maiar)
                    {
                        //PP Count
                        if (lowmess.IndexOf($"{maia}'s proactive count", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"{maia}'s pp count", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            ppCount = $"{maia} has {ainur.proactivePoints} Proactive Points";
                            await message.Channel.SendMessageAsync($"{ppCount}");
                            foundCount = true;
                            break;
                        }
                        if (foundCount)
                            break;
                        //end maia foreach
                    }
                    /* end ainur foreach
                     * End of PP Count 
                     */
                }//End PP Count

                //Joe Points and Blame Count
                foreach (var person in people)
                {
                    foreach (var name in person.names)
                    {
                        //Joe Points Count
                        if (lowmess.IndexOf($"{name}'s points count", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"{name}'s point count", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            jpCount = $"{name} has {person.joePoints} Joe Points";
                            await message.Channel.SendMessageAsync($"{jpCount}");
                            foundCount = true;
                            break;
                        }//End Joe Points count

                        //Blame count
                        else if (lowmess.IndexOf($"{name}'s blame count", StringComparison.OrdinalIgnoreCase) >= 0 || 
                                 lowmess.IndexOf($"{name}'s fault count", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            var text = $"{name} has been blamed {person.blameCount} times";
                            //Sass count for me
                            if (person.id == 334071463210385409)
                            {
                                text = $"People have tried to blame Daniel {person.blameCount} times";
                            }

                            await message.Channel.SendMessageAsync(text);
                            foundCount = true;
                            break;
                        }//End blame count
                    }
                    if (foundCount)
                        break;
                    //end of name foreach
                }//End JP and Blame
                /* end of person foreach
                 * End of Joe Points and Blame count
                 */
            }//End of Points Count


            //Blame Tracker
            else if (lowmess.Contains("blame") || lowmess.Contains("fault"))
            {
                var foundMatch = false;
                foreach (var person in people)
                {
                    foreach (var name in person.names)
                    {
                        //Creates variables for fault and blame
                        //"basically regex is a very useful but complicated format for searching strings for different patterns" -Carrot <3
                        //Regex.Match() means "make regex match [thing]
                        //lowmess is the lowercase message thing
                        //@"b" states the boundaries of what to look for
                        //Regex.Escape($"blame {name}".ToLower()). idk what Regex.Escape means, but this part means "this is the [thing] to look for"
                        //.ToLower makes sure [thing] isn't case sensitive
                        //.Success returns true if it found any match
                        var blameSuccess = Regex.Match(lowmess, @"\b" + Regex.Escape($"blame {name}".ToLower()) + @"\b").Success;
                        var faultSuccess = Regex.Match(lowmess, @"\b" + Regex.Escape($"{name}'s fault".ToLower()) + @"\b").Success;

                        //Blame || fault == true
                        if ((blameSuccess || faultSuccess) && (!lowmess.Contains("clear")))
                        {
                            Console.WriteLine($"Blame used: {Today} \nname: {name} \nblame success: {blameSuccess} \nfault success: {faultSuccess} \nSass chance: {sass}\n");
                            var text = $"It's all {name}'s fault! {name} has been blamed {person.blameCount} times";
                            var msg = "if you say so";

                            //Bob's sass
                            if (!Custodian && (sass == 50))
                            {
                                text = $"{sassVal}";
                            }

                            //If Bob tries to sass me
                            else if ((sass == 50) && Custodian)
                            {
                                person.blameCount++;
                                msg = "I *would* say no, but I actually like Daniel so I'll do it";
                                await message.Channel.SendMessageAsync($"{msg} \n{text}");
                                SavePeople();
                            }

                            //for Will and his script
                            else if (Will)
                            {
                                var alert = $"<@334071463210385409> Will might be using his stupid script";
                                person.blameCount++;
                                text = $"It's all {name}'s fault! {name} has been blamed {person.blameCount} times";
                                //if someone tries to blame me
                                if (person.id == 334071463210385409)
                                {
                                    text = "Nah, fam. I ain't blaming The Custodian. " +
                                        "People have tried to blame him {person.blameCount} times";
                                }

                                await message.Channel.SendMessageAsync($"{alert}");
                                await message.Channel.SendMessageAsync(text);
                                SavePeople();
                            }

                            //Normal blame
                            else if (AllButWill)
                            {
                                person.blameCount++;
                                text = $"It's all {name}'s fault! {name} has been blamed {person.blameCount} times";

                                //if someone tries to blame me
                                if (person.id == 334071463210385409)
                                {
                                    text = $"Nah, fam. I ain't blaming The Custodian. " +
                                        $"People have tried to blame him {person.blameCount} times";
                                }

                                await message.Channel.SendMessageAsync(text);
                                SavePeople();
                            }

                            foundMatch = true;
                            break;
                        } //End blaming someone

                        //Clearing blame
                        else if ((lowmess.Contains("clear")) && Mod)
                        {
                            if (lowmess.IndexOf($"clear {name}'s blame", StringComparison.OrdinalIgnoreCase) >= 0 ||
                                lowmess.IndexOf($"clear {name}'s fault", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                person.blameCount = 0;
                                var text = $"{name}'s blame count has been reset to {person.blameCount}";
                                await message.Channel.SendMessageAsync(text);
                                SavePeople();
                                foundMatch = true;
                                break;
                            }
                        } //End clearing blame
                    } //end of 2nd foreach
                    if (foundMatch)
                        break;

                } //end of 1st foreach
            } //End Blame

            //Test Code
            else if (Custodian && Testing)
            {
                //Person foreach
                var foundPeople = false;
                foreach (var person in people)
                {
                    foreach (var name in person.names)
                    {
                        if (lowmess.Contains("people code"))
                        {
                            Console.WriteLine("just a test");
                            foundPeople = true;
                            break;
                        }

                        else if (userID == 334071463210385409)
                        {
                            Console.WriteLine("test successful");
                            foundPeople = true;
                            break;
                        }

                        //other timer test
                        else if (lowmess.Equals("blah"))
                        {
                            var time2 = DateTime.Now;
                            Console.WriteLine($"Time: {Today}. Time1: {time1}. Time2: {time2}");
                            TimeSpan interval = time2 - Today;
                            Console.WriteLine($"{interval}");
                        }

                        foundPeople = true;
                        break;
                    }
                    //end of second people foreach
                    if (foundPeople)
                        break;
                }

                //Proactive foreach
                var foundProactive = false;
                foreach (var ainur in proactive)
                {
                    foreach (var maia in ainur.maiar)
                    {
                        if (lowmess.Contains("proactive code"))
                        {
                            Console.WriteLine("Proactive peeps test");
                            foundProactive = true;
                            break;
                        }
                        foundProactive = true;
                        break;
                    }
                    //end of second proactive peeps foreach
                    if (foundProactive)
                        break;
                }

                //Various tests 
                if (lowmess.Contains("test"))
                {
                    var msg = "test";
                    int timerCycle = 0;

                    //Emote testing
                    if (lowmess.StartsWith("emote"))
                    {
                        var emotes = $"filler";
                        await message.Channel.SendMessageAsync($"{emotes}");
                        await message.AddReactionAsync(facepalm);
                    }

                    //Experiment Code
                    else if (lowmess.StartsWith("experiment"))
                    {
                        await message.Channel.SendMessageAsync($"hello");
                    }

                    //Channel ID etc
                    else if (lowmess.StartsWith("channel"))
                    {
                        await message.Channel.SendMessageAsync(msg);
                    }

                    //Shortcut testing
                    else if (lowmess.StartsWith("shortcut"))
                    {
                        msg = "shortcut response";
                        await message.Channel.SendMessageAsync($"{msg}");
                    }

                    //Timer testing
                    else if (lowmess.StartsWith("template"))
                    {
                        timerCycle = 0;
                        int maxCycles = 3;
                        await message.Channel.SendMessageAsync("timer started");

                        //using a while loop
                        while (timerCycle < 5)
                        {
                            int finishedCycle = timerCycle + 1;
                            GlobalServices.TimerTemplate.ExampleTimer();
                            timerCycle++;
                            Console.WriteLine($"Cyle number {finishedCycle} finished \n");
                        }

                        Console.WriteLine("All cycles complete");

                        //using a for loop
                        for (timerCycle = 0; timerCycle < maxCycles; timerCycle++)
                        {
                            int finishedCycle = timerCycle + 1;
                            int cyclesRemain = maxCycles - finishedCycle;

                            GlobalServices.LiveTimers.BlameTimer();
                            Console.WriteLine($"Cyle {finishedCycle} finished \n{cyclesRemain} cycles remain \n");
                            await message.Channel.SendMessageAsync($"Cycle {finishedCycle} finished. {cyclesRemain} cycles remain");
                        }

                        Console.WriteLine("All cycles complete");
                    }

                    //Blame timer test
                    else if (lowmess.StartsWith("timer"))
                    {
                        timerCycle = 0;
                        int maxCycles = 3;
                        var potat = "https://tenor.com/view/bravo-six-going-dark-cod-sergeant-mw-modern-warfare-gif-14985183";

                        await message.Channel.SendMessageAsync($"{potat}");

                        for (timerCycle = 0; timerCycle < maxCycles; timerCycle++)
                        {
                            int finishedCycle = timerCycle + 1;
                            int cyclesRemain = maxCycles - finishedCycle;

                            GlobalServices.LiveTimers.BlameTimer();

                            //Cycle
                            if (finishedCycle < (maxCycles - 1))
                            {
                                potat = $"Cycle {finishedCycle} finished. {cyclesRemain} cycles remain";

                            }

                            //Last cycle
                            else if (finishedCycle == maxCycles)
                            {
                                potat = $"Last cycle finished. No cycles remain";
                            }

                            Console.WriteLine($"Cyle {finishedCycle} finished \n{cyclesRemain} cycles remain \n");
                            await message.Channel.SendMessageAsync($"{potat}");

                        }

                        Console.WriteLine("All cycles complete");
                        await message.Channel.SendMessageAsync("timer finished");
                    }

                    //random shit
                    else if (lowmess.Contains(PumphouseAdminRole))
                    {
                        var text = $"congratulations {userMention}, your code works. See {PumphouseAdminRole}?";
                        await message.Channel.SendMessageAsync($"{text}");
                    }

                    //interval test
                    else if (lowmess.StartsWith("interval"))
                    {
                        // Define two dates.
                        DateTime date1 = new DateTime(2010, 1, 1, 8, 0, 15);
                        DateTime date2 = new DateTime(2010, 8, 18, 13, 30, 30);
                        var date3 = message.Timestamp;
                        var date4 = DateTime.Now;

                        // Calculate the interval between the two dates.
                        TimeSpan interval = date2 - date1;
                        Console.WriteLine("{0} - {1} = {2}", date2, date1, interval.ToString());
                        Console.WriteLine($"Timestamp: {date3}");

                        // Display individual properties of the resulting TimeSpan object.
                        //Console.WriteLine("   {0,-35} {1,20}", "Total Number of Days:", interval.TotalDays); for gaps in between {0} and {1} used in the example
                        Console.WriteLine("   {0} {1}", "Value of Days Component:", interval.Days);
                        Console.WriteLine("   {0,-35} {1,20}", "Total Number of Days:", interval.TotalDays);
                        Console.WriteLine("   {0,-35} {1,20}", "Value of Hours Component:", interval.Hours);
                        Console.WriteLine("   {0,-35} {1,20}", "Total Number of Hours:", interval.TotalHours);
                        Console.WriteLine("   {0,-35} {1,20}", "Value of Minutes Component:", interval.Minutes);
                        Console.WriteLine("   {0,-35} {1,20}", "Total Number of Minutes:", interval.TotalMinutes);
                        Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Seconds Component:", interval.Seconds);
                        Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Seconds:", interval.TotalSeconds);
                        Console.WriteLine("   {0,-35} {1,20:N0}", "Value of Milliseconds Component:", interval.Milliseconds);
                        Console.WriteLine("   {0,-35} {1,20:N0}", "Total Number of Milliseconds:", interval.TotalMilliseconds);
                        Console.WriteLine("   {0,-35} {1,20:N0}", "Ticks:", interval.Ticks);
                    }

                    else if (lowmess.StartsWith("schedule"))
                    {

                    }
                }
                //end of if("test")

                else if (lowmess.Contains("time") || lowmess.Contains("date"))
                {
                    var BigBen = "What format?";

                    if (lowmess.StartsWith("reg"))
                    {
                        BigBen = Today.ToString();
                    }

                    else if (lowmess.StartsWith("full"))
                    {
                        //day of week, month, day, year, hh:mm:ss
                        BigBen = Today.ToString("F");
                    }

                    else if (lowmess.StartsWith("watch") || lowmess.StartsWith("current"))
                    {
                        //hh:mm:ss
                        BigBen = Today.ToString("T");
                    }

                    else if (lowmess.StartsWith("day and"))
                    {
                        //mm/dd/yyyy hh:mm:ss
                        BigBen = Today.ToString("G");
                    }

                    else if (lowmess.StartsWith("day of week"))
                    {
                        //day of week, full
                        BigBen = Today.ToString("dddd");
                    }

                    else if (lowmess.StartsWith("month"))
                    {
                        //month, date
                        BigBen = Today.ToString("M");
                    }

                    else if (lowmess.StartsWith("year"))
                    {
                        //month, year
                        BigBen = Today.ToString("Y");
                    }

                    await message.Channel.SendMessageAsync($"{BigBen}");
                }
            }
            //End Test Code
        } 
        //end of else if statements
    }
    //end of class Program
}
//end of namespace Bob Biggby

#region Index

//else if statements: 637
/* bees in my head: 739
 * blame: 1711
 * bob: 816
 * count (JP, PP, blame): 1640
 * deez nutz: 745
 * get me a jeffery: 714
 * ghost town: 802
 * going dark/bob is going offline: 727
 * I am the Senate/Custodian: 637
 * insult: 656
 * irish curse: 755
 * Joe Points: 1297
 * leaderboard: 906
 * morning/good morning: 676
 * pinging degens in proactive chats: 809
 * PPs: 1004
 * quickbooks: 783
 * rob's desktop: 751
 * testing: 1812
 * that's you're opinion: 708
 * will's spank bank: 757
 * willy p/willie p: 733
 * you're wrong: 702
 */

//readonly strings: 279
/* adjit string: 325
 * alpha bob commands: 434
 * Alpha bob commands to add: 466
 * bob sass: 399
 * curse: 413
 * good morning string: 342
 * insult string: 283
 * item string: 299
 * marty insult: 488
 * marty praise: 494
 * morning string: 351
 * names w/o reactions: 476
 * people name list: 366
 * proactive name list: 386
 * shakespeare 1: 429
 * shakespeare 2: 430
 * shakespeare 3: 431
 */

#endregion Index