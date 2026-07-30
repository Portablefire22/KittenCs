namespace KittenRs.Client.Data;

public class BlogDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public long Modified { get; set; }
    public string? ImageUrl { get; set; }
    public bool BlogFinished { get; set; }
    public bool ProjectFinished { get; set; }
    public long HiatusSince { get; set; }
    public string? Collection { get; set; }
}