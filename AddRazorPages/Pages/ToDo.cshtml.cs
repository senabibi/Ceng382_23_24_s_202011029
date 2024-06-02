using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; // Ensure you have this for DbContext usage

namespace MyApp.Namespace
{
    public class ToDoModel : PageModel
    {
        // Add a new property for binding the form data
        [BindProperty]
        public TblTodo NewToDo { get; set; } = default!;

        // Initialize a new instance of your database context
        public ToDoDatabaseContext ToDo = new();
        public List<TblTodo> ToDoList { get;set; } = default!;
Add the the following code to the OnGet method: 
            public void OnGet()
        {
     // LINQ query to retrieve items where IsDeleted is false
            ToDoList = (from item in ToDoDb.TblTodos
                          where item.IsDeleted == false
                          select item).ToList();
        }

        public void OnGet()
        {
        }

        // Add a page handler for HTTP POST
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewToDo == null)
            {
                return Page();
            }

            // Set IsDeleted to false as new todos are not deleted
            NewToDo.IsDeleted = false;

            // Add the new ToDo item to the database
            ToDo.Add(NewToDo);

            // Save changes to the database
            ToDo.SaveChanges();

            // Redirect to the Get handler after successful insertion
            return RedirectToPage("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
           // var itemToUpdate = ToDoList.FirstOrDefault(item => item.Id == id);
            if (ToDoDb.TblTodos != null)
            {
                var todo = ToDoDb.TblTodos.Find(id);
                if (todo != null)
                {
                    todo.IsDeleted = true;
                    ToDoDb.SaveChanges();
                }
            }            

            return RedirectToAction("Get");
        }
    }
}
