using System.Linq;
using Breeze.ContextProvider;
using Breeze.ContextProvider.EF6;
using Breeze.WebApi2;
using System.Web.Http;
using BreezeWebAPI.Models;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;



namespace BreezeWebAPI.Controllers
{

    [BreezeController]
    public class TodosController : ApiController
    {

        readonly EFContextProvider<TodosContext> _contextProvider =
            new EFContextProvider<TodosContext>();

        // ~/breeze/todos/Metadata 
        [HttpGet]
        public string Metadata ()
        {
            return _contextProvider.Metadata();
        }

        // ~/breeze/todos/Todos
        // ~/breeze/todos/Todos?$filter=IsArchived eq false&$orderby=CreatedAt 
        [HttpGet]
        public IQueryable<TodoItem> Todos ()
        {
            return _contextProvider.Context.Todos;
        }

        // ~/breeze/todos/Todos/{id}
        [HttpGet]
        public IQueryable<TodoItem> Todos (int id)
        {
            return _contextProvider.Context.Todos.Where( t => t.Id == id) ;
        }


        // ~/breeze/todos/SaveChanges
        [HttpPost]
        public SaveResult SaveChanges ( JObject saveBundle )
        {
            return _contextProvider.SaveChanges( saveBundle );
        }
    }



}