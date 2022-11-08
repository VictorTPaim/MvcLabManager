using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class ComputerController : Controller
{
    private readonly LabManagerContext _context;

    public ComputerController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index() {
        return View(_context.Computers);
    } 

    public IActionResult Show(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound(); // RedirectToAction("Index")
        }

        return View(computer);
    }

    public IActionResult Cadastrar(int id, string ram, string processor)
    {
        return View();
    }

    public IActionResult CadastrarComputador(Computer computer)
    {
        _context.Computers.Add(computer);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Deletar(int id)
    {
        Computer computer = _context.Computers.Find(id);
        if(computer == null)
        {
            return NotFound();
        }

        _context.Computers.Remove(_context.Computers.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Atualizar(int id)
    {
        Computer computer = _context.Computers.Find(id);

        if(computer == null)
        {
            return NotFound();
        }

        return View(computer);
    }

    [HttpPost]
    public IActionResult Atualizar(Computer computer)
    {
        Computer computadorAtualizado = _context.Computers.Find(computer.Id);

        if(computadorAtualizado == null)
        {
            return NotFound();
        }

        computadorAtualizado.Processor = computer.Processor;
        computadorAtualizado.Ram = computer.Ram;

        _context.Computers.Update(computadorAtualizado);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
