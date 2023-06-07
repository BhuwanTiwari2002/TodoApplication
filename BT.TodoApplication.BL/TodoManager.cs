using BT.TodoListApplication.BL.Models;
using BT.TodoListApplication.DB.Helper;
using System.Data;

namespace BT.TodoListApplication.BL
{
    public static class TodoManager
    {
        

        public static List<TodoItem> getAllItems() {
            List<TodoItem> items = new List<TodoItem>();
            try
            {
                DatabaseHelper databaseHelper = new DatabaseHelper();
                var dataTable = databaseHelper.sendSQLCommand("SELECT * FROM TodoList;");
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    TodoItem item = new TodoItem(int.Parse(dataRow["Id"].ToString()), dataRow["ItemName"].ToString(), dataRow["ItemDescription"].ToString(), DateTime.Parse(dataRow["ItemTime"].ToString()));
                    items.Add(item);
                }
                return items;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        // Id is auto  
        public static int insertItem(TodoItem item)
        {
            try
            {
                DatabaseHelper databaseHelper = new DatabaseHelper();   
                var dataTable = databaseHelper.sendSQLCommand("INSERT INTO TodoList " +
                                                              "(ItemName, ItemDescription,ItemTime) " +
                                                              $"VALUES ('{item.ItemName}','{item.ItemDescription}','{item.ItemTime}');");
                return 1;
            } catch(Exception ex) {
                throw ex;
            }
        }

        public static int deleteItem(TodoItem item) {
            try {
                DatabaseHelper databaseHelper = new DatabaseHelper();
                var dataTable = databaseHelper.sendSQLCommand("DELETE FROM TodoList WHERE " +
                                                              $"{item.Id} = Id");
                return 1;
            } catch (Exception ex) {
                throw ex;
            }
        }
   
        public static int updateItem(TodoItem item)
        {
            try
            {
                DatabaseHelper databaseHelper = new DatabaseHelper();
                var dataTable = databaseHelper.sendSQLCommand("UPDATE TodoList SET ItemName = " +
                                                              $"'{item.ItemName}' WHERE ${item.Id} = Id;");
                return 1;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}