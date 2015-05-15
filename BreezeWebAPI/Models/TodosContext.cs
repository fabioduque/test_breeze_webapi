using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BreezeWebAPI.Models
{


    public class TodosContext : DbContext
    {
        // DEVELOPMENT ONLY: initialize the database
        static TodosContext ()
        {
            Database.SetInitializer( new TodoDatabaseInitializer() );
        }
        public DbSet<TodoItem> Todos { get; set; }
    }
}