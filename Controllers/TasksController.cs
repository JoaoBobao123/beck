using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using oto_trabaio__task_.Models;

namespace oto_trabaio__task_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<ModelTask> modelTasks = new List<ModelTask>();

        [HttpGet]
        public ActionResult<List<ModelTask>> SearchTask()
        {
            return Ok(modelTasks);
        }


        [HttpPost]
        public ActionResult<List<ModelTask>>
            AddModelTask(ModelTask newTask)

        {
            if (newTask.Description.Length < 10)
                return BadRequest("Need more characters");

    

        
            if (newTask.Id == 0 && modelTasks.Count > 0)
                newTask.Id = modelTasks[modelTasks.Count - 1].Id + 1;

            modelTasks.Add(newTask);
            return Ok(modelTasks);

        }

        [HttpDelete("{id}")]

        public ActionResult<List<ModelTask>>

      RemoveModelTask(int id, ModelTask Remove)
        {

            var finded = modelTasks.Find(x => x.Id == id);
            if (finded is null)
                return NotFound("This task doesn´t exist");

            modelTasks.Remove(finded);  
            return Ok(modelTasks);
        }

    }
}
