using Fiap.Web.Aula02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Web.Aula02.Controllers
{
    public class VeiculoController : Controller
    {
        //Lista para gravar os veiculos
        private static IList<Veiculo> _lista = new List<Veiculo>();
        private static int _id = 0;

        //TAREFA!
        //Cadastrar o veiculo na lista
        //Usar o index para exibir todos os veiculos em uma tabela HTML

        public IActionResult Index()
        {            
            return View(_lista); //Envia a lista para a view
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(Veiculo veiculo)
        {
            veiculo.Id = ++_id;
            //Cadastrar na lista
            _lista.Add(veiculo);
            //Mostrar uma mensagem de sucesso
            TempData["mensagem"] = "Veículo cadastrado!";
            return RedirectToAction("Cadastrar"); //Nome do método
        }

        [HttpGet]
        public IActionResult Editar(int id) {

            //Pesquisar o veiculo pelo ID
            var veiculo = _lista.First(v => v.Id == id);
            //Enviar o objeto Veiculo para a View
            return View(veiculo);
        }

        [HttpPost]
        public IActionResult Editar(Veiculo veiculo)
        {   
            //Atualizar o veiculo na lista
            //Pesquisar a posição do veiculo na lista
            var index = _lista.ToList().FindIndex(v => v.Id == veiculo.Id);
            _lista[index] = veiculo;
            //Enviar uma mensagem para view
            TempData["msg"] = "Veiculo atualizado";
            //Redirect para a listagem (index)
            return RedirectToAction("Index");

        }
    }
}
