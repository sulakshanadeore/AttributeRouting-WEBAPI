using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AttributeRouting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        [HttpGet("all")]
        [HttpGet("listAllProducts")]
        public IActionResult GetProducts()
        {

            return Ok(new[] {"Laptop","Mobile","Charger","Cable" });

        }

        [HttpGet("FindProductByName/{name?}")]
        public IActionResult GetProducts(string? name="Mobile")
        {
            string[] prods = new string[] { "Laptop", "Mobile", "Charger", "Cable" };

            bool found=prods.Contains(name);
            if (found)
            {
                return Ok(name);
            }
            else
            {
                return NotFound();
            }
            

        }

        [HttpGet("FindName/id")]
        public IActionResult GetProd(int id)
        {
            string[] prods = new string[] { "Laptop", "Mobile", "Charger", "Cable" };

            string s=prods[id];
            if (s!=null)
            {
                return Ok(s);
            }
            else
            {
                return NotFound();
            }


        }





        [HttpGet("Find/id/name")]
        public IActionResult GetProductByIDorName(int? id,string? name)
        {
            string[] prods = new string[] { "Laptop", "Mobile", "Charger", "Cable" };
            if (id == null && name!=null)
            {

                Boolean ans = prods.Contains(name);
                return Ok($"Found by name ={name}, because id was not given");

            }
            else if (id != null)
            {
                int? prodid = id;
                  return RedirectToAction("GetProd", new {id=prodid });
                
            }
            else
            {

                return NotFound();
            }


        }


        [HttpPut("{id:int}/newname")]
        public IActionResult UpdateProduct(int id,string newname)
        {

            string[] prods = new string[] { "Laptop", "Mobile", "Charger", "Cable" };
            prods[id] = newname;
            return Ok($"Product id {id} updated to {newname}");


        }







        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            //logic to delete
            return Ok($"ProductID {id} deleted successfully");

        }

    }
}
