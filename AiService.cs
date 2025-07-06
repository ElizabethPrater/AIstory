using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIstory.Services
{
    public static class AiService
    {
        public static async Task<string> GetAIResponse(string prompt)
        {
            await Task.Delay(500); // Simulate thinking time
            return $"[AI responds to \"{prompt}\" with something mysterious and dramatic.]";
        }
    }

}
