//System
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using CustomReactions;
using System.Web.WebPages;

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
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Interop;
using Discord.Rest;

//Current Version, Desktop 2.8

//Current Verson, Anton 2.7.1

/// <summary>
///  v2.5.3 changelog
///  removed EDI testing
///  Removed skeleton of adding commands to alpha bob's lcr
///  ghost town
///  fixed assigning JP and PP so that it's not case sensitive
///  allowed Brittney to remove PPs 
///  fixed PPs so that the degens don't have access to it
///  
/// v2.5.4 changelog
/// fixed PPs and JPs again so that it's not case sensitive. made sure trim had {name} and {name.ToLower()}
/// deleted og insults from else if
/// added irish curses to insult else if
/// added shakespeare to insult
/// added regular insults to insult
/// made it so that insult will trigger all 3 of the above insults
/// 
/// v2.5.5 changelog
/// added IBS' haunter to the code
/// alphabatized emotes
/// 
/// v2.5.6 changelog
/// added "gif" and "meme" section to elif
/// added Waltersobchakeit
/// 
/// v2.5.7
/// Cleaned up unused code in testing (Bob only)
/// Changed message.Author.isBot to exclude Rob's Bot
/// Added ability to reply to messages
/// added Politics bool
/// updated channels to V3
/// 
/// v2.5.8
/// migrated "commands to add" to their .cs files
/// added "Jon Snow knows nothing" gif
/// fixed "morning" so there's positive and grumpy messages
/// 
/// v2.5.9
/// organized code
/// updated alpha bob's cs file with new commands
/// added "absolutely not" to reaction memes
/// Removed Beta Bob's access to politics channel
/// 
/// V2.6
/// changed numVal in PPs to int64 from int32
/// added reaction to deez nutz
/// 
/// v2.6.1
/// added Dr Strange morning response and reaction meme
/// added sugar free gummy bear reviews
/// transferred Will reactions from Alpha Bob to Beta Bob
/// 
/// v2.7
/// Added newbie to Beta Bob
/// fixed Will's command so that it didn't mess with the blame count or JPs
/// 
/// v2.7.1
/// added lunch reminder
/// 
/// v2.8
/// Added ability to add custom reactions a la Nadeko
/// 
/// </summary>

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

        List<PeopleList.Nadeko> nadekoCommands = new List<PeopleList.Nadeko>();

        List<Response> commands = new List<Response>();

        string basePath;
        string peopleDataPath;
        string proactiveDataPath;
        string customReactionsDataPath;

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
            StartCustomReactions();

            //This makes Bob use token.txt to get the bot token instead of putting the token directly into the code
            var tokenPath = Path.Combine(basePath, "token.txt");
            string token = File.ReadAllText(tokenPath);

            _client.Log += _client_Log;

            await RegisterCommandAsync();

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();

            await Task.Delay(-1);

        }

        #region People Voids
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

        //Creates a list of people and their different nicknames
        void CreatePeople()
        {
            people.Add(new PeopleList.Person("Becky"));
            people.Add(new PeopleList.Person("Brittney"));
            people.Add(new PeopleList.Person("Daniel"));
            people.Add(new PeopleList.Person("Dan"));
            people.Add(new PeopleList.Person("Dennis"));
            people.Add(new PeopleList.Person("Deon"));
            people.Add(new PeopleList.Person("Jake"));
            people.Add(new PeopleList.Person("Joe"));
            people.Add(new PeopleList.Person("Jonathan", "Jon", "Lemons"));
            people.Add(new PeopleList.Person("Justin", "Larson"));
            people.Add(new PeopleList.Person("Martin", "Marty"));
            people.Add(new PeopleList.Person("Rob"));
            people.Add(new PeopleList.Person("Timm"));
            people.Add(new PeopleList.Person("Kikendall", "Kikko", "Kikki"));
            people.Add(new PeopleList.Person("Will"));
            people.Add(new PeopleList.Person("Bob"));
            people.Add(new PeopleList.Person("NOC"));
            people.Sort();
            SavePeople();
        }

        //Saves the list of people to a JSON file titled "people"
        void SavePeople()
        {
            File.WriteAllText(peopleDataPath, JsonConvert.SerializeObject(people, Newtonsoft.Json.Formatting.Indented));
        }

        void LoadPeople()
        {
            people = JsonConvert.DeserializeObject<List<PeopleList.Person>>(File.ReadAllText(peopleDataPath));
        }

        #endregion People Voids

        #region Proactive Voids
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

        //Saves Poractive peeps
        void SaveProactive()
        {
            File.WriteAllText(proactiveDataPath, JsonConvert.SerializeObject(proactive, Newtonsoft.Json.Formatting.Indented));
        }

        void LoadProactive()
        {
            proactive = JsonConvert.DeserializeObject<List<PeopleList.Proactive>>(File.ReadAllText(proactiveDataPath));
        }

        #endregion Proactive Voids

        #region Custom Reactions Voids
        //Start for Custom Reactions
        void StartCustomReactions()
        {
            customReactionsDataPath = Path.Combine(basePath, "customReactionsPath.json");

            var lastEdit = DateTime.Now;
            
            if (File.Exists(customReactionsDataPath))
            {
                Console.WriteLine($"Custom Reactions was last modified {File.GetLastWriteTime(customReactionsDataPath)}. Current time is {DateTime.Now}");

                LoadCustomReactions();
            }

            //if (File.GetLastWriteTime(customReactionsDataPath) != DateTime.Now)
            //{
            //    Console.WriteLine($"Custom Reactions was last modified {File.GetLastWriteTime(customReactionsDataPath)}. Current time is {DateTime.Now}");
            //    CreateCustomReactions();
            //    Console.WriteLine($"Command List update ran {DateTime.Now} \n");
            //}

            else
            {
                CreateCustomReactions();
            }
        }

        //Custom Reactions list
        void CreateCustomReactions()
        {
            commands.Clear();

            //test
            commands.Add(new Response()
                .SetPrompts("hey, bob")
                .SetResponses("bitch"));

            //Symbols
            commands.Add(new Response()
                .SetPrompts("*eyeroll*")
                .SetResponses(NadekoLCR.Eyeroll()));

            commands.Add(new Response()
                .SetPrompts(":(", ":frowning")
                .SetResponses(NadekoLCR.Frown()));

            //A
            commands.Add(new Response()
                .SetPrompts("a great day", "great day")
                .SetResponses(NadekoLCR.AGreatDay()));

            //B
            commands.Add(new Response()
                .SetPrompts("backup checklist")
                .SetResponses(NadekoLCR.BackupChecklist()));

            commands.Add(new Response()
                .SetPrompts("be gone vile man")
                .SetResponses(NadekoLCR.BeGoneVileMan()));

            commands.Add(new Response()
                .SetPrompts("becky")
                .SetResponses(NadekoLCR.Becky()));

            commands.Add(new Response()
                .SetPrompts("big head")
                .SetResponses(NadekoLCR.BigHead()));

            commands.Add(new Response()
                .SetPrompts("big stupid jellyfish")
                .SetResponses(NadekoLCR.BigStupidJellyfish()));

            //2 responses
            commands.Add(new Response()
                .SetPrompts("bitch")
                .SetResponses(NadekoLCR.Bitch()));

            commands.Add(new Response()
                .SetPrompts("bones day")
                .SetResponses(NadekoLCR.BonesDay()));

            commands.Add(new Response()
                .SetPrompts("boss man")
                .SetResponses(NadekoLCR.BossMan()));

            commands.Add(new Response()
                .SetPrompts("brittney")
                .SetResponses(NadekoLCR.Brittney()));

            //C
            commands.Add(new Response()
                .SetPrompts("can it wait for a bit?", "can it wait for a bit")
                .SetResponses(NadekoLCR.CanItWaitForABit()));

            commands.Add(new Response()
                .SetPrompts("castle")
                .SetResponses(NadekoLCR.Castle()));

            commands.Add(new Response()
                .SetPrompts("check the handbook")
                .SetResponses(NadekoLCR.CheckTheHandbook()));

            commands.Add(new Response()
                .SetPrompts("chloe price")
                .SetResponses(NadekoLCR.ChloePrice()));

            commands.Add(new Response()
                .SetPrompts("custodian")
                .SetResponses(NadekoLCR.Custodian()));

            //D
            commands.Add(new Response()
                .SetPrompts("dab")
                .SetResponses(NadekoLCR.Dab()));

            commands.Add(new Response()
                .SetPrompts("dan")
                .SetResponses(NadekoLCR.Dan()));

            //2 responses
            commands.Add(new Response()
                .SetPrompts("dan w")
                .SetResponses(NadekoLCR.DanW()));

            commands.Add(new Response()
                .SetPrompts("daniel")
                .SetResponses(NadekoLCR.Daniel()));

            commands.Add(new Response()
                .SetPrompts("deal with it")
                .SetResponses(NadekoLCR.DealWithIt()));

            commands.Add(new Response()
                .SetPrompts("dennis")
                .SetResponses(NadekoLCR.Dennis()));

            //2 responses
            commands.Add(new Response()
                .SetPrompts("dew it")
                .SetResponses(NadekoLCR.DewIt()));

            //5 responses. includes dew it
            commands.Add(new Response()
                .SetPrompts("do it")
                .SetResponses(NadekoLCR.DoIt()));

            //E
            commands.Add(new Response()
                .SetPrompts("eat a chode")
                .SetResponses(NadekoLCR.EatAChode()));

            commands.Add(new Response()
                .SetPrompts("eat a dick")
                .SetResponses(NadekoLCR.EatADick()));

            commands.Add(new Response()
                .SetPrompts("escalate")
                .SetResponses(NadekoLCR.Escalate()));

            commands.Add(new Response()
                .SetPrompts("ess")
                .SetResponses(NadekoLCR.ESS()));

            commands.Add(new Response()
                .SetPrompts("ew")
                .SetResponses(NadekoLCR.Ew()));

            commands.Add(new Response()
                .SetPrompts("excellent")
                .SetResponses(NadekoLCR.Excellent()));

            commands.Add(new Response()
                .SetPrompts("extended it alignments", "extended it alignment chart")
                .SetResponses(NadekoLCR.ExtendedITAlignments()));

            //F
            commands.Add(new Response()
                .SetPrompts("fc3 fuck you")
                .SetResponses(NadekoLCR.FC3FuckYou()));

            commands.Add(new Response()
                .SetPrompts("fresh prince", "fresh prince of bel air")
                .SetResponses(NadekoLCR.FreshPrince()));

            commands.Add(new Response()
                .SetPrompts("fuck")
                .SetResponses(NadekoLCR.Fuck()));

            commands.Add(new Response()
                .SetPrompts("fuck off")
                .SetResponses(NadekoLCR.FuckOff()));

            commands.Add(new Response()
                .SetPrompts("fuck that")
                .SetResponses(NadekoLCR.FuckThat()));

            //3 responses
            commands.Add(new Response()
                .SetPrompts("fuck you")
                .SetResponses(NadekoLCR.FuckYou()));

            //G
            commands.Add(new Response()
                .SetPrompts("general kenobi")
                .SetResponses(NadekoLCR.GeneralKenobi()));

            //H
            commands.Add(new Response()
                .SetPrompts("haha good one")
                .SetResponses(NadekoLCR.HahaGoodOne()));

            commands.Add(new Response()
                .SetPrompts("have you checked your butthole", "i know where it is")
                .SetResponses(NadekoLCR.HaveYouCheckedYourButthole()));

            commands.Add(new Response()
                .SetPrompts("hehe")
                .SetResponses(NadekoLCR.Hehe()));
            commands.Add(new Response()
                .SetPrompts("hello there")
                .SetResponses(NadekoLCR.HelloThere()));

            commands.Add(new Response()
                .SetPrompts("help desk")
                .SetResponses(NadekoLCR.HelpDesk()));

            commands.Add(new Response()
                .SetPrompts("help desk main line")
                .SetResponses(NadekoLCR.HelpDeskMainLine()));

            commands.Add(new Response()
                .SetPrompts("help desk mating ritual")
                .SetResponses(NadekoLCR.HelpDeskMatingRitual()));

            commands.Add(new Response()
                .SetPrompts("help me")
                .SetResponses(NadekoLCR.HelpMe()));
            
            ///here strictly for bookmarking
            //commands.Add(new Response()
                //.SetPrompts("hey bob")
                //.SetResponses(NadekoLCR.HeyBob()));

            commands.Add(new Response()
                .SetPrompts("hmm no")
                .SetResponses(NadekoLCR.HmmNo()));

            commands.Add(new Response()
                .SetPrompts("how dare you")
                .SetResponses(NadekoLCR.HowDareYou()));

            //I
            commands.Add(new Response()
                .SetPrompts("https://tenor.com/view/balls-sucking-cherry-lick-his-nuts-gif-15332077")
                .SetResponses(NadekoLCR.InappropriateGif()));

            commands.Add(new Response()
                .SetPrompts("i am untethered", "i am untethered and my rage knows no bounds")
                .SetResponses(NadekoLCR.IAmUntethered()));

            commands.Add(new Response()
                .SetPrompts("i can do this all day")
                .SetResponses(NadekoLCR.ICanDoThisAllDay()));

            commands.Add(new Response()
                .SetPrompts("i have spoken")
                .SetResponses(NadekoLCR.IHaveSpoken()));

            commands.Add(new Response()
                .SetPrompts("i know some of those words")
                .SetResponses(NadekoLCR.IKnowSomeOfThoseWords()));

            commands.Add(new Response()
                .SetPrompts("i quit")
                .SetResponses(NadekoLCR.IQuit()));

            //2 responses
            commands.Add(new Response()
                .SetPrompts("i understand that reference", "i understood that reference")
                .SetResponses(NadekoLCR.IUnderstandThatReference()));

            commands.Add(new Response()
                .SetPrompts("i'll allow it")
                .SetResponses(NadekoLCR.IllAllowIt()));

            commands.Add(new Response()
                .SetPrompts("i'll just leave")
                .SetResponses(NadekoLCR.IllJustLeave()));

            commands.Add(new Response()
                .SetPrompts("i'm disappointed")
                .SetResponses(NadekoLCR.ImDissapointed()));

            commands.Add(new Response()
                .SetPrompts("i'm fine")
                .SetResponses(NadekoLCR.ImFine()));

            commands.Add(new Response()
                .SetPrompts("i'm totally working")
                .SetResponses(NadekoLCR.ImTotallyWorking()));

            commands.Add(new Response()
                .SetPrompts("i'm watching you")
                .SetResponses(NadekoLCR.ImWatchingYou()));

            commands.Add(new Response()
                .SetPrompts("it is decided")
                .SetResponses(NadekoLCR.ItIsDecided()));

            commands.Add(new Response()
                .SetPrompts("it is done")
                .SetResponses(NadekoLCR.ItIsDone()));

            commands.Add(new Response()
                .SetPrompts("it's friday")
                .SetResponses(NadekoLCR.ItsFriday()));

            commands.Add(new Response()
                .SetPrompts("it's friday, losers")
                .SetResponses(NadekoLCR.ItsFridayLosers()));

            commands.Add(new Response()
                .SetPrompts("it's monday")
                .SetResponses(NadekoLCR.ItsMonday()));

            commands.Add(new Response()
                .SetPrompts("it's time to press buttons")
                .SetResponses(NadekoLCR.ItsTimeToPressButtons()));

            //J
            commands.Add(new Response()
                .SetPrompts("jake")
                .SetResponses(NadekoLCR.Jake()));

            commands.Add(new Response()
                .SetPrompts("jks")
                .SetResponses(NadekoLCR.JKS()));

            commands.Add(new Response()
                .SetPrompts("joe")
                .SetResponses(NadekoLCR.Joe()));

            commands.Add(new Response()
                .SetPrompts("justin k")
                .SetResponses(NadekoLCR.JustinK()));

            //K
            commands.Add(new Response()
                .SetPrompts("kaseya", "vsa")
                .SetResponses(NadekoLCR.Kaseya()));

            commands.Add(new Response()
                .SetPrompts("kikki", "kikko")
                .SetResponses(NadekoLCR.Kikki()));

            commands.Add(new Response()
                .SetPrompts("know your place")
                .SetResponses(NadekoLCR.KnowYourPlace()));

            //L
            commands.Add(new Response()
                .SetPrompts("larson")
                .SetResponses(NadekoLCR.Larson()));

            commands.Add(new Response()
                .SetPrompts("loveall")
                .SetResponses(NadekoLCR.Loveall()));

            //M
            commands.Add(new Response()
                .SetPrompts("martin")
                .SetResponses(NadekoLCR.Martin()));

            commands.Add(new Response()
                .SetPrompts("marty")
                .SetResponses(NadekoLCR.Marty()));

            commands.Add(new Response()
                .SetPrompts("mild shock")
                .SetResponses(NadekoLCR.MildShock()));

            //N
            commands.Add(new Response()
                .SetPrompts("noc")
                .SetResponses(NadekoLCR.NOC()));

            //O
            commands.Add(new Response()
                .SetPrompts("on site", "onsite")
                .SetResponses(NadekoLCR.OnSite1()));

            commands.Add(new Response()
                .SetPrompts("oops")
                .SetResponses(NadekoLCR.Oops()));

            commands.Add(new Response()
                .SetPrompts("oopsie")
                .SetResponses(NadekoLCR.Oopsie()));

            //P
            commands.Add(new Response()
                .SetPrompts("panda rage")
                .SetResponses(NadekoLCR.PandaRage()));

            commands.Add(new Response()
                .SetPrompts("pebcac")
                .SetResponses(NadekoLCR.Pebcac()));

            commands.Add(new Response()
                .SetPrompts("praise the beheaded")
                .SetResponses(NadekoLCR.PraiseTheBeheaded()));

            commands.Add(new Response()
                .SetPrompts("praise the sun")
                .SetResponses(NadekoLCR.PraiseTheSun()));

            //R
            commands.Add(new Response()
                .SetPrompts("rob")
                .SetResponses(NadekoLCR.Rob()));

            //S
            commands.Add(new Response()
                .SetPrompts("self burn")
                .SetResponses(NadekoLCR.SelfBurn()));

            commands.Add(new Response()
                .SetPrompts("shame")
                .SetResponses(NadekoLCR.Shamne()));

            commands.Add(new Response()
                .SetPrompts("shhh")
                .SetResponses(NadekoLCR.Shhh()));

            commands.Add(new Response()
                .SetPrompts("signal flags")
                .SetResponses(NadekoLCR.SignalFlags()));

            commands.Add(new Response()
                .SetPrompts("slap chris")
                .SetResponses(NadekoLCR.SlapChris()));

            commands.Add(new Response()
                .SetPrompts("stfu")
                .SetResponses(NadekoLCR.STFU()));

            commands.Add(new Response()
                .SetPrompts("suck it")
                .SetResponses(NadekoLCR.SuckIt()));

            //T
            commands.Add(new Response()
                .SetPrompts("thank you bob")
                .SetResponses(NadekoLCR.ThankYouBob()));

            commands.Add(new Response()
                .SetPrompts("that's fucking it")
                .SetResponses(NadekoLCR.ThatsFuckingIt()));

            commands.Add(new Response()
                .SetPrompts("that's rough buddy", "zuko")
                .SetResponses(NadekoLCR.ThatsRoughBuddy()));

            commands.Add(new Response()
                .SetPrompts("that's what she said")
                .SetResponses(NadekoLCR.ThatsWhatSheSaid()));

            commands.Add(new Response()
                .SetPrompts("the beheaded")
                .SetResponses(NadekoLCR.TheBeheaded()));

            commands.Add(new Response()
                .SetPrompts("the discord purge")
                .SetResponses(NadekoLCR.TheDiscordPurge()));

            commands.Add(new Response()
                .SetPrompts("the worst")
                .SetResponses(NadekoLCR.TheWorst()));

            commands.Add(new Response()
                .SetPrompts("this is the way")
                .SetResponses(NadekoLCR.ThisIsTheWay()));

            commands.Add(new Response()
                .SetPrompts("time to work")
                .SetResponses(NadekoLCR.TimeToWork()));

            commands.Add(new Response()
                .SetPrompts("tlj")
                .SetResponses(NadekoLCR.TLJ()));

            //U
            commands.Add(new Response()
                .SetPrompts("ugh")
                .SetResponses(NadekoLCR.Ugh()));

            commands.Add(new Response()
                .SetPrompts("unacceptable")
                .SetResponses(NadekoLCR.Unacceptable()));

            commands.Add(new Response()
                .SetPrompts("unlimited power")
                .SetResponses(NadekoLCR.UnlimitedPower()));

            //W
            commands.Add(new Response()
                .SetPrompts("wait...")
                .SetResponses(NadekoLCR.Wait()));

            commands.Add(new Response()
                .SetPrompts("who gives a fuck")
                .SetResponses(NadekoLCR.WhoGivesAFuck()));

            commands.Add(new Response()
                .SetPrompts("who the hell cares")
                .SetResponses(NadekoLCR.WhoTheHellCares()));

            commands.Add(new Response()
                .SetPrompts("winston")
                .SetResponses(NadekoLCR.Winston()));

            commands.Add(new Response()
                .SetPrompts("wtf")
                .SetResponses(NadekoLCR.WTF()));

            //Y
            commands.Add(new Response()
                .SetPrompts("yes, my liege")
                .SetResponses(NadekoLCR.YesMyLiege()));

            commands.Add(new Response()
                .SetPrompts("you have no power here")
                .SetResponses(NadekoLCR.YouHaveNoPowerHere()));

            commands.Add(new Response()
                .SetPrompts("you're a bitch")
                .SetResponses(NadekoLCR.YoureaABitch()));

            SaveCustomReactions();
        }

        //Saves Custom Reactions
        void SaveCustomReactions()
        {
            File.WriteAllText(customReactionsDataPath, JsonConvert.SerializeObject(commands, Newtonsoft.Json.Formatting.Indented));
        }

        void LoadCustomReactions()
        {
            commands = JsonConvert.DeserializeObject<List<Response>>(File.ReadAllText(customReactionsDataPath));
        }

        //Update Custom Reactions
        void UpdateCustomReactions()
        {
            commands.Clear();
            CreateCustomReactions();

            Console.WriteLine($"Custom Reactions was last modified {File.GetLastWriteTime(customReactionsDataPath)}. Current time is {DateTime.Now}");
        }

        void CustomReastionsEditTime()
        {
            //sets time of last edit
            var lastEdit = DateTime.Now;
            File.GetLastWriteTime(customReactionsDataPath);

            SaveEditTime();
        }

        void SaveEditTime()
        {

        }

        #endregion Custom Reaction Voids

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

        //Reply to a message
        public async Task ReplyWithMessageAsync(SocketUserMessage userMsg)
        {
            await userMsg.ReplyAsync();
        }

        async void LunchReminder(SocketUserMessage userMsg)
        {
            await Task.Delay(TimeSpan.FromHours(1));

            await userMsg.ReplyAsync("lunch is over");
        }

        //Bob's Custom Reactions
        public void OnGetMessage(SocketUserMessage userMessage)
        {
            Console.WriteLine($"OnGetMessage triggered with userMessage: '{userMessage}'");
            foreach (var r in commands)
            {
                if (r.MessageMatches(userMessage))
                {
                    Console.WriteLine($"match found in r '{r}' with userMessage: '{userMessage}'");
                    break;
                }
            }
        }

        #region Readonly Strings

        //When "curse" is the input, Bob will take a word from curse, item, and adjet, string them together, and output them in chat
        //String for curses Bob will use in the curse
        readonly String[] swears =
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

        //Positive morning responses
        readonly String[] goodMorning =
        {
            "What do you mean? " +
                "Do you wish me a good morning or do you mean that it is a good morning wheter I want it or not? " +
                "Or perhaps you mean to say that you feel good on this particular morning? " +
                "Or are you simply stating that this is a morning to be a good on? " +
                "Hm? ",
            //Troy and Abed in the morning
            "https://tenor.com/view/community-troy-and-abed-morning-gif-15331382",
            "https://tenor.com/view/community-gif-8678797",
            //How do you do, fellow kids?
            "https://tenor.com/view/how-do-you-do-fellow-kids-steve-buscemi-30rock-fellow-kids-one-of-us-gif-21904018",
        };
        //Grumpy morning responses
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
            //Kid on merry go round
            "https://tenor.com/view/status-tired-dead-haggard-gif-11733031",
            //Doctor Strange "trapped in this moment endlessly"
            "https://cdn.discordapp.com/attachments/902629594564296725/957430021985820702/viddit_6636a42d.gif",
        };

        //String for people
        readonly String[] peopleNameList = 
        {
            "Becky",
            "Brittney",
            "Brandon",
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
            "Brandon",
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

        //String for Irish curse
        readonly String[] IrishCurse =
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
        readonly String[] shakespearePhrases = { "What, you egg", "Villain, I have done thy mother", "You are a fishmonger", "Well. here is my leg", "Take you me for a sponge, my lord?", 
            "Do you see yonder cloud that's almost in the shape of a camel?", "Eat my leek" };

        //String for regular insults
        readonly String[] regularInsults =
        {
            "Any day is a good day without you in it",
        };

        //Alpha Bob Commands
        readonly String[] AlphaBobCommands =
        {
            //**
            "*eyeroll*",
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
            "kikki", "kikko", "know your place",
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
            //W
            "wait...", "who gives a fuck", "who the hell cares", "winston",
            "wtf", "wtf", "wtf", "wtf", 
            //Y
            "yes, my liege", "you have no power here", "you're a bitch",
            //Z
            "zuko",
        };

        //Beta Bob Commands
        readonly String[] BetaBobCommands =
        {
            "ping",
        };

        //Custom Commands
        readonly String[] CustomCommands =
        {
            "I am the senate", "I am the discord",
            "insult",
            "morning", "good morning",

        };

        //Commands to add to .cs files
        readonly String[] CommandsToAdd =
        {
            //Alpha Bob Commands
            "virtual background",
            
            //Beta Bob Commands
            "bees in my head", "blame", "bob", "bob is going offline",
            "count",
            "deez nuts",
            "EDI testing",
            "get me a jeffery", "ghost town", "going dark", "good morning",
            "I am the Custodian", "I am the Senate", "insult", "irish curse",
            "joe points",
            "leaderboard",
            "morning",
            "pinging degens in proactive chats", "proactive points",
            "quickbooks",
            "rob's desktop",
            "that's you're opinion",
            "will's masterbatorium", "will's spank bank", "willie p", "willy p",
            "you're wrong"
        };

        //Names without reactions
        //Change this to a list of names and their respective reactions
        readonly String[] nameReactions =
        {
            //Becky
            "https://tenor.com/view/artangels-grimes-knight-warrior-sword-gif-4985799",
            //Brittney
            "https://tenor.com/view/ricky-trailer-park-boys-my-brains-shor-circulating-gif-14045185",
            //Custodian
            "https://cdn.discordapp.com/attachments/895367300390211634/929641177131651092/viddit_e3a2f13e.mp4",
            //Dan B
            //Dan W
            "https://tenor.com/view/forrest-gump-forrest-gump-wave-hello-gif-13288735",
            //Daniel
            "https://tenor.com/view/the-joker-heath-ledger-no-plan-gif-5874443",
            //Dennis
            "https://tenor.com/view/help-gif-7380459",
            //Deon
            //Jake
            //Joe
            "https://tenor.com/view/hacker-typing-hacking-computer-codes-gif-17417874",
            //Justin
            //Kikko & Kikki
            "https://tenor.com/view/kikis-delivery-service-ghibli-kiki-kiki-the-witch-anime-gif-16933631",
            //Larson
            "https://tenor.com/view/no-randy-jackson-dawg-gif-12730917",
            //Martin
            "You mean the Director of Inclusion, Care, and Kindness? You can call him DICK for short",
            //Marty
            "https://media.giphy.com/media/UrK4buqejkhK2NTFw9/giphy.gif",
            //Rob
            "https://tenor.com/view/sad-gif-24073087",
            //Timm
            //Will
            "https://media.giphy.com/media/ZXIaNe5qervdfZuBvM/giphy.gif",
            "https://tenor.com/view/uncut-gems-cum-gif-18874799",

            //those without reactions: Dan B, Deon, Jake, Justin, and Timm
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

        //Sugar free gummy bears
        readonly String[] sugarfreeGummies =
        {
            //See you in hell
            "https://cdn.discordapp.com/attachments/951622505959919656/958797753302007858/unknown.png",
            //Digestive overload
            "https://cdn.discordapp.com/attachments/951622505959919656/958798166956867684/unknown.png",
            //St. Diarrhea's Day Massacre
            "https://cdn.discordapp.com/attachments/951622505959919656/958799437797392434/unknown.png",
        };

        readonly String[] troubleshootingWheel =
        {
            "Reinstall it",
            "Reboot", 
            "Recreate profile", 
            "Ignore the problem, see if it comes back", 
            "Clear cached credentials", 
            "Shut down the PC. Head home and don't come back",
            "Go fuck yourself", 
            "Make sure it's plugged in",
            "Check for updates", 
            "Is it wet?", 
            "Try turning the volume up", 
            "Try it in a different browser", 
            "Reseat the cables",
            "Uhhhhhhh (then hang up)", 
            "Your problem is petty and you're wasting my time", 
            "Lo siento no hablo ingles (hang up)",
            "Oh I see we have an ID10t error",
            "PEBCAC.PEBCAC.PEBCAC", 
            "Try logging in again", 
        };

        #endregion Readonly Strings

        private async Task HandleCommandAsync(SocketMessage arg)
        {
            var message = arg as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            //Will return if bot ID is Bob
            if (message.Author.Id == 895393051982307349)
            {
                return;
            };
            int argPos = 0;            

            //converts the input to a string, since it comes in as "socketusermessage"
            string stringmessage = message.ToString();
            //converts string to lowercase so that the message is the same for the sake of the bot
            string lowmess = stringmessage.ToLower();

            #region Shortcuts

            #region Server IDs
            #endregion Server IDs

            #region Pumphouse Server
            //Beta Bob testing
            bool betabobTesting = GlobalShortcuts.DiscordIDs.IsBetaBobTesting(message.Channel);
            bool deezbotsTesting = GlobalShortcuts.DiscordIDs.IsDeezBotsTesting(message.Channel);
            bool botDatabase = GlobalShortcuts.DiscordIDs.IsBotDatabase(message.Channel);
            //EDI only testing
            bool ediTesting = GlobalShortcuts.DiscordIDs.IsEDITesting(message.Channel);
            #endregion Pumphouse Server

            #region IBS Server
            #region channels            
            //Channels
            //Announcements
            bool Announcements = GlobalShortcuts.DiscordIDs.IsAnnouncements(message.Channel);
            bool ProactiveAnnouncements = GlobalShortcuts.DiscordIDs.IsProactiveAnnouncements(message.Channel);

            //Work Chats, V5
            bool ProactiveChat = GlobalShortcuts.DiscordIDs.IsProactiveChat(message.Channel);
            bool HelpDeskChat = GlobalShortcuts.DiscordIDs.IsHelpDesk(message.Channel);

            //Fun Zone, V5
            bool ChillChat = GlobalShortcuts.DiscordIDs.IsChillChat(message.Channel);
            bool MemesChat = GlobalShortcuts.DiscordIDs.IsMemes(message.Channel);

            //Niche Channels, V5
            bool PoliticsChat = GlobalShortcuts.DiscordIDs.IsPolitics(message.Channel);

            //Bot Testing
            //IBS and Pumphouse channels, Bob only
            bool Testing = GlobalShortcuts.DiscordIDs.IsAllBotTesting(message.Channel);
            //IBS testing
            bool ibsTesting = GlobalShortcuts.DiscordIDs.IsIBSTesting(message.Channel);
            #endregion channels

            #region User IDs
            //User IDs
            bool Mod = GlobalShortcuts.DiscordIDs.IsMod(message.Author);
            bool Custodian = GlobalShortcuts.DiscordIDs.IsCustodian(message.Author);
            bool Proactive = GlobalShortcuts.DiscordIDs.IsProactive(message.Author);
            bool Degen = GlobalShortcuts.DiscordIDs.IsDegen(message.Author);
            bool Everybody = GlobalShortcuts.DiscordIDs.Everybody(message.Author);
            bool NonMod = GlobalShortcuts.DiscordIDs.IsNotMod(message.Author);
            bool Will = GlobalShortcuts.DiscordIDs.WillTheJew(message.Author);
            bool AllButWill = GlobalShortcuts.DiscordIDs.AllButWill(message.Author);

            //Bots
            bool BetaBob = GlobalShortcuts.DiscordIDs.IsBothBobs(message.Author);
            bool EDI = GlobalShortcuts.DiscordIDs.IsEDI(message.Author);
            bool TheNOC = GlobalShortcuts.DiscordIDs.IsRobsBestFriend(message.Author);
            bool AllBots = GlobalShortcuts.DiscordIDs.IsAllBots(message.Author);
            #endregion User IDs

            #region Roles
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
            #endregion Roles

            #region misc
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
            #endregion misc
            #endregion IBS Server

            #region Emotes
            ///<summary>
            ///Emotes
            /// If you wanna send an emote as a message or reaction, Bob has to be apart of that server
            /// To send an emote as a message, use $"{emote}" 
            ///</summary>
            
            #region Global Emotes 
            //Global emotes
            var thumbsupEmoji = new Emoji("\uD83D\uDC4D");
            #endregion  Global emotes 

            #region IBS Emotes
            //IBS
            //B
            var BravoFlag = Emote.Parse(GlobalStrings.IBSEmoteStrings.BravoFlag());
            //F
            var facepalm = Emote.Parse(GlobalStrings.IBSEmoteStrings.Facepalm());
            var facts = Emote.Parse(GlobalStrings.IBSEmoteStrings.Facts());
            var fake = Emote.Parse(GlobalStrings.IBSEmoteStrings.Fake());
            var FuckYou = Emote.Parse(GlobalStrings.IBSEmoteStrings.FuckYou());
            //G
            var goth_heart = Emote.Parse(GlobalStrings.IBSEmoteStrings.GothHeart());
            //H
            var Hank = Emote.Parse(GlobalStrings.IBSEmoteStrings.Hank());
            //L
            var larsoneyes = Emote.Parse(GlobalStrings.IBSEmoteStrings.LarsonEyes());
            //M
            var martin = Emote.Parse(GlobalStrings.IBSEmoteStrings.Martin());
            var martin_heart = Emote.Parse(GlobalStrings.IBSEmoteStrings.MartinHeart());
            var monster = Emote.Parse(GlobalStrings.IBSEmoteStrings.Monster());
            //N
            var no = Emote.Parse(GlobalStrings.IBSEmoteStrings.No());
            //O
            var omegaroll = Emote.Parse(GlobalStrings.IBSEmoteStrings.OmegaRoll());
            //P
            var partyglasses = Emote.Parse(GlobalStrings.IBSEmoteStrings.PartyGlasses());
            //T
            var tom = Emote.Parse(GlobalStrings.IBSEmoteStrings.Tom());
            var Tux = Emote.Parse(GlobalStrings.IBSEmoteStrings.Tux());
            //Y
            var yes = Emote.Parse(GlobalStrings.IBSEmoteStrings.Yes());
            //Z
            var ZuluFlag = Emote.Parse(GlobalStrings.IBSEmoteStrings.ZuluFlag());
            #endregion IBS Emotes

            #region My Servers
            //Pumphouse Server
            var evilZorra = Emote.Parse(GlobalStrings.PumphouseEmoteStrings.EvilZorra());
            var SakamotoDab = Emote.Parse(GlobalStrings.PumphouseEmoteStrings.SakamotoDab());
            var Solaire = Emote.Parse(GlobalStrings.PumphouseEmoteStrings.Solaire());
            //Emote Server
            var doubt = Emote.Parse(GlobalStrings.EmoteServerStrings.Doubt());
            var shadowHaunter = Emote.Parse(GlobalStrings.EmoteServerStrings.ShadowHaunter());

            //Future emotes
            var e_sus = Emote.Parse(GlobalStrings.FutureEmoteStrings.ESus());
            var finger_guns = Emote.Parse(GlobalStrings.FutureEmoteStrings.FingerGuns());
            #endregion My Servers

            //Random shit
            string username = message.Author.Username;
            var userID = message.Author.Id;
            var userMention = $"<@{userID}>";

            #endregion Emotes

            #endregion Shortcuts

            /// <summary>
            /// Tips and Tricks
            /// 
            /// lowmess tips
            /// lowmess.Contains means "if lowercase message contains [input] anywhere in message"
            /// lowmess.Equals is for when you want Bob to do [thing} only if lowmess is *exactly* [input] and nothing more or less
            /// lowmess.StartsWith and lowmess.EndsWith are exactly what you think
            /// 
            /// Bot Response tips
            /// replying to messages: message.ReplyAsync("[text]"); 
            /// reacting to messages: message.AddReactionAsync([emote]);
            /// </summary>

            //this is for if Nadeko doesn't have all the commands
            OnGetMessage(message);
            Console.WriteLine($"message: '{message}'");
            Console.WriteLine($"lowmess: '{lowmess}'");

            //Command prefix for Bob. Bob's version of '.' for Nadeko
            if (message.HasStringPrefix("+", ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess)
                    Console.WriteLine(result.ErrorReason);
            }

            else if (PoliticsChat)
            {
                return;
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
            else if (lowmess.Equals("insult"))
            {

                //Insult choices
                String[] respondOptions = { "irish curse", "shakespeare", "regular insults"};
                var insult = "I insult you";

                //Bob decides how to respond
                Random random = new Random();
                int respondChoice = random.Next(0, respondOptions.Length);

                //Bob's responses

                //Irish Curse
                if (respondChoice == 0)
                {
                    int value = random.Next(0, IrishCurse.Length);
                    insult = $"{IrishCurse[value]}";
                }

                //Shakespeare
                else if (respondChoice == 1)
                {
                    int swear1 = random.Next(0, shakespeare1.Length);
                    int swear2 = random.Next(0, shakespeare2.Length);
                    int swear3 = random.Next(0, shakespeare3.Length);

                    insult = $"{shakespeare1[swear1]} {shakespeare2[swear2]} {shakespeare3[swear3]}";
                }

                //Regular insults
                else if (respondChoice == 2)
                {
                    int value = random.Next(0, regularInsults.Length);

                    insult = $"{regularInsults[value]}";
                }

                await message.Channel.SendMessageAsync(insult);
            }

            //Morning
            else if (lowmess.Contains("morning") || lowmess.Contains("mornin"))
            {
                //Response choices
                String[] respondOptions = { "grumpy morning", "good morning" };

                //Bob chooses the response from each set to choose from
                Random random = new Random();
                int respondChoice = random.Next(0, respondOptions.Length);
                int morningChoice = random.Next(0, morning.Length);
                int goodMorningChoice = random.Next(0, goodMorning.Length);
                string msg;

                //trimming excess characters
                var also = "also ".ToCharArray();
                var symbols = "!".ToCharArray();
                var trim = lowmess.TrimStart(also);
                var filterMessage = trim.TrimEnd(symbols);
                Console.WriteLine($"filtered message: '{filterMessage}'");

                //Grumpy
                if (filterMessage.Equals("morning") || filterMessage.Equals("mornin"))
                {
                    if (respondChoice == 0)
                    {
                        msg = $"{morning[morningChoice]}";
                        await message.Channel.SendMessageAsync(msg);
                    }

                    else if (respondChoice == 1)
                    {
                        msg = $"{goodMorning[goodMorningChoice]}";
                        await message.Channel.SendMessageAsync(msg);
                    }
                }

                //Positive
                else if (filterMessage.Equals("good morning") || filterMessage.Equals("good mornin"))
                {
                    msg = $"{goodMorning[goodMorningChoice]}";
                    await message.Channel.SendMessageAsync(msg);
                }
            }

            //You're wrong
            else if (lowmess.Equals("you're wrong"))
            {
                await message.Channel.SendMessageAsync("https://www.youtube.com/watch?v=GM-e46xdcUo&ab_channel=wintermoot");
            }

            //Your Opinion
            else if (lowmess.Equals("that's your opinion"))
            {
                await message.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/894991535542788137/900786985747243038/download_1.png");
            }

            //Shame Corner
            else if (lowmess.Contains("shame corner"))
            {
                var shame = "https://tenor.com/view/taylor-bartley-sad-corner-hungover-dunce-gif-14751671";
                await message.Channel.SendMessageAsync($"{shame}");
            }

            //Going Dark
            //else if (lowmess.Equals("going dark") || lowmess.Equals("bob is going offline"))
            //{
            //    await message.Channel.SendMessageAsync("https://tenor.com/view/bravo-six-going-dark-cod-sergeant-mw-modern-warfare-gif-14985183");
            //}

            //Willy P and Willie 
            else if (lowmess.Contains("willy p") || lowmess.Contains("willie"))
            {
                //tests for URL
                try
                {
                    WebRequest url = WebRequest.Create(lowmess);
                    WebResponse request = url.GetResponse();

                    if (request.SupportsHeaders)
                    {
                        return;
                    }
                }
                //tests for file
                catch (FormatException)
                {
                    try
                    {
                        FileInfo file = new FileInfo(lowmess);
                        bool exists = file.Exists;
                        if (exists)
                        {
                            return;
                        }
                    }
                    catch (FormatException)
                    {
                        return;
                    }
                }

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
                await message.AddReactionAsync(thumbsupEmoji);
                await message.Channel.SendMessageAsync("gottem");
            }

            //Rob's Desktop
            else if (lowmess.Equals("rob's desktop") || lowmess.Equals("robs desktop"))
            {
                var desktop = "https://media.discordapp.net/attachments/920025341341351947/943607875325022238/unknown.png";
                await message.Channel.SendMessageAsync(desktop);
            }

            //Will's spank bank
            //transfer to DB
            //needs new links for all
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
                int value = random.Next(0, IrishCurse.Length);
                await message.Channel.SendMessageAsync(IrishCurse[value]);
            }

            //Quickbooks
            else if (lowmess.Contains("quickbooks"))
            {
                String[] quickbooks = 
                { 
                    "https://media.giphy.com/media/QvF8DglKNi3GwG5WIN/giphy-downsized-large.gif", 
                    "https://media.giphy.com/media/hTovQQU3dBiE6mmNkJ/giphy.gif"
                };

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

            //Sugar free gummy bears
            else if (lowmess.Equals("sugar free gummy bears"))
            {
                Random random = new Random();
                var value = random.Next(0, sugarfreeGummies.Length);
                await message.Channel.SendMessageAsync(sugarfreeGummies[value]);
            }

            //Waltersobchakeit
            //transfer to DB
            else if (lowmess.Contains("waltersobchakeit"))
            {
                await message.Channel.SendMessageAsync("https://media.discordapp.net/attachments/920025510883524679/948315645781626970/IMG_3714-1.jpg");
            }

            //Will's reactions
            else if (lowmess.Contains("will") && !lowmess.Contains("blame") && !lowmess.Contains("joe point"))
            {
                String[] willReactions =
                {
                //Silence, index: #t
                "https://media.giphy.com/media/ZXIaNe5qervdfZuBvM/giphy.gif",
                //Sandler, index: #3j
                "https://tenor.com/view/uncut-gems-cum-gif-18874799", 
                };

                if (lowmess.Equals("will"))
                {
                    Random random = new Random();
                    var msg = random.Next(0, willReactions.Length);
                    await message.Channel.SendMessageAsync(willReactions[msg]);
                }

                else if (lowmess.Equals("silence will") || lowmess.Equals("will silence"))
                {
                    var msg = "https://media.giphy.com/media/ZXIaNe5qervdfZuBvM/giphy.gif";
                    await message.Channel.SendMessageAsync(msg);
                }

                else if (lowmess.Equals("will cum") || lowmess.Equals("cum will"))
                {
                    var msg = "https://tenor.com/view/uncut-gems-cum-gif-18874799";
                    await message.Channel.SendMessageAsync(msg);
                }
            }

            //Reaction Memes
            //transfer to DB
            //add to Beta bob's commands cs file
            else if (lowmess.Contains("gif") || lowmess.Contains("meme"))
            {
                //Transfer to DB
                if (lowmess.Equals("absolutely not gif"))
                {
                    String[] msg =
                    {
                        //Wolf of Wall Street
                        "https://cdn.discordapp.com/attachments/895367300390211634/905140828530434048/IMG_3508.gif",
                        //Ryan Renolds
                        "https://tenor.com/view/absolutely-not-nope-no-no-way-no-chance-gif-17243246",
                    };

                    Random random = new Random();
                    int value = random.Next(0, msg.Length);

                    await message.Channel.SendMessageAsync(msg[value]);
                }

                else if (lowmess.Equals("are you sure gif"))
                {
                    await message.Channel.SendMessageAsync("https://tenor.com/view/dumb-and-dumber-are-you-sure-gif-8838081");
                }

                else if (lowmess.Equals("boi gif"))
                {
                    await message.Channel.SendMessageAsync("https://tenor.com/view/kratos-boy-kratos-boy-boi-god-of-war-gif-12278930");
                }

                else if (lowmess.Equals("jon snow gif") || lowmess.Equals("I know nothing gif"))
                {
                    await message.Channel.SendMessageAsync("https://tenor.com/view/got-game-of-thrones-you-know-nothing-jon-snow-ygritte-gif-14613130");
                }

                else if (lowmess.Equals("not yet gif"))
                {
                    await message.Channel.SendMessageAsync("https://tenor.com/view/not-yet-mace-windu-star-wars-gif-9797353");
                }

                //transfer to DB
                else if (lowmess.Equals("you're not wrong, you're just an asshole meme"))
                {
                    await message.Channel.SendMessageAsync("https://media.discordapp.net/attachments/920025510883524679/948315645781626970/IMG_3714-1.jpg");
                }

                //transfer to DB
                else if (lowmess.Equals("endlessly trapped gif"))
                {
                    await message.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/902629594564296725/957430021985820702/viddit_6636a42d.gif");
                }

                //Brooklyn 99 gif
                else if (lowmess.Equals("why are you telling me gif"))
                {
                    await message.Channel.SendMessageAsync("https://cdn.discordapp.com/attachments/902629594564296725/948208141437395044/687d1b74-db91-4244-87e1-44cbd75390d5.gif");
                }
            }

            //For when Joe pings the degens in proactive
            else if ((ProactiveChat) && lowmess.Contains(DegenRole))
            {
                var text = $"{DegenRole} doesn't have access to this chat {userMention}";
                await message.Channel.SendMessageAsync($"{text}");
            }

            //Responses from Bob
            else if (lowmess.EndsWith("bob") && !lowmess.Contains("blame") && !lowmess.Contains("fault"))
            {
                string[] commands = CommandsToAdd;

                //Bob sass part 1
                if (lowmess.Equals("fuck you bob"))
                {
                    var text = $"well fuck you too {userMention}";
                    await message.Channel.SendMessageAsync(text);
                    await message.Channel.SendMessageAsync($"{FuckYou}");
                }

                //Hello Bob
                else if (lowmess.Equals("hello bob"))
                {
                    var text = $"hello there {username}";
                    await message.Channel.SendMessageAsync($"{text}");
                }

                //Hey Bob
                else if (lowmess.Equals("hey bob"))
                {
                    //Strings
                    String[] respondOptions = { "polite", "rude", };

                    String[] polite = 
                    { 
                        "hello there", 
                        "yes?", 
                        "how can I help you?", 
                    };

                    String[] rude = 
                    {
                        "the fuck do you want?", 
                        $"{FuckYou}", 
                    };
                    var bobResponse = "hello";

                    //Bob decides how to respond
                    Random random = new Random();
                    int respondChoice = random.Next(0, respondOptions.Length);
                    int politeValue = random.Next(0, polite.Length);
                    int rudeValue = random.Next(0, rude.Length);

                    // Bob's responses
                    // Polite response
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
                    foreach (var reaction in nadekoCommands)
                    {
                        foreach (var answer in reaction.lcr)
                        {
                            var msg = "Vanilla Bobs custom reactions:";

                            //LB code
                            for (var i = 0; i < Math.Min(AlphaBobCommands.Length, nadekoCommands.Count); i++)
                            {
                                var lcr = new List<String>();
                                nadekoCommands = nadekoCommands.OrderByDescending(p => p.responses).ToList();
                                //"\n" means a new line. This line will look like e.g. "1) Daniel"
                                msg += $"\n{i + 1}) {nadekoCommands[i].lcr[0]}";
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

            //Responses to Rob's bot
            else if (TheNOC)
            {
                if (lowmess.Contains("2015 wants its joke back"))
                {
                    await message.ReplyAsync("Said the bot using a joke from 2005");
                }
            }

            //Lunch reminder
            else if ((lowmess.Equals("going on lunch") || lowmess.Equals("taking lunch")) && Custodian)
            {
                await message.AddReactionAsync(thumbsupEmoji);
                LunchReminder(message);
            }

            else if (lowmess.Equals("troubleshooting wheel"))
            {
                Random random = new Random();
                int value = random.Next(0, troubleshootingWheel.Length);
                var tip = ($"{troubleshootingWheel[value]}");

                await message.Channel.SendMessageAsync(tip);                
            }

            #region Custom Points

            ///<summary>
            ///below starts JPS, PPs, Blame Count, and it's side functions
            ///the test code is below that
            ///</summary>

            //Leaderboard
            else if (lowmess.EndsWith("leaderboard"))
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
                                var msg = "Would you like to see the Joe Points Leaderboard (command: `Joe Points leaderboard`) or the Blame Count Leaderboard (command: `Blame Count Leaderboard`). " +
                                    "The commands are not case sensitive.";
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
            }
            //End of Leaderboard

            else if (lowmess.Contains("proactive point") && Proactive)
            {
                var foundProactive = false;
                foreach (var ainur in proactive)
                {
                    foreach (var maia in ainur.maiar)
                    {
                        //Awarding Proactive Points
                        if (lowmess.IndexOf($"{maia} gets ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"{maia} has been awarded ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"to {maia}", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            long numVal;
                            string MyString = message.Content;
                            Console.WriteLine($"Proactive Points assigned: {Today} \nInput string: '{MyString}'");

                            //String
                            string proactivePoints = $"gets has been awarded proactive points P {maia} {maia.ToLower()}";

                            //Convert string to char
                            char[] proactiveTrim = proactivePoints.ToCharArray();

                            //Trim OG string to return an int
                            string firstTrim = MyString.TrimStart(proactiveTrim);
                            string finalTrim = firstTrim.TrimEnd(proactiveTrim);

                            //Console lines for testing
                            Console.WriteLine("trimmedchar: '{0}'", proactivePoints);
                            Console.WriteLine("First trim: {0}", firstTrim);
                            Console.WriteLine("Final trim: {0}", finalTrim);

                            //Start awarding Try
                            try
                            {
                                numVal = Convert.ToInt64(finalTrim);
                                if (numVal < Int64.MaxValue)
                                {
                                    //adding Proactive Points
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
                                        ainur.proactivePoints = Int64.MaxValue;
                                    }
                                    Console.WriteLine("numval is {0}", numVal);
                                    Console.WriteLine("Total Proactive points is {0}", ainur.proactivePoints);

                                    var text = $"{maia} has been awarded {numVal} Proactive Points. " +
                                        $"Good job! " +
                                        $"{maia} has earned a total of {ainur.proactivePoints} Proactive Points. " +
                                        $"You should feel proud of earning these fake internet points. " +
                                        $"Even tho nobody else is using them. " +
                                        $"But hey, someone is appreciating your work, so that's nice.";

                                    if (numVal == 1)
                                    {
                                        text = $"{maia} has been awarded 1 (one) Proactive Point. " +
                                            $"Good job? " +
                                            $"{maia} has earned a total of {ainur.proactivePoints} Proactive Points. " +
                                            $"You should feel proud of earning this singular fake internet point. " +
                                            $"Even tho nobody else is using them. " +
                                            $"But hey, someone is kind of appreciating your work, so that's sort of nice, I suppose.";
                                    }

                                    await message.Channel.SendMessageAsync($"{text}");
                                    SaveProactive();
                                }
                                else
                                {
                                    Console.WriteLine("Proactive Points cannot be incremented beyond its current value");
                                    await message.Channel.SendMessageAsync($"{maia} can't have more than {Int64.MaxValue} Proactive Points. They currently have {ainur.proactivePoints} Proactive Points");
                                }
                            }
                            //End of "try" for awarding PPs
                            catch (FormatException)
                            {
                                Console.WriteLine("Input string '{0}' is not a sequence of digits", finalTrim);
                                await message.Channel.SendMessageAsync($"Input string '{finalTrim}' is not a sequence of digits");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("The number cannot fit in an Int32");
                                await message.Channel.SendMessageAsync("You can't assign more than 9,223,372,036,854,775,808 Proactive Points at a time");
                            }
                            //End awarding Try

                            Console.WriteLine("End of awarding Proactive Points \n");
                            foundProactive = true;
                            break;

                        }
                        //End of awarding Proactive Points

                        //Taking away Proactive Points
                        else if (lowmess.IndexOf($"{maia} loses ", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            //Strings
                            long numVal;
                            string MyString = message.Content;
                            Console.WriteLine($"Proactive Points lost: {Today} \nInput string: '{MyString}'");

                            //Trim strings
                            string proactivePoints = $"loses proactive points P {maia} {maia.ToLower()}";

                            //Trim process
                            char[] proactiveTrim = proactivePoints.ToCharArray();
                            string firstTrim = MyString.TrimStart(proactiveTrim);
                            string finalString = firstTrim.TrimEnd(proactiveTrim);

                            //Console lines for errors
                            Console.WriteLine("trimmedchar: '{0}'", proactivePoints);
                            Console.WriteLine($"First trim: {firstTrim}");
                            Console.WriteLine($"Final trim: {finalString}");

                            //Start losing Try
                            try
                            {
                                numVal = Convert.ToInt64(finalString);
                                if (numVal > Int64.MinValue)
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
                                        ainur.proactivePoints = Int64.MinValue;

                                    }
                                    SaveProactive();

                                    Console.WriteLine("numval is {0}", numVal);
                                    Console.WriteLine("Total Proactive Points is {0}", ainur.proactivePoints);

                                    //Message for losing Proactive Points
                                    var text = $"{maia} has lost {numVal} Proactive points. " +
                                        $"I'd make a big deal out of you losing Proactive Points, but let's face it. " +
                                        $"Who's really keeping track? " +
                                        $"Well, besides me. " +
                                        $"{maia} now has {ainur.proactivePoints} Proactive Points";

                                    //Message for if Proactive Points is less than zero but greater than MinValue
                                    if ((ainur.proactivePoints < 0) && (ainur.proactivePoints > Int64.MinValue))
                                    {
                                        if (lowmess.Contains("noc") || lowmess.Contains("bob"))
                                        {
                                            text = $"Congratulations, {maia}. " +
                                                $"You just lost {numVal} Proactive Points, which brings your total down to {ainur.proactivePoints} Proactive Points. " +
                                                $"Good job going negative. " +
                                                $"Just like your personality. " +
                                                $"You should probably work on that";
                                        }

                                        else
                                        {
                                            text = $"That's a big oof, {maia}. " +
                                                $"You not only lost {numVal} Proactive Points, but you now have gone negative with {ainur.proactivePoints}. " +
                                                $"I hope everything is ok with you. " +
                                                $"I'm sure you'll be back on top soon enough";
                                        }
                                    }

                                    //Message if Proactive points equals int.MinValue
                                    else if (ainur.proactivePoints == Int64.MinValue)
                                    {
                                        text = $"Wait, what's going on? " +
                                            $"{maia} now has {ainur.proactivePoints} PPs? " +
                                            $"That is literally the lowest possible amount of PPs you can have. " +
                                            $"You doin ok, bruv?";
                                    }

                                    //Sends one of the above messages
                                    await message.Channel.SendMessageAsync($"{text}");
                                }
                                else
                                {
                                    Console.WriteLine("Proactive Points cannot be incremented beyond its current value");
                                    await message.Channel.SendMessageAsync($"Proactive Points cannot be less than 9,223,372,036,854,775,808. {maia} currently has {ainur.proactivePoints} Proactive Points");
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
                                await message.Channel.SendMessageAsync($"You can't take away more than 9,223,372,036,854,775,807 Proactive Points at a time");
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
                        //Also manually setting PPs
                        else if (lowmess.IndexOf($"{maia}'s proactive points", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            //setting proactive points to a specific amount
                            if (Mod && lowmess.IndexOf($"set {maia}'s proactive points to", StringComparison.OrdinalIgnoreCase) >= 0)
                            {
                                //Strings
                                long numVal;
                                string MyString = message.Content;
                                Console.WriteLine($"PP manually set on: {Today} \nInput string: {MyString}");

                                //Trim Statements
                                string proactivePoints = $"set proactive points P to {maia}'s {maia.ToLower()}";

                                //Convert string to var
                                char[] proactiveTrim = proactivePoints.ToCharArray();

                                //Trim Process
                                string firstTrim = MyString.TrimStart(proactiveTrim);
                                string finalString = firstTrim.TrimEnd(proactiveTrim);

                                //Console lines for errors
                                Console.WriteLine($"First trim: {firstTrim}");
                                Console.WriteLine($"Final trim: {finalString}");

                                //start specific PP try
                                try
                                {
                                    numVal = Convert.ToInt64(finalString);
                                    if ((numVal > Int64.MinValue) && (numVal < Int64.MaxValue))
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
                                        var msg = $"Proactive Points cannot be more than 9,223,372,036,854,775,808 or less than -9,223,372,036,854,775,808. " +
                                            $"{maia} currently has {ainur.proactivePoints} Proactive Points";
                                        await message.Channel.SendMessageAsync(msg);
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
                                    await message.Channel.SendMessageAsync("You can't assign more than 9,223,372,036,854,775,808 or less than -9,223,372,036,854,775,808 Proactive Points at a time");
                                }//End specific PP try

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

                //Mass distribution of PP
                if (lowmess.IndexOf($"proactive gets ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                    lowmess.IndexOf($"proactive has been awarded ", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    long numVal;
                    string MyString = message.Content;
                    Console.WriteLine($"Proactive Points assigned: {Today} \nInput string: '{MyString}'");

                    //String
                    string proactivePoints = $"gets has been awarded proactive points P";

                    //Convert string to var
                    char[] proactiveTrim = proactivePoints.ToCharArray();

                    //Trim OG string to return an int
                    string firstTrim = MyString.TrimStart(proactiveTrim);
                    string finalTrim = firstTrim.TrimEnd(proactiveTrim);

                    //Console lines for testing
                    Console.WriteLine("trimmedchar: '{0}'", proactivePoints);
                    Console.WriteLine("First trim: {0}", firstTrim);
                    Console.WriteLine("Final trim: {0}", finalTrim);

                    numVal = Convert.ToInt32(finalTrim);
                    Console.WriteLine("numval is {0}", numVal);

                    var text = $"Congratulations, Proactive! {username} decided that every one of you deserves {numVal} PPs! I'm not sure what y'all did, but you should feel very proud.";

                    foreach (var ainur in proactive)
                    {
                        foreach (var maia in ainur.maiar)
                        {
                            //Start awarding Try
                            try
                            {

                                if (numVal < Int64.MaxValue)
                                {
                                    try
                                    {
                                        ainur.proactivePoints = checked(ainur.proactivePoints + numVal);
                                    }
                                    catch (OverflowException)
                                    {
                                        ainur.proactivePoints = Int64.MaxValue;
                                    }
                                    Console.WriteLine($"Total Proactive points for {maia} is {ainur.proactivePoints}");

                                    if (numVal == 1)
                                    {
                                        text = $"Proactive has been awarded 1 (one) Proactive Point. Good job? You should feel proud of earning this singular fake internet point. " +
                                            $"Even tho nobody else is using them. But hey, someone is kind of appreciating your work, so that's sort of nice, I suppose.";
                                    }


                                    SaveProactive();
                                }//End of if for PPs
                                else
                                {
                                    Console.WriteLine("Proactive Points cannot be incremented beyond its current value");
                                    await message.Channel.SendMessageAsync($"{maia} can't have more than {Int64.MaxValue} Proactive Points. They currently have {ainur.proactivePoints} Proactive Points");
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Input string '{0}' is not a sequence of digits", finalTrim);
                                await message.Channel.SendMessageAsync($"Input string '{finalTrim}' is not a sequence of digits");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("The number cannot fit in an Int32");
                                await message.Channel.SendMessageAsync($"You can't assign more than {Int64.MaxValue} Proactive Points at a time");
                            }//End awarding Try
                        }

                    }
                    await message.Channel.SendMessageAsync($"{text}");
                    Console.WriteLine("End of mass PP distribution \n");
                }//End PP distribution

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
                            string toTrim = $"has been awarded gets joe points JP to {name} {name.ToLower()}";

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
                        }
                        //End of awarding Joe Points

                        //Subtracting Joe Points
                        else if (Mod && (lowmess.IndexOf($"{name} loses", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"from {name}", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            int numVal;
                            string MyString = message.Content;
                            Console.WriteLine($"Joe Points taken away {Today} \nInput string is: '{MyString}'");

                            //strings
                            string toTrim = $"loses from joe points JP {name} {name.ToLower()}";

                            //convert string to char[]
                            char[] trimChar = toTrim.ToCharArray();

                            //Trimming og string
                            string beginTrim = MyString.TrimStart(trimChar);
                            string endTrim = beginTrim.TrimEnd(trimChar);

                            //Console lines
                            Console.WriteLine("toTrim: '{0}'", toTrim);
                            Console.WriteLine("beginTrim: '{0}'", beginTrim);
                            Console.WriteLine("endTrim: '{0}'", endTrim);

                            //Start losing JP try
                            try
                            {
                                numVal = Convert.ToInt32(endTrim);
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
                                Console.WriteLine("Input string '{0}' is not a sequence of digits", endTrim);
                                await message.Channel.SendMessageAsync($"Input string '{endTrim}' is not a sequence of digits");
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("The number cannot fit in an Int32");
                                await message.Channel.SendMessageAsync("You can't take away more than 2,147,483,647 at a time");
                            }//end losing JP try

                            Console.WriteLine("End of taking away Joe Points \n");
                            foundPoints = true;
                            break;
                        }
                        //End of lose JP

                        //Clear Joe Points
                        else if (Mod && (lowmess.IndexOf($"clear {name}'s joe points", StringComparison.OrdinalIgnoreCase) >= 0))
                        {
                            person.joePoints = 0;
                            var text = $"{name}'s Joe Points have been reset. Press F to pay respects. {name}'s Joe Points have been reset to {person.joePoints}";
                            await message.Channel.SendMessageAsync(text);
                            SavePeople();
                            foundPoints = true;
                            break;
                        }
                        //End of clearing Joe Points

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
                                string joePoints = $"set joe points JP to {name}'s {name.ToLower()}";

                                //Trim process
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
                        }
                        //End of JP Count

                        //Degen failsafe
                        else if (NonMod && (lowmess.IndexOf($"{name} gets", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"{name} has been awarded", StringComparison.OrdinalIgnoreCase) >= 0 ||
                            lowmess.IndexOf($"to {name}", StringComparison.OrdinalIgnoreCase) >= 0))
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
                        }
                        //End of degen failsafe
                    }
                    //End of 2nd "foreach"
                    if (foundPoints)
                        break;
                }
                //End of 1st "foreach"

                //Mass JP distribution

            }
            //End of Joe Points

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
                    // end ainur foreach
                    // End of PP Count 

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
                /// end of person foreach
                /// End of Joe Points and Blame count
                
            }
            //End of Points Count

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
                            //Sass
                            Random brat = new Random();
                            int sass = brat.Next(0, 50);
                            var sassVal = brat.Next(0, bobSass.Length);

                            Console.WriteLine($"Blame used: {Today} \nname: {name} \nblame success: {blameSuccess} \nfault success: {faultSuccess} \nSass chance: {sass}\n");

                            var text = $"It's all {name}'s fault! {name} has been blamed {person.blameCount} times";
                            var msg = "if you say so";

                            //Bob's sass
                            if (sass == 50)
                            {
                                //If Bob tries to sass me
                                if (Custodian)
                                {
                                    person.blameCount++;
                                    msg = $"{finger_guns}";
                                    await message.Channel.SendMessageAsync($"{msg}");
                                    await message.Channel.SendMessageAsync($"{text}");
                                    SavePeople();
                                }
                                
                                //Sass when anyone else is blamed
                                else
                                {
                                    text = $"{sassVal}";
                                }
                            }

                            #region Will's script
                            //for Will and his script
                            /*
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
                            */
                            #endregion Will's script

                            //Normal blame
                            else
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
                        } 
                        //End blaming someone

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

                        } 
                        //End clearing blame
                    } 
                    //end of 2nd foreach
                    if (foundMatch)
                        break;

                } 
                //end of 1st foreach
            } 
            //End Blame

            #endregion Custom Points

            //Blank Space

            #region Test Code

            ///Test Code
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

                async void TestSwitch(string testing)
                {
                    switch (testing)
                    {
                        //emote testing
                        case "emote test":
                            testing = $"filler";
                            await message.Channel.SendMessageAsync($"{testing}");
                            await message.AddReactionAsync(facepalm);
                            return;

                        //reply test
                        case "reply test":
                            await message.ReplyAsync("test successful");
                            break;

                        //Experimental code? idk
                        case "experiment test":
                            await message.Channel.SendMessageAsync($"hello");
                            break;

                        //channel ID etc? idk
                        case "channel test":
                            await message.Channel.SendMessageAsync("channel test");
                            break;

                        //shortcut testing? idk
                        case "shortcut test":
                            var shortcut = "shortcut response";
                            await message.Channel.SendMessageAsync($"{shortcut}");
                            break;
                    };
                }

                async void RNGSwitch(int rng)
                {
                    switch (rng)
                    {
                        case 0:
                            await message.Channel.SendMessageAsync("case 0");
                            break; 

                        case 1:
                            await message.Channel.SendMessageAsync("case 1");
                            break;

                        case 2:
                            await message.Channel.SendMessageAsync("case 2");
                            break;
                    }
                }

                //Various tests 
                if (lowmess.Contains("test"))
                {
                    TestSwitch(lowmess);

                    //random shit
                    if (lowmess.Contains(PumphouseAdminRole))
                    {
                        var text = $"congratulations {userMention}, your code works. See {PumphouseAdminRole}?";
                        await message.Channel.SendMessageAsync($"{text}");
                    }

                    else if (lowmess.Equals("switch test"))
                    {

                        Random random = new Random();
                        int value = random.Next(0, 3);

                        Console.WriteLine($"{value}");

                        RNGSwitch(value);
                    }

                    else if (lowmess.Equals("create fuck shit test"))
                    {
                        commands.Add(new Response()
                            .SetPrompts("fuck shit")
                            .SetResponses());
                        SaveCustomReactions();
                    }

                    else if (lowmess.Equals("response test"))
                    {
                        var deviceName = System.Net.Dns.GetHostName();
                        await message.Channel.SendMessageAsync("message sent from " + deviceName);
                    }
                }
                //end of if("test")

                else if (lowmess.Equals("update custom commands"))
                {
                    UpdateCustomReactions();

                    await message.Channel.SendMessageAsync($"Custom Reactions was last modified {File.GetLastWriteTime(customReactionsDataPath)}. Current time is {DateTime.Now}");
                }

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

                //Timer testing
                else if (lowmess.Equals("timer template"))
                {
                    int timerCycle = 0;
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
                else if (lowmess.Equals("blame timer test"))
                {
                    int timerCycle = 0;
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

                //interval test
                else if (lowmess.Equals("interval test"))
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
            }

            #endregion Test code

        }
        //end of else if statements
    }
    //end of class Program
}
//end of namespace Bob Biggby
