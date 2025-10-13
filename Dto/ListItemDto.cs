namespace TodoListMinimalApi.Dto
{
    public class ListItemDto
    {
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime Date { get; set; }
        public string Author { get; set; } = null!;
    }
}

