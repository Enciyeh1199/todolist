using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class Todo :DbContext
{
    [Key]
    public int id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsComplited { get; set; }
    //relation
    public int  CategoryId { get; set; }
    public Category Category  { get; set; }   
}
