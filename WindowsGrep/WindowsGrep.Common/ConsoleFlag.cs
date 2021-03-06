﻿namespace WindowsGrep.Common
{
    public enum ConsoleFlag
    {
        SearchTerm,

        // Targets a specific file directory
        [ExpectsParameter(true)]
        [FilterCharacterCollection('\'', '"', '\\')]
        [DescriptionCollection("-d", "--directory=")]
        Directory,

        // Suppress normal output; Instead print a count of matching lines for each input file
        //[DescriptionCollection("-c", "--count")]
        //Count,

        // Returns local text surrounding the search term in each result
        [ExpectsParameter(true)]
        [DescriptionCollection("-c", "--context=")]
        Context,

        // Interprets patterns as fixed strings, not regular expressions
        [DescriptionCollection("-F", "--fixed-strings")]
        FixedStrings,

        // Interprets patterns as basic regular expressions. This is default
        [DescriptionCollection("-G", "--basic-regexp")]
        BasicRegex,

        // Obtain patterns from a specific file
        [ExpectsParameter(true)]
        [FilterCharacterCollection('\'', '"', '\\')]
        [DescriptionCollection("-f", "--file=")]
        TargetFile,

        // Ignore breaks in-between lines within the file
        [DescriptionCollection("-b", "--ignore-breaks")]
        IgnoreBreaks,

        // Ignore case distinctions in patterns and input data
        [DescriptionCollection("-i", "--ignore-case")]
        IgnoreCase,

        // Searches also in the subdirectories of the target directory
        [DescriptionCollection("-r", "--recursive")]
        Recursive,

        // Restricts search to files with the specified extensions. Comma delimited
        [ExpectsParameter(true)]
        [FilterCharacterCollection('\'', '"', '.', '\\')]
        [DescriptionCollection("-t", "--filetype-include=")]
        FileTypeInclusions,

        // Excludes all files with the specified extensions. Comma delimited
        [ExpectsParameter(true)]
        [FilterCharacterCollection('\'', '"', '.', '\\')]
        [DescriptionCollection("-T", "--filetype-exclude=")]
        FileTypeExclusions,

        // Match against file names rather than file content
        [DescriptionCollection("-k", "--filenames-only")]
        FileNamesOnly,

        // Replace instances of the search term with the replace parameter
        [ExpectsParameter(true)]
        [FilterCharacterCollection('\'', '"')]
        [DescriptionCollection("-R", "--replace")]
        Replace,

        // Delete files returned in search
        [DescriptionCollection("-D", "--delete-files")]
        Delete,

        // Write outputs to specified file
        [ExpectsParameter(true)]
        [FilterCharacterCollection('\'', '"', '\\')]
        [DescriptionCollection("-w", "--write=")]
        Write
    }
}
