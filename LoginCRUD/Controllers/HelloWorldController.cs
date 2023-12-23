using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


public class HelloWorldController : Controller
{
    // Ejemplo
    // GET: /HelloWorld/
    // public string Index()
    // {
    //     return "This is my default action...";
    // }

    public IActionResult Index(){
        return View();
    }



    // 
    // GET: /HelloWorld/Welcome/ 
    // GET: /HelloWorld/Welcome/ 
// Requires using System.Text.Encodings.Web;
 public IActionResult Welcome(string name, int numTimes = 1)
    {
        ViewData["Message"] = "Hello " + name;
        ViewData["NumTimes"] = numTimes;
        return View();
        //return HtmlEncoder.Default.Encode($"Hello {name}, NumTimes is: {numTimes}");
    }
}

