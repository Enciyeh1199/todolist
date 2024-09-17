using System.ComponentModel.DataAnnotations;
namespace Data;

public class Category
{
    [Key]
    public  int id { get; set; }
    public bool IsAction { get; set; }
    public string Titel  { get; set; }
    //relation
    public List<Todo> Todos { get; set; }

}