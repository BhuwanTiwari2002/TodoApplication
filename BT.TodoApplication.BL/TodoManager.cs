﻿using BT.TodoListApplication.BL.Models;
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
                    TodoItem item = new TodoItem(int.Parse(dataRow["Id"].ToString()), dataRow["ItemName"].ToString(), dataRow["ItemDescription"].ToString()); 
                    items.Add(item);
                }
                return items;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int insertItem(TodoItem item)
        {
            try
            {
                DatabaseHelper databaseHelper = new DatabaseHelper();   
                var dataTable = databaseHelper.sendSQLCommand("INSERT INTO TodoList " +
                                                              "(Id, ItemName, ItemDescription) " +
                                                              $"VALUES ('{item.Id}','{item.ItemName}','{item.ItemDescription}');");
                return dataTable.GetChanges().Rows.Count;
            } catch(Exception ex) {
                throw ex;
            }
        }
    
    }
}