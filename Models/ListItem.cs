using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListMinimalApi.Models
{
    [Table("ListItem")]
    public class ListItem
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; } 

        [Column("content")]
        public string Content { get; set; } 

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("author")]
        public string Author { get; set; } 
    }
}

