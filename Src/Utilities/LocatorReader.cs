using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AutomationFrameworkRepo_v02.Src.Utilities
{
    public class LocatorReader
    {
        private static Dictionary<string, Dictionary<string, string>> locators;

        static LocatorReader()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string filePath = Path.Combine(projectPath, "Config\\UserInterface", "locators.json");
            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);
                locators = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonContent);
            }
            else
            {
                throw new FileNotFoundException($"Locator file not found: {filePath}");
            }
        }

        public static string GetLocator(string page, string element)
        {
            if (locators.ContainsKey(page) && locators[page].ContainsKey(element))
                return locators[page][element];

            throw new KeyNotFoundException($"Locator not found for {page}.{element}");
        }
    }
}
