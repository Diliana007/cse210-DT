using System.Collections.Generic;

public class Video
{
    public string Title{get;set}
    public string Author{get;set}
    public int Length{get;set;}
    private List<Comment>_comments=new List<Comment>();

    public Video(string title,string author, int lenght)
    {
        Title = title;
        Author = author;
        Length = Length; 
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()

    {
        return _comments.Count;
    }

    public List<Comment>GetComment()

    {
        return_comments;
    }
}

