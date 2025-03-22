using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    public Scripture(Reference reference,string text)
    {
        _reference = reference;
        _words = text.Split('_').Select(word=>new Word(word)).ToList();
    }
    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

            if (visibleWords.Count == 0)
            {
                break;
            }

            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            hiddenCount++;

        }
    }

    public string GetDisplayText()
    {
        string text = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()}:{text}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public double GetHiddenPercentage()
    {
    int totalWords = _words.Count;
    int hiddenWords = _words.Count(word => word.IsHidden());
    return ((double)hiddenWords / totalWords) * 100; // Calculate percentage
    }
}

