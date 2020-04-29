﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WindowsGrep.Common
{
    public static class ConsoleUtils
    {
        #region Methods..
        #region DiscoverCommandArgs
        public static IDictionary<ConsoleFlag, string> DiscoverCommandArgs(string commandRaw)
        {
            ConcurrentDictionary<ConsoleFlag, string> CommandArgs = new ConcurrentDictionary<ConsoleFlag, string>();

            List<ConsoleFlag> ConsoleFlagValues = EnumUtils.GetValues<ConsoleFlag>().ToList();
            ConsoleFlagValues.ForEach(flag =>
            {
                bool ExpectsParameter = flag.GetCustomAttribute<ExpectsParameterAttribute>()?.Value ?? false;
                List<string> DescriptionCollection = flag.GetCustomAttribute<DescriptionCollectionAttribute>()?.Value.ToList();
               
                DescriptionCollection?.ForEach(description =>
                {
                    string FlagPattern = $"(^|\\s|-)(?<FlagDescriptor>{description})";
                    FlagPattern = ExpectsParameter ? FlagPattern + "\\s*(?<Argument>\\S*)" : FlagPattern;
                   
                    var Matches = Regex.Matches(commandRaw, FlagPattern, RegexOptions.IgnoreCase);
                    if (ExpectsParameter && Matches.Count > 1)
                    {
                        throw new Exception("Error: Arguments of parameter type cannot be specified more than once");
                    }
                    else if (Matches.Count > 0)
                    {
                        string Argument = Matches.Select(match => match.Groups["Argument"].Value).FirstOrDefault();
                        CommandArgs[flag] = Argument;

                        commandRaw = Regex.Replace(commandRaw, FlagPattern, string.Empty);
                    }
                });
            });

            // Search term
            string SearchFilterPattern = commandRaw.Trim();
            CommandArgs[ConsoleFlag.SearchTerm] = SearchFilterPattern;

            if (CommandArgs[ConsoleFlag.SearchTerm] == string.Empty)
            {
                throw new Exception("Error: Search term not supplied");
            }

            return CommandArgs;
        }
        #endregion DiscoverCommandArgs
        #endregion Methods..
    }
}
