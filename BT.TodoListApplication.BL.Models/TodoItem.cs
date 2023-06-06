namespace BT.TodoListApplication.BL.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public TodoItem(string ItemName)
        {
            this.ItemName = ItemName;
            this.ItemDescription = string.Empty;
        }
        public TodoItem(int Id, string ItemName, string ItemDescription)
        {
            this.Id = Id;
            this.ItemName = ItemName;
            this.ItemDescription = ItemDescription;
        }
        public TodoItem() { }
    }
}