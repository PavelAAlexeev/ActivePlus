using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ActivePlus.Service;

namespace ActivePlus.Controllers
{
    [Route("api/[controller]")]
    public class ActivePlusController : Controller
    {
        private readonly IAPService APService;
        
        public ActivePlusController(IAPService aPService)
        {
            APService = aPService;
        }

        [HttpPost("Task1")]
        [Consumes("application/json")]
        public ActionResult<int> Task1(IEnumerable<int> array)
        {
            return APService.Task1(array);
        }

        [HttpPost("Task2")]
        [Consumes("application/json")]
        public ActionResult<IEnumerable<byte>> Task2(IEnumerable<byte> array1, IEnumerable<byte> array2)
        {
            var list1 = new LinkedList<byte>(array1);
            var list2 = new LinkedList<byte>(array2);

            return APService.Task2(list1, list2);
        }

        [HttpPost("Task3")]
        [Consumes("application/json")]
        public ActionResult<bool> Task3(string phrase)
        {
            return APService.Task3(phrase);
        }
    }
}
