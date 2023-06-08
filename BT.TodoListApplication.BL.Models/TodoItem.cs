namespace BT.TodoListApplication.BL.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? ItemName { get; set; }
        public string? ItemDescription { get; set; }
        public DateTime ItemTime { get; set; }
        public TodoItem(string ItemName)
        {
            this.ItemName = ItemName;
            this.ItemDescription = string.Empty;
            this.ItemTime = DateTime.Today;
        }
        public TodoItem(int Id, string ItemName, string ItemDescription, DateTime ItemTime, string UserId)
        {
            this.Id = Id;
            this.ItemName = ItemName;
            this.ItemDescription = ItemDescription;
            this.ItemTime = ItemTime;
            this.UserId = UserId;
        }

        public TodoItem() { }
    }
}