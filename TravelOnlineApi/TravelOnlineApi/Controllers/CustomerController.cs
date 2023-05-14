using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TravelOnlineApi.DAL.Context;
using TravelOnlineApi.DAL.Entities;

namespace TravelOnlineApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IActionResult ListVisitors()
        {
            using (var context = new APIContext())
            {
                var visitors = context.Visitors.ToList();
                return Ok(visitors);
            }
        }

        [HttpPost]
        public IActionResult AddVisitor(Visitor visitor)
        {
            using (var context = new APIContext())
            {
                context.Visitors.Add(visitor);
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetVisitor(int id)
        {
            using (var context = new APIContext())
            {
                var visitor = context.Visitors.Find(id);
                if (visitor == null) return NotFound();
                else return Ok(visitor);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var context = new APIContext())
            {
                var visitor = context.Find<Visitor>(id);
                if (visitor == null) return NotFound();
                else
                {
                    context.Remove(visitor);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }

        [HttpPut]
        public IActionResult UpdateVisitor(Visitor model)
        {
            using (var context = new APIContext())
            {
                var visitor = context.Visitors.Find(model.VisitorID);
                if (visitor == null) return NotFound();
                else
                {
                    visitor.Name = model.Name;
                    visitor.Surname = model.Surname;
                    visitor.City = model.City;
                    visitor.Country = model.Country;
                    visitor.Mail = model.Mail;
                    context.Update(visitor);
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
    }
}
