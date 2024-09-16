using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Data;
public class TodolistContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Todo> Todos { get; set; }
    public string DbPath { get; set; }
    public TodolistContext(DbSet<Category> blogs, DbSet<Todo> posts)
    {
        Categories = blogs;
        Todos = posts;
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Todolist.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class Category
{
    [Key]
    public  int id { get; set; }
    public bool IsAction { get; set; }
    public string Titel  { get; set; }

   // public List<Post> Posts { get; set; } = new();
}

public class Todo
{
    [Key]
    public int id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplited { get; set; }
}
