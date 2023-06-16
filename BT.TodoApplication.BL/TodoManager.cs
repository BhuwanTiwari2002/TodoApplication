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
                    // TodoItem item = new TodoItem(int.Parse(dataRow["Id"].ToString()), dataRow["ItemName"].ToString(), dataRow["ItemDescription"].ToString(), DateTime.Parse(dataRow["ItemTime"].ToString()), int.Parse(dataRow["UserId"].ToString()));
                    TodoItem item = new TodoItem(int.Parse(dataRow["Id"].ToString()), dataRow["ItemName"].ToString(), dataRow["ItemDescription"].ToString(), DateTime.Parse(dataRow["ItemTime"].ToString()), dataRow["UserId"].ToString(), dataRow["IsChecked"].ToString());
                    items.Add(item);
                }
                return items;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<TodoItem> getItemsByUserId(string UserId)
        {
            List<TodoItem> items = new List<TodoItem>();
            try
            {
                DatabaseHelper databaseHelper = new DatabaseHelper();
                var dataTable = databaseHelper.sendSQLCommand($"SELECT * FROM TodoList WHERE UserId = '{UserId}';");
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    TodoItem item = new TodoItem(int.Parse(dataRow["Id"].ToString()), dataRow["ItemName"].ToString(), dataRow["ItemDescription"].ToString(), DateTime.Parse(dataRow["ItemTime"].ToString()),UserId, dataRow["IsChecked"].ToString());
                    items.Add(item);
                }
                return items;
            }
            catch (Exception ex)
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
                                                              "(ItemName, ItemDescription,ItemTime, UserId, isChecked) " +
                                                              $"VALUES ('{item.ItemName}','{item.ItemDescription}','{item.ItemTime}','{item.UserId}', '{item.isChecked}');");
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
                                                              $"'{item.ItemName}', isChecked = '{item.isChecked}', ItemDescription = '{item.ItemDescription}' WHERE ${item.Id} = Id;");
                return 1;
            } catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}