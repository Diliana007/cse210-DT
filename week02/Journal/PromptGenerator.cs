using System;
using System.Collections.Generic;
public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "What are you grateful for today?",
        "What did you learn today?",
        "How did you see God's hand in your life today?",
        "What can you do better tomorrow?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return  _prompts[index];
    }
}