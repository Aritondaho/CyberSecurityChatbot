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
                {"malwane", "Malwane is harmful software. Avoid downkoading unknown files and always use activirus." },
                {"scam", "Scams try to trick you into giving money or information. Never trust urgent messages asking for personal details." },
                {"help", "💡 You can ask me about cybersecurity topics like:\n- password\n- phishing\n- safe browsing\n- two factor\n- malware\n- scam\n\nType 'exit' to quit."}
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
