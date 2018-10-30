﻿using MongoDB.Driver;
using System.Collections.Generic;

namespace Bootstrap.DataAccess.MongoDB
{
    /// <summary>
    /// 
    /// </summary>
    public class Task : DataAccess.Task
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<DataAccess.Task> RetrieveTasks()
        {
            var users = MongoDbAccessManager.DBAccess.GetCollection<DataAccess.Task>("Tasks");
            return users.Find(FilterDefinition<DataAccess.Task>.Empty).SortByDescending(task => task.AssignTime).ToList();
        }
    }
}