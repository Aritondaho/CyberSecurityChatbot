using System;
using System.Collections.Generic;

namespace CyberSecurityChatbot
{
    public class ResponseEngine
    {
        private readonly Dictionary<string, string> responses;

        public ResponseEngine()
        {
            responses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                {"password", "🔐 Use a strong password (12+ chars), mix letters/numbers/symbols, and use a password manager."},
                {"phishing", "⚠ Phishing: never click suspicious links. Verify sender and check links by hovering before clicking."},
                {"safe browsing", "🌐 Use HTTPS, keep browser updated, avoid public Wi-Fi for banking, and don't download unknown files."},
                {"two factor", "🔑 Enable 2FA (authenticator apps or SMS) for important accounts."},
                {"help", "Try keywords: password, phishing, safe browsing, two factor, or type 'exit' to quit."}
            };
        }

        public string GetResponse(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
                return "I didn't catch that. Try one of: password, phishing, safe browsing.";

            
            foreach (var key in responses.Keys)
            {
                if (userInput.IndexOf(key, StringComparison.OrdinalIgnoreCase) >= 0)
                    return responses[key];
            }

            return "Sorry, I don't know that one. Try 'help' for suggestions.";
        }
    }
}
