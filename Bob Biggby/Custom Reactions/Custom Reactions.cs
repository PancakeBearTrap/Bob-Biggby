using Discord;
using Discord.Interactions;
using Discord.Net.Queue;
using Discord.Net.Rest;
using Discord.Rest;
using Discord.Webhook;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomReactions
{
    public class Response
    {
        public string[] prompts;
        public string[] responses;

        //'Params' allow you to pass in arrays of objects without saying "new Array". i.e. SetPrompts("hi", "hello") is the same as SetPrompts(new string[] {"hi", "hello"})
        public Response SetPrompts(params string[] _prompts)
        {
            prompts = _prompts;
            return this;
        }

        //Returning this object with these "set" methods allows us to chain them together, like new Response().SetPrompts(...).SetResponses(...)
        public Response SetResponses(params string[] _responses)
        {
            responses = _responses;
            return this;
        }


        //this is basically pseudocode, the specifics depend on how you're using the API
        public bool MessageMatches(SocketUserMessage arg)
        {
            var message = arg as SocketUserMessage;
            //converts the input to a string, since it comes in as "socketusermessage"
            string stringmessage = message.ToString();
            //converts string to lowercase so that the message is the same for the sake of the bot
            string lowmess = stringmessage.ToLower();

            foreach (var s in prompts)
            {

                if (lowmess.Equals(s))
                {
                    //you probably need a reference to the discord API object or whatever you're using to send messages, pass it in via the constructor of this object. Then pick a random string from the response array
                    //PrintResponse();

                    Random random = new Random();
                    int value = random.Next(0, responses.Length);
                    var RandomResponse = ($"{responses[value]}");

                    message.Channel.SendMessageAsync(RandomResponse).Wait();

                    return true;
                }
            }
            return false;
        }
    }
}
