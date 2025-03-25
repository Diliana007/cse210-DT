using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
public class Program
{
    public static void Main(string[] args)
    {
        //Create videos and comments
        var videos = new List<Video>();
        // Video 1 
        var video1 = new Video("Getting Started with C#", "Tech Academy", 120);
        video1.AddComment(new Comment("John", "Great video!"));
        video1.AddComment(new Comment("Alice", "Very helpful"));
        video1.AddComment(new Comment("Bob", "Thanks for sharing!"));
        videos.Add(video1);

        //Video 2
        var video2 = new Video("Object-Oriented Programming", "CodeMasters", 180);
        video2.AddComment(new Comment("Sarah", "Awesome explanation!"));
        video2.AddComment(new Comment("Mike", "Makes sense now!"));
        video2.AddComment(new Comment("Emma", "Thanks!"));
        videos.Add(video2);

        //Video 3
        var video3 = new Video("Introduction to Abstraction", "LearnTeach", 90);
        video3.AddComment(new Comment("Tom", "Perfect explanation!"));
        video3.AddComment(new Comment("Lucy", "I get it now"));
        video3.AddComment(new Comment("Harry", "Thanks!"));
        videos.Add(video3);

        //Display all videos
        foreach (Video video in videos)
        {
            Console.WriteLine($"Video Title:{video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments:{video.GetCommentCount()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.Name}: {comment.Text}");
            }
            Console.WriteLine($"\n---\n");
        }
    }  
}

