using System;
using System.IO;

namespace SpamServices
{
    public class Spam : ISpam
    {
        public string GetSpam()
        {
            return "Хочешь заработать? Спроси меня как";
        }
    }
}
