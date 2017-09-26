/*******************************************************************************
* Copyright 2009-2017 Amazon.com, Inc. or its affiliates. All Rights Reserved.
* 
* Licensed under the Apache License, Version 2.0 (the "License"). You may
* not use this file except in compliance with the License. A copy of the
* License is located at
* 
* http://aws.amazon.com/apache2.0/
* 
* or in the "license" file accompanying this file. This file is
* distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
* KIND, either express or implied. See the License for the specific
* language governing permissions and limitations under the License.
*******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Text.Encodings.Web;
using dotnetLexChatBot.Models;
using dotnetLexChatBot.Data;
using System.Net.Http;
using System.Xml;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnetLexChatBot.Controllers
{
    public class HelloChatBotController : Controller
    {
        //Collection of ChatBot Messages

        //static Dictionary<string, string> lexSessionData = new Dictionary<string, string>();
        private readonly IAWSLexService awsLexSvc;
        private ISession userHttpSession;
        private Dictionary<string, string> lexSessionData;
        private List<ChatBotMessage> botMessages;
        private string botMsgKey = "ChatBotMessages", 
                       botAtrribsKey = "LexSessionData",
                       userSessionID = String.Empty;


        public HelloChatBotController(IAWSLexService awsLexService)
        {
            awsLexSvc = awsLexService;
        }

        public IActionResult TestChat(List<ChatBotMessage> messages)
        {
            return View(messages);
        }

        public IActionResult ClearBot()
        {
            userHttpSession = HttpContext.Session;
            
            //Clear session keys and session information without removing Session ID
            userHttpSession.Clear();

            //New botMessages and lexSessionData objects
            botMessages = new List<ChatBotMessage>();
            lexSessionData = new Dictionary<string, string>();

            userHttpSession.Set<List<ChatBotMessage>>(botMsgKey, botMessages);
            userHttpSession.Set<Dictionary<string, string>>(botAtrribsKey, lexSessionData);
            
            awsLexSvc.Dispose();
            return View("TestChat", botMessages);
        }

        [HttpGet]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GetChatMessage(string userMessage)
        {
            //Get user session and chat info
            userHttpSession = HttpContext.Session;
            userSessionID = userHttpSession.Id;
            botMessages = userHttpSession.Get<List<ChatBotMessage>>(botMsgKey) ?? new List<ChatBotMessage>();
            lexSessionData = userHttpSession.Get<Dictionary<string, string>>(botAtrribsKey) ?? new Dictionary<string, string>();

            //No message was provided, return to current view
            if (String.IsNullOrEmpty(userMessage)) return View("TestChat", botMessages);

            //A Valid Message exists, Add to page and allow Lex to process
            botMessages.Add(new ChatBotMessage()
            { MsgType = MessageType.UserMessage, ChatMessage = userMessage });

            await postUserData(botMessages);

            //Call Amazon Lex with Text, capture response
            var lexResponse = await awsLexSvc.SendTextMsgToLex(userMessage, lexSessionData, userSessionID);

            lexSessionData = lexResponse.SessionAttributes;
            botMessages.Add(new ChatBotMessage()
            { MsgType = MessageType.LexMessage, ChatMessage = lexResponse.Message });

            //Add updated botMessages and lexSessionData object to Session
            userHttpSession.Set<List<ChatBotMessage>>(botMsgKey, botMessages);
            userHttpSession.Set<Dictionary<string, string>>(botAtrribsKey, lexSessionData);
           
            return View("TestChat", botMessages);
        }

        public async Task<IActionResult> postUserData(List<ChatBotMessage> messages)
        {
            //testing
            return await Task.Run(() => TestChat(messages));
        }

        
    }

}
