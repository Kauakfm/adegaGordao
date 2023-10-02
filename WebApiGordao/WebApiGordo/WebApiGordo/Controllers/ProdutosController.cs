using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiGordao.Application.Model;
using WebApiGordao.Application.Produtos;
using WebApiGordao.Repository;

namespace WebApiGordo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly GordaoEntities _gordo;

        public ProdutosController(GordaoEntities context)
        {
            _gordo = context;
        }



        [HttpGet]
        public IActionResult ObterDashboard()
        {
            var produtoService = new ProdutosService(_gordo);
            var sucesso = produtoService.ObterProdutos();

            if (sucesso != null)
            {
                return Ok(sucesso);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("Atualizarfoto/{id}")]
        public async Task<IActionResult> InserirFoto(List<IFormFile> files, int id)
        {
            var produtoService = new ProdutosService(_gordo);
            var objId = _gordo.tabProdutos.FirstOrDefault(y => y.id == id);
            if (objId== null)
            {
                // faz alguma coisa pra negar
            }

            try
            {
                var fileModels = new List<FileUploadModel>();

                foreach (var formFile in files)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await formFile.CopyToAsync(memoryStream);
                        fileModels.Add(new FileUploadModel
                        {
                            FileName = formFile.FileName,
                            Data = memoryStream.ToArray()
                        });
                    }
                }

                var fotosSalvas = await produtoService.InserirFoto(fileModels, id);
                return Ok(fotosSalvas);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao salvar as fotos.");
            }
        }
    }
}