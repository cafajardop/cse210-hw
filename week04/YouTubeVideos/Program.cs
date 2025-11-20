using System;

class Program
{
    static void Main(string[] args)
    {        
        List<Video> videos = new List<Video>();
     
        Video video1 = new Video
        {
            Title = "C# Basics Tutorial",
            Author = "CodeMaster",
            LengthInSeconds = 600
        };

        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very clear explanation."));
        video1.AddComment(new Comment("Carl", "Helped me a lot."));

        videos.Add(video1);

        Video video2 = new Video
        {
            Title = "Learning OOP",
            Author = "DevLatino",
            LengthInSeconds = 720
        };

        video2.AddComment(new Comment("Dana", "Excellent explanation of objects."));
        video2.AddComment(new Comment("Leo", "Thanks for this content."));
        video2.AddComment(new Comment("Marta", "Will you make one about interfaces?"));

        videos.Add(video2);
        
        Video video3 = new Video
        {
            Title = "SOLID Principles Demo",
            Author = "CleanCoder",
            LengthInSeconds = 840
        };

        video3.AddComment(new Comment("Sergio", "Loved the single responsibility example."));
        video3.AddComment(new Comment("Nina", "Good use of examples."));
        video3.AddComment(new Comment("Rafa", "More videos like this, please!"));

        videos.Add(video3);

        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetCommentCount()}");

            foreach (var comment in video.Comments)
            {
                Console.WriteLine($" - {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}