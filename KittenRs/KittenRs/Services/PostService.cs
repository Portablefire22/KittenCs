using KittenRs.Client.Data;
using KittenRs.Data;
using KittenRs.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KittenRs.Services;

public class PostService
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;
    
    public PostService(IDbContextFactory<ApplicationDbContext> factory)
    {
        _contextFactory = factory;
    }


    public async Task<BlogDto[]> GetPosts()
    {
        await using var db = await _contextFactory.CreateDbContextAsync();
        return await db.Posts.OrderByDescending(x => x.Modified).Select(x => new BlogDto()
        {
            Title =  x.Title,
            Description = x.Description,
            BlogFinished =  x.BlogFinished,
            Collection =  x.Collection,
            HiatusSince =  x.HiatusSince,
            ImageUrl =  x.ImageUrl,
            ProjectFinished =  x.ProjectFinished,
        }).ToArrayAsync();
    }
    
    
    public async Task<BlogDto?> GetPost(string name)
    {
        int id;
        await using var db = await _contextFactory.CreateDbContextAsync();
        var postModel = db.Posts.SingleOrDefaultAsync(x => x.Title == name).Result;
        if (postModel == null) return null;
        return new BlogDto()
        {
            Title =  postModel.Title,
            Description =  postModel.Description,
            BlogFinished =  postModel.BlogFinished,
            Collection =  postModel.Collection,
            HiatusSince =  postModel.HiatusSince,
            ImageUrl =  postModel.ImageUrl,
            ProjectFinished =  postModel.ProjectFinished,
        };
    }

    public async Task<string?> GetPostContent(int id)
    {
        await using var db = await _contextFactory.CreateDbContextAsync();
        var post = await db.Posts.FindAsync(id);
        if (post == null) return null;
        
        // Should be safe since u need to edit the DB to specify path
        return await File.ReadAllTextAsync($"Posts/{post.Path}");
    }

    public async Task<string?> GetPostContent(string name)
    {
        int id;
        await using (var db = await _contextFactory.CreateDbContextAsync())
        {
            var postModel = db.Posts.SingleOrDefaultAsync(x => x.Title == name).Result;
            if (postModel == null) return null;
            id = postModel.Id;
        }

        return await GetPostContent(id);
    }
}