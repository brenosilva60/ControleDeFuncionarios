using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using controleDeFuncionarios.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace ControleDeFuncionarios.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public FuncionarioController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("http://localhost:5077/api/funcionario");
            var funcionarios = new List<Funcionario>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                funcionarios = JsonSerializer.Deserialize<List<Funcionario>>(json);
            }

            return View(funcionarios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("http://localhost:5077/api/funcionario", funcionario);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index"); // Redireciona para a lista de funcionários
            }

            // Exibe mensagem de erro caso a criação falhe
            ModelState.AddModelError(string.Empty, "Erro ao criar funcionário.");
            return View(funcionario); // Retorna a view com o modelo em caso de erro
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"http://localhost:5077/api/funcionario/{id}");
            var funcionario = new Funcionario();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                funcionario = JsonSerializer.Deserialize<Funcionario>(json);
            }

            return View(funcionario);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Funcionario funcionario)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.PutAsJsonAsync($"http://localhost:5077/api/funcionario/{funcionario.id}", funcionario);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index"); // Redireciona para a lista de funcionários
            }

            // Exibe mensagem de erro caso a edição falhe
            ModelState.AddModelError(string.Empty, "Erro ao editar funcionário.");
            return View(funcionario); // Retorna a view com o modelo em caso de erro
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"http://localhost:5077/api/funcionario/{id}");

            if (response.IsSuccessStatusCode)
            {
                return Ok(); // Retorna sucesso sem redirecionar
            }

            return BadRequest("Erro ao remover funcionário.");
        }
    }
}