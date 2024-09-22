using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class Category :DbContext
{
    [Key]
    public  int id { get; set; }
    public bool IsAction { get; set; }
    public string Titel  { get; set; }
    //relation
    public List<Todo> Todos { get; set; }

}