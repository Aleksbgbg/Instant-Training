namespace Instant.Training.UI.Utilities.LibraryFolders
{
    using System;
    using System.IO;
    using System.Linq;

    public class LibraryFoldersEntry
    {
        private readonly string[] _entryParts;

        public LibraryFoldersEntry(string entry)
        {
            _entryParts = entry.Split(separator: (char[])null, StringSplitOptions.RemoveEmptyEntries);

            if (IsValid())
            {
                Key = ParseComponent(0);
                Value = ParseComponentOrPath(1);
            }
        }

        public string Key { get; }

        public string Value { get; }

        public bool IsValid()
        {
            return _entryParts.Length == 2 && ComponentSurroundedByQuotes(0) && ComponentSurroundedByQuotes(1);
        }

        private bool ComponentSurroundedByQuotes(int index)
        {
            const string quote = "\"";

            string component = _entryParts[index];

            return component.StartsWith(quote) && component.EndsWith(quote);
        }

        private string ParseComponentOrPath(int index)
        {
            string component = ParseComponent(index);

            if (IsPath(component))
            {
                component = Path.GetFullPath(component);
            }

            return component;
        }

        private bool IsPath(string component)
        {
            char[] invalidPathChars = Path.GetInvalidPathChars();
            return Path.IsPathRooted(component) && !component.Any(invalidPathChars.Contains);
        }

        private string ParseComponent(int index)
        {
            const char quote = '"';

            string component = _entryParts[index];

            return component.Trim(quote);
        }
    }
}