using Discord.Commands;
using System;
using System.Threading.Tasks;

namespace CustomReactions
{
    //Last updated 9/8/22
    //"+" commands
    //if there is no comment, assume it's either a non discord link or in Pumphouse DB
    public class Commands : ModuleBase<SocketCommandContext>
    {
        //Alpha Bob
        #region Alpha Bob commands

        readonly String[] CommandsToAddToAB =
        {
            ":(", ":frowning:",
        };

        readonly String[] NeedsNewLink =
        {
            "comms", "comms",
            "dann",
            "email the user",
            "it's friday losers",
            "yes, my liege",
        };

        [Command("*eyeroll*")]
        public async Task Eyeroll()
        {
            await ReplyAsync("https://tenor.com/view/jessica-jones-krysten-ritter-eye-roll-ugh-so-done-gif-8657077");
        }

        [Command("a great day")]
        public async Task AGreatDay()
        {
            await ReplyAsync("https://youtu.be/WRu_-9MBpd4");
        }

        //Transfer to DB
        [Command("backup checklist")]
        public async Task BackupChecklist()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/989223734781018112/989228588958122004/unknown.png");
        }

        [Command("be gone vile man")]
        public async Task BeGoneVileMan()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/989223734781018112/1009194589707579514/be_gone_full.mp4");
        }

        [Command("becky")]
        public async Task Becky()
        {
            await ReplyAsync("https://tenor.com/view/artangels-grimes-knight-warrior-sword-gif-4985799");
        }

        [Command("big head")]
        public async Task BigHead()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/989223734781018112/992102167370530836/bigHead.jpg");
        }

        //transfer to DB
        [Command("big stupid jellyfish")]
        public async Task BigStupidJellyfish()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/979489423697788968/viddit_4e65990c.mp4");
        }

        //2 responses
        [Command("bitch")]
        public async Task Bitch()
        {
            String[] bitch =
            {
                //Suction Cup Korea gif, index: #37
                "https://tenor.com/view/youre-a-bitch-jopstoffels-suctioncupman-gif-11942465",
                //Suction Cup you're a bitch song, index: #38
                "https://www.youtube.com/watch?v=f9zpxWEweWc",
            };

            Random random = new Random();
            int value = random.Next(0, bitch.Length);
            var text = ($"{bitch[value]}");
            await ReplyAsync(text);
        }

        [Command("bones day")]
        public async Task BonesDay()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=tVOzsA7BaME&ab_channel=JoshuaRegier");
        }

        [Command("boss man")]
        public async Task BossMan()
        {
            await ReplyAsync("https://tenor.com/view/yay-arte-gif-19715102");
        }

        [Command("brittney")]
        public async Task Brittney()
        {
            await ReplyAsync("https://tenor.com/view/ricky-trailer-park-boys-my-brains-shor-circulating-gif-14045185");
        }

        //transfer to DB
        [Command("can it wait for a bit?")]
        public async Task CanItWaitForABit()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/902629594564296725/958078313568563400/downloadfile.gif");
        }

        //transfer to DB
        [Command("castle")]
        public async Task Castle()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/412068411451899925/930925559805005924/IMG_2947.gif");
        }

        //transfer to DB
        [Command("check the handbook")]
        public async Task CheckTheHandbook()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/920025341341351947/941416879505936414/unknown.png");
        }

        //transfer to DB
        [Command("chloe price")]
        public async Task ChloePrice()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/971457801845112842/image0.gif");
        }

        //same as email the user
        //needs new link        
        [Command("comms")]
        public async Task Comms()
        {
            await ReplyAsync("https://media.discordapp.net/attachments/920025341341351947/927671844541190165/unknown.png");
        }

        //transfer to DB
        //Different from daniel
        [Command("custodian")]
        public async Task Custodian()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/929641177131651092/viddit_e3a2f13e.mp4");
        }

        [Command("dab")]
        public async Task Dab()
        {
            await ReplyAsync("https://tenor.com/view/dab-slide-slippery-gif-14299663");
        }

        //transfer to DB
        [Command("dan")]
        public async Task Dan()
        {
            await ReplyAsync("https://media.discordapp.net/attachments/894991535542788137/966007090491555962/unknown.png");
        }
        //2 responses
        [Command("dan w")]
        public async Task DanW()
        {
            String[] msg =
            {
                //forest gump
                "https://tenor.com/view/forrest-gump-forrest-gump-wave-hello-gif-13288735", 
                //panda being a dick
                "https://tenor.com/view/panda-cart-shopping-grocery-push-gif-17715527"
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var danW = ($"{msg[value]}");
            await ReplyAsync(danW);
        }

        [Command("daniel")]
        public async Task Daniel()
        {
            await ReplyAsync("https://tenor.com/view/the-joker-heath-ledger-no-plan-gif-5874443");
        }

        //needs new link
        [Command("dann")]
        public async Task Dann()
        {
            await ReplyAsync("https://media.discordapp.net/attachments/948590685056040970/959083245872496671/unknown.png");
        }

        //transfer to DB
        [Command("darth maul")]
        public async Task DarthMaul()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/902629594564296725/946213179208392714/viddit_2aa4aa9c_1.mp4");
        }

        [Command("deal with it")]
        public async Task DealWithIt()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/989223734781018112/1017139934282391633/giphy_2.gif");
        }

        [Command("dennis")]
        public async Task Dennis()
        {
            await ReplyAsync("https://tenor.com/view/help-gif-7380459");
        }

        //transfer to DB
        //2 responses
        [Command("dew it")]
        public async Task DewIt()
        {
            String[] dewIt =
            {
                //Dew it, index f
                "https://cdn.discordapp.com/attachments/895367300390211634/920741002120167514/viddit_d1c084fe.mp4",
                //Dew it. index 4n
                "https://cdn.discordapp.com/attachments/895367300390211634/941708551120887838/tiktok_1644336462238.mp4",
            };

            Random random = new Random();
            int value = random.Next(0, dewIt.Length);
            var text = ($"{dewIt[value]}");

            await ReplyAsync(text);
        }

        //5 responses
        //transfer to DB
        [Command("do it")]
        public async Task DoIt()
        {
            String[] doIt =
            {
                //Dew it #1
                "https://cdn.discordapp.com/attachments/895367300390211634/920741002120167514/viddit_d1c084fe.mp4",
                //Dew it #2
                "https://cdn.discordapp.com/attachments/895367300390211634/941708551120887838/tiktok_1644336462238.mp4",
                //Sheev
                "https://tenor.com/view/do-it-star-wars-gif-4928619",
                //Shia, do it
                "https://tenor.com/view/do-it-shia-la-beouf-flame-gif-4445204",
                //Shia, what are you waiting for
                "https://tenor.com/view/do-it-what-are-you-waiting-for-determined-angry-gif-5247874",
            };

            Random random = new Random();
            int value = random.Next(0, doIt.Length);
            var text = ($"{doIt[value]}");

            await ReplyAsync(text);
        }

        [Command("eat a chode")]
        public async Task EatAChode()
        {
            await ReplyAsync("https://youtube.com/shorts/WZjENfDvNsE?feature=share");
        }

        [Command("eat a dick")]
        public async Task EatADick()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=zffma5Py92c&list=PLrvVfo9ufJZcj9YjUJx8AagyhBHFpZjgV&index=36");
        }

        //needs a new link
        //same as comms
        [Command("email the user")]
        public async Task Email()
        {
            await ReplyAsync("https://media.discordapp.net/attachments/920025341341351947/927671844541190165/unknown.png");
        }

        //transfer to DB
        [Command("escalate")]
        public async Task Escalate()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/894991535542788137/896063241095098448/9k.png");
        }

        //transfer to DB
        [Command("ess")]
        public async Task ESS()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/920025341341351947/943939768734089287/unknown.png");
        }

        //transfer to DB
        [Command("ew")]
        public async Task Ew()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/925134245238820914/the_oc_ew.gif");
        }

        [Command("excellent")]
        public async Task Excellent()
        {
            await ReplyAsync("https://tenor.com/view/excellent-bill-and-ted-happy-gif-14318181");
        }

        //transfer to DB
        [Command("extended it alignments")]
        public async Task ExtendedAlignments()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/930516339334987836/Extra_Alignment_color.png");
        }

        [Command("fc3 fuck you")]
        public async Task FC3FuckYou()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/989223734781018112/1009453766476562503/VideoEditor_20220730_081226.mp4");
        }

        [Command("fresh prince")]
        public async Task FreshPrince()
        {
            await ReplyAsync("fresh prince of bel air was just pretty okay and did not age well");
        }

        //transfer to DB
        //2 responses
        [Command("fuck")]
        public async Task Fuck()
        {
            String[] msg =
{
                //AoE2 Fuck Not Censored
                "https://media.discordapp.net/attachments/895367300390211634/931645134691516446/RDT_20220114_1524178313261399590404924.jpg",
                //Witcher
                "https://media.discordapp.net/attachments/895367300390211634/972388680033513563/443f76a3-466c-4063-80f3-926ee124bb06.gif",
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var fuck = ($"{msg[value]}");
            await ReplyAsync(fuck);
        }

        [Command("fuck off")]
        public async Task FuckOff()
        {
            await ReplyAsync("https://youtu.be/t3jKtjgRZQY");
        }

        //transfer to DB
        [Command("fuck that")]
        public async Task FuckThat()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/955910174835613807/viddit_83f62cfb.gif");
        }

        //3 responses
        [Command("fuck you")]
        public async Task FuckYou()
        {
            String[] msg =
            {
                //Suction Cup Man, fuck you song, index: #r
                "https://www.youtube.com/watch?v=jEXjhGJg1Jk",
                //Suction cup man every time he says fuck you, index: #6i
                "https://youtu.be/7V22OCLqovA",
                //Vaas fuck you; index 7n
                "https://cdn.discordapp.com/attachments/989223734781018112/1009453766476562503/VideoEditor_20220730_081226.mp4",
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var fuckYou = ($"{msg[value]}");

            await ReplyAsync(fuckYou);
        }

        [Command("general kenobi")]
        public async Task GeneralKenobi()
        {
            await ReplyAsync("https://tenor.com/view/hello-there-general-kenobi-star-wars-grevious-gif-17774326");
        }

        [Command("great day")]
        public async Task GreatDay()
        {
            await ReplyAsync("https://youtu.be/WRu_-9MBpd4");
        }

        [Command("haha good one")]
        public async Task GoodOne()
        {
            await ReplyAsync("https://tenor.com/view/jim-carrey-look-hint-allusion-eyes-gif-15443059");
        }

        [Command("have you checked your butthole")]
        public async Task HaveYouCheckedYourButthole()
        {
            await ReplyAsync("https://youtu.be/6IjuSycXjqM");
        }

        //transfer to db
        [Command("hehe")]
        public async Task Hehe()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/935237716403167232/IMG_5271.gif");
        }

        [Command("hello there")]
        public async Task HelloThere()
        {
            await ReplyAsync("https://tenor.com/view/hello-there-hi-there-greetings-gif-9442662");
        }

        [Command("help desk")]
        public async Task HelpDesk()
        {
            await ReplyAsync("https://tenor.com/view/scum-wretched-villany-tattooine-gif-10985312");
        }

        [Command("help desk main line")]
        public async Task HelpDeskMainLine()
        {
            await ReplyAsync("Help Desk Main Line: (517) 978-3025");
        }

        [Command("help desk mating ritual")]
        public async Task HelpDeskMatingRitual()
        {
            await ReplyAsync("https://www.reddit.com/r/StrangeAndFunny/comments/ntkg35/this_is_how_i_attract_mates/?utm_medium=android_app&utm_source=share");
        }

        [Command("help me")]
        public async Task HelpMe()
        {
            await ReplyAsync("https://tenor.com/view/new-girl-help-help-me-yelling-shouting-gif-3568504");
        }

        [Command("hey bob")]
        public async Task HeyBob()
        {
            await ReplyAsync("Yes, I am here");
        }

        //Transfer to DB
        [Command("hmm no")]
        public async Task HmmNo()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/925134529553911828/IckyBossyHarvestmen-size_restricted.gif");
        }

        [Command("how dare you")]
        public async Task HowDareYou()
        {
            await ReplyAsync("https://tenor.com/view/how-dare-you-greta-thunberg-gif-15130785");
        }

        [Command("https://tenor.com/view/balls-sucking-cherry-lick-his-nuts-gif-15332077")]
        public async Task StopIt()
        {
            //Michael Jordan "Stop it" 
            await ReplyAsync("https://tenor.com/view/stop-it-get-some-help-gif-15058124");
        }

        //transfer to DB
        [Command("I am untethered")]
        public async Task IAmUntethered()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/902629594564296725/946213305234620426/viddit_37bd7fb4_1.mp4");
        }

        //transfer to DB
        [Command("I am untethered and my rage knows no bounds")]
        public async Task IAmUntetheredAndMyRageKnowsNoBounds()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/902629594564296725/946213305234620426/viddit_37bd7fb4_1.mp4");
        }

        [Command("I can do this all day")]
        public async Task ICanDoThisAllDay()
        {
            await ReplyAsync("https://tenor.com/view/captain-america-i-can-do-this-all-day-avengers-endgame-marvel-gif-15551087");
        }

        [Command("I have spoken")]
        public async Task IHaveSpoken()
        {
            await ReplyAsync("https://tenor.com/view/kuiil-have-spoken-mandalorian-star-wars-gif-15566834");
        }

        //transfer to DB
        [Command("I know some of those words")]
        public async Task IKnowSomeOfThoseWords()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/907348953614413855/RDT_20210616_0037112639804550901458370.png");
        }

        [Command("I know where it is")]
        public async Task IKnowWhereItIs()
        {
            await ReplyAsync("https://youtu.be/6IjuSycXjqM");
        }

        //Transfer to DB
        [Command("I own you")]
        public async Task IOwnYou()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/925133029339459624/IMG_3430.gif");
        }

        [Command("I quit")]
        public async Task IQuit()
        {
            await ReplyAsync("https://tenor.com/view/get-out-of-here-throw-trash-garbage-gif-16402986");
        }

        //transfer to DB
        //2 responses
        [Command("I understand that reference")]
        public async Task IUnderstandThatReference()
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
            var CaptAmerica = ($"{msg[value]}");

            await ReplyAsync(CaptAmerica);
        }

        //transfer to DB
        //2 responses
        [Command("I understood that reference")]
        public async Task IUnderstoodThatReference()
        {
            String[] msg =
            {
                //Captain America gif, index: #4u
                "https://tenor.com/view/captain-america-i-understood-that-reference-look-back-gif-14556485",
                //Captain America jpeg, index: 5c
                "https://media.discordapp.net/attachments/895367300390211634/949012494561718282/IMG_4229.jpg",
            };

            Random random = new Random();
            int value = random.Next(0, msg.Length);
            var CaptAmerica = ($"{msg[value]}");

            await ReplyAsync(CaptAmerica);
        }

        //Transfer to DB
        [Command("I'll allow it")]
        public async Task IllAllowIt()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/925133422911975445/giphy-1.gif");
        }

        [Command("I'll just leave")]
        public async Task IllJustLeave()
        {
            await ReplyAsync("https://tenor.com/view/leaving-im-gone-going-gif-13660937");
        }

        [Command("I'm disappointed")]
        public async Task Disappointed()
        {
            await ReplyAsync("https://tenor.com/view/disappointment-disappointed-food-review-meme-gif-16003613");
        }

        [Command("I'm fine")]
        public async Task HadesFine()
        {
            await ReplyAsync("https://tenor.com/view/hades-its-cool-im-fine-relax-hercules-gif-16668568");
        }

        [Command("I'm totally working")]
        public async Task TotallyWorking()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=lNxjZ9XLzV0&ab_channel=JackStauber");
        }

        [Command("I'm watching you")]
        public async Task ImWatchingYou()
        {
            await ReplyAsync("https://tenor.com/view/mike-wazowski-watchingyou-gif-5352035");
        }

        //Transfer to DB
        [Command("it is decided")]
        public async Task Decided()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/925133251109064714/IMG_3198.gif");
        }

        //3 responses
        [Command("it is done")]
        public async Task ItIsDone()
        {
            //String order: Frodo, Kronk
            String[] itIsDone =
            {
                //Frodo, index: #k
                "https://tenor.com/view/finished-elijah-wood-lord-of-the-rings-lava-fire-gif-5894611",
                //Kronk, index: #m
                "https://tenor.com/view/victory-done-success-mission-accomplished-kronk-gif-4946910",
                //Borat, index: 5u
                "https://tenor.com/view/success-great-job-nice-great-success-great-gif-5586706",
            };

            Random random = new Random();

            int value = random.Next(0, itIsDone.Length);
            var text = ($"{itIsDone[value]}");

            await ReplyAsync(text);
        }

        [Command("it's friday")]
        public async Task ItsFriday()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=kfVsfOSbJY0");
        }

        //needs new link
        //Transfer to DB
        [Command("it's friday losers")]
        public async Task ItsFridayLosers()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/899754600352067624/901077939511230474/6vjNyozd9-NHn872.mp4");
        }

        //transfer to DB
        [Command("it's monday")]
        public async Task ItsMonday()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/902629594564296725/938487641895223406/RDT_20220131_2331024689813064455587372.jpg");
        }

        [Command("it's time to press buttons")]
        public async Task PressButtons()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=OYHwCuGn_x0");
        }

        [Command("jake")]
        public async Task Jake()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/989223734781018112/997213547547332690/jake1.jpg");
        }

        //transfer to DB
        [Command("jks")]
        public async Task JKS()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/955910177608073276/viddit_b996e3f8.gif");
        }

        [Command("joe")]
        public async Task Joe()
        {
            await ReplyAsync("https://tenor.com/view/hacker-typing-hacking-computer-codes-gif-17417874");
        }

        //transfer to DB
        [Command("justin k")]
        public async Task JustinK()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/894991535542788137/981981904603582504/unknown.png");
        }

        //Same as kikko
        [Command("kikki")]
        public async Task Kikki()
        {
            await ReplyAsync("https://tenor.com/view/kikis-delivery-service-ghibli-kiki-kiki-the-witch-anime-gif-16933631");
        }

        //same as kikki
        [Command("kikko")]
        public async Task Kikko()
        {
            await ReplyAsync("https://tenor.com/view/kikis-delivery-service-ghibli-kiki-kiki-the-witch-anime-gif-16933631");
        }

        [Command("know your place")]
        public async Task KnowYourPlace()
        {
            await ReplyAsync("https://tenor.com/view/trash-know-your-place-gif-12886026");
        }

        [Command("larson")]
        public async Task Larson()
        {
            await ReplyAsync("https://tenor.com/view/no-randy-jackson-dawg-gif-12730917");
        }

        [Command("loveall")]
        public async Task Loveall()
        {
            await ReplyAsync("https://tenor.com/view/campesino-farmer-looking-sneaking-gif-14335387");
        }

        //The DICK
        [Command("martin")]
        public async Task Martin()
        {
            await ReplyAsync("You mean the Director of Inclusion, Care, and Kindness? You can call him DICK for short");
        }

        //Fresh Prince gif
        [Command("marty")]
        public async Task Marty()
        {
            await ReplyAsync("https://media.giphy.com/media/UrK4buqejkhK2NTFw9/giphy.gif");
        }

        [Command("mild shock")]
        public async Task MildShock()
        {
            await ReplyAsync("https://tenor.com/view/patrick-stewart-mild-shock-shocked-shock-mild-gif-5292523");
        }

        [Command("noc")]
        public async Task NOC()
        {
            await ReplyAsync("https://tenor.com/view/nailed-it-three-pointer-basketball-whoosh-3pointer-gif-16331098");
        }

        [Command("on site")]
        public async Task OnSite1()
        {
            await ReplyAsync("https://tenor.com/view/nailed-it-three-pointer-basketball-whoosh-3pointer-gif-16331098");
        }

        [Command("onsite")]
        public async Task OnSite2()
        {
            await ReplyAsync("https://tenor.com/view/nailed-it-three-pointer-basketball-whoosh-3pointer-gif-16331098");
        }

        [Command("oops")]
        public async Task Oops()
        {
            await ReplyAsync("https://tenor.com/view/made-a-huge-tiny-mistake-im-listening-huge-mistake-gif-14364427");
        }

        [Command("oopsie")]
        public async Task Oopsie()
        {
            await ReplyAsync("https://tenor.com/view/dumb-stupid-stfu-peretti-b99-gif-5120485");
        }

        //transfer to DB
        [Command("panda rage")]
        public async Task PandaRage()
        {
            await ReplyAsync("https://media.discordapp.net/attachments/895346146313125898/908765386009370665/IMG_4908.gif");
        }

        [Command("pepcac")]
        public async Task Pebcac()
        {
            await ReplyAsync("problem exists between computer and chair");
        }

        [Command("praise the beheaded")]
        public async Task PraiseTheBeheaded()
        {
            await ReplyAsync("https://tenor.com/view/pray-the-sun-dead-cells-gif-19409747");
        }

        [Command("praise the sun")]
        public async Task Solaire()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=So5hTxKmPrA&list=PLrvVfo9ufJZcj9YjUJx8AagyhBHFpZjgV&index=31");
        }

        [Command("rob")]
        public async Task Rob()
        {
            await ReplyAsync("https://tenor.com/view/sad-gif-24073087");
        }

        [Command("self burn")]
        public async Task SelfBurn()
        {
            await ReplyAsync("https://tenor.com/view/self-burn-brooklyn-nine-rare-andy-samberg-detective-jake-peralta-gif-5606998");
        }

        [Command("shame")]
        public async Task Shame()
        {
            await ReplyAsync("https://tenor.com/view/shame-game-of-thrones-gif-11381550");
        }

        //transfer to DB
        [Command("shhh")]
        public async Task Shhh()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/955910175951294604/x4cHkTBUQHob3cZRWE_1.gif");
        }

        [Command("signal flags")]
        public async Task SignalFlags()
        {
            await ReplyAsync("https://en.wikipedia.org/wiki/International_maritime_signal_flags");
        }

        [Command("slap chris")]
        public async Task SlapChris()
        {
            await ReplyAsync("https://slapchris.com/");
        }

        [Command("stfu")]
        public async Task STFU()
        {
            await ReplyAsync("https://www.youtube.com/watch?v=OLpeX4RRo28");
        }

        [Command("suck it")]
        public async Task SuckIt()
        {
            await ReplyAsync("https://tenor.com/view/ruxin-the-league-suck-it-commissioner-gif-5003995");
        }

        [Command("thank you bob")]
        public async Task ThankYouBob()
        {
            await ReplyAsync("you're welcome");
        }

        //transfer to DB
        [Command("that's fucking it")]
        public async Task ThatsFuckingIt()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/902629594564296725/948207664125599814/61160522_2454260577925971_913587187931414528_n.jpg");
        }

        [Command("that's rough, buddy")]
        public async Task ThatsRoughBuddy()
        {
            await ReplyAsync("https://tenor.com/view/thats-rough-buddy-avatar-the-last-airbender-zuko-gif-17596756");
        }

        [Command("that's what she said")]
        public async Task ThatsWhatSheSaid()
        {
            await ReplyAsync("https://tenor.com/view/steve-carell-the-office-thats-what-she-said-gif-8356135");
        }

        [Command("the beheaded")]
        public async Task TheBeheaded()
        {
            await ReplyAsync("https://tenor.com/view/dead-cells-middle-finger-fuck-you-gif-15761204");
        }

        [Command("the discord purge")]
        public async Task TheDiscordPurge()
        {
            await ReplyAsync("https://tenor.com/view/purge-design-weapons-destruction-gif-5999223");
        }

        [Command("the worst")]
        public async Task TheWorst()
        {
            await ReplyAsync("https://tenor.com/view/the-worst-gif-13248078");
        }

        [Command("this is the way")]
        public async Task ThisIsTheWay()
        {
            await ReplyAsync("https://tenor.com/view/mando-way-this-is-the-way-mandalorian-star-wars-gif-18467370");
        }

        [Command("time to work")]
        public async Task TimeToWork()
        {
            await ReplyAsync("https://tenor.com/view/working-work-gif-20073706");
        }

        //Transfer to DB
        [Command("tlj")]
        public async Task TLJ()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/925115018331172905/IMG_3701.jpg");
        }

        [Command("ugh")]
        public async Task Ugh()
        {
            await ReplyAsync("https://tenor.com/view/ugh-no-why-me-annoyed-gif-12005705");
        }

        [Command("unacceptable")]
        public async Task Unacceptable()
        {
            await ReplyAsync("https://tenor.com/view/unacceptable-adventure-time-lemongrab-freakout-armflail-gif-5515437");
        }

        [Command("unlimited power")]
        public async Task UnlimitedPower()
        {
            await ReplyAsync("https://tenor.com/view/unlimited-power-star-wars-gif-10270127");
        }

        //Transfer to DB
        [Command("wait...")]
        public async Task WaitFranco()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/925133556848660550/41020a6.gif");
        }

        //transfer to DB
        [Command("who gives a fuck")]
        public async Task WhoGivesAFuck()
        {
            await ReplyAsync("https://media.discordapp.net/attachments/895367300390211634/958932253596069949/chris-pratt-who-gives-a-fuck.gif");
        }

        //transfer to DB
        [Command("who the hell cares")]
        public async Task WhoTheHellCares()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/959133120970489908/viddit_37b34f8b.gif");
        }

        //transfer to DB
        [Command("winston")]
        public async Task Winston()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/895367300390211634/964237663060246578/IMG_2918.gif");
        }

        //4 responses
        [Command("wtf")]
        public async Task WTF()
        {
            String[] wtf =
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
            int value = random.Next(0, wtf.Length);
            var text = ($"{wtf[value]}");

            await ReplyAsync(text);
        }

        //needs new link
        [Command("yes, my liege")]
        public async Task YesMyLiege()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/948590685056040970/952070092689117235/RDT_20220312_0006067869055844959929244.jpg");
        }

        //transfer to DB
        [Command("you have no power here")]
        public async Task YouHaveNoPowerHere()
        {
            await ReplyAsync("https://media.discordapp.net/attachments/720505313085620286/972737120777171014/L0coY9I1D2BnaKln9a.gif");
        }

        //transfer to DB
        [Command("you're a bitch")]
        public async Task YoureABitch()
        {
            await ReplyAsync("https://cdn.discordapp.com/attachments/902629594564296725/936617850880286780/A_Special_Song_Just_For_You.webm");
        }

        [Command("zuko")]
        public async Task Zuko()
        {
            await ReplyAsync("https://tenor.com/view/thats-rough-buddy-avatar-the-last-airbender-zuko-gif-17596756");
        }

        #endregion Alpha Bob Commands

        //Beta Bob
        #region Beta Bob Commands

        readonly String[] CommandsToAddToBB =
        {
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

        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("pong");
        }

        #endregion Beta Bob Commands

    }
}