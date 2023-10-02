using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiGordao.Application.Model;
using WebApiGordao.Repository;
using WebApiGordao.Repository.Models;

namespace WebApiGordao.Application.Produtos
{
    public class ProdutosService
    {
        private readonly GordaoEntities _gordo;

        public ProdutosService(GordaoEntities context)
        {
            _gordo = context;
        }


        public List<Produto> ObterProdutos()
        {
            try
            {
                var objProd = _gordo.tabProdutos.ToList();
                List<Produto> produto = new List<Produto>();
                foreach (var item in objProd)
                {
                    produto.Add(new Produto
                    {
                        numeroProduto = item.id,
                        nome = item.nomeProduto,
                        valor = item.valor,
                        ml = item.quantidadeMl,
                        tipo = item.tipoId,
                        Foto = item.Foto
                    });
                }
                return produto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<string>> InserirFoto(List<FileUploadModel> files, int id)
        {
            if (files == null || files.Count == 0)
                throw new ArgumentException("Nenhum arquivo foi fornecido para upload.");

            var fotosSalvas = new List<string>();

            foreach (var file in files)
            {
                if (file.Data.Length > 0)
                {
                    file.FileName = id.ToString() + $".{file.FileName.Split(".")[1]}";
                    // Salvar a foto em um diretório (por exemplo, "Fotos") e obter o caminho completo do arquivo salvo
                    string filePath = "C:\\inetpub\\wwwroot\\images\\" + file.FileName;

                    // Verificar se o diretório "Fotos" existe e criar se não existir
                    if (!Directory.Exists("C:\\inetpub\\wwwroot\\images"))
                    {
                        Directory.CreateDirectory("C:\\inetpub\\wwwroot\\images");
                    }

                    // Salvar o arquivo no diretório
                    await File.WriteAllBytesAsync(filePath, file.Data);
                    var user = _gordo.tabProdutos.FirstOrDefault(x => x.id == id);
                    user.Foto = file.FileName;
                    _gordo.tabProdutos.Update(user);
                    _gordo.SaveChanges();


                    fotosSalvas.Add(filePath);
                }
            }

            return fotosSalvas;
        }







    }
}
