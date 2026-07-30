using Microsoft.EntityFrameworkCore;

namespace KittenRs.Data.Models;

[PrimaryKey(nameof(Id))]
public class PostModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public long Modified { get; set; }
    public string Description { get; set; }
    public string? ImageUrl { get; set; }
    public string Path { get; set; }
    public bool BlogFinished { get; set; }
    public bool ProjectFinished { get; set; }
    public long HiatusSince { get; set; }
    public string? Collection { get; set; }
}