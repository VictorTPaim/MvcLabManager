using Microsoft.AspNetCore.Mvc;
using MvcLabManager.Models;

namespace MvcLabManager.Controllers;

public class LabController : Controller
{
    private readonly LabManagerContext _context;

    public LabController(LabManagerContext context)
    {
        _context = context;
    }

    public IActionResult Index() {
        return View(_context.Labs);
    } 

    public IActionResult Show(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }

    [HttpGet]
    public IActionResult Cadastrar(int id, string ram, string processor)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Cadastrar(Lab lab)
    {
        _context.Labs.Add(lab);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Atualizar(int id)
    {
        Lab lab = _context.Labs.Find(id);

        if(lab == null)
        {
            return NotFound();
        }

        return View(lab);
    }

    [HttpPost]
    public IActionResult Atualizar(Lab lab)
    {
        Lab labAtualizado = _context.Labs.Find(lab.Id);

        if(labAtualizado == null)
        {
            return NotFound();
        }

        labAtualizado.Number = lab.Number;
        labAtualizado.Name = lab.Name;
        labAtualizado.Block = lab.Block;

        _context.Labs.Update(labAtualizado);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Deletar(int id)
    {
        Lab lab = _context.Labs.Find(id);
        if(lab == null)
        {
            return NotFound();
        }

        _context.Labs.Remove(_context.Labs.Find(id));
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}