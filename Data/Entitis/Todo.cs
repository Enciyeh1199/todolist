using System.ComponentModel.DataAnnotations;

namespace Data;

public class Todo
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
