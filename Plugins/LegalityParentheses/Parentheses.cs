using BasePlugin;
using BasePlugin.Interfaces;
using BasePlugin.Records;
using System;
using System.Collections.Generic;

namespace LegalityParentheses
{
    public class ParenthesesPlugin : IPlugin
    {
        public static string _Id = "parent";
        public string Id => _Id;

        public static bool CheckBrackets(string input)
        {
            int count = 0;

            foreach (char c in input)
            {
                if (c == '(')
                {
                    count++;
                }
                else if (c == ')')
                {
                    count--;
                }

                if (count < 0)
                {
                    return false; // More closing brackets than opening brackets
                }
            }

            return count==0; // Check if all brackets are closed properly
        }
        public PluginOutput Execute(PluginInput input)
        {

            if (input.Message == "")
            {
                input.Callbacks.StartSession();
                return new PluginOutput("Enter a string with brackets:");
            }
            
            else
            {
                string iinput = input.Message;

                if (CheckBrackets(iinput))
                {
                    return new PluginOutput("The brackets in the input string are valid.");
                }
                else
                {
                    return new PluginOutput("The brackets in the input string are not valid.");
                }
                
            }
        }
    }
}