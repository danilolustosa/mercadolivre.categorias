using MercadoLivreCategorias.Model;
using MercadoLivreCategorias.Repository;
using Newtonsoft.Json;
using System;

namespace MercadoLivreCategorias
{
    class Program
    {
        public static MercadoLivreRepository _mercadoLivreRepository = new MercadoLivreRepository();
        public static CategoriaRepository _repository = new CategoriaRepository();
        public static int level = 0;

        static void Main(string[] args)
        {


            _mercadoLivreRepository.RootCategories().ForEach(root =>
            {
                Console.WriteLine(root.name + $" ({root.id})");

                int id = _repository.Salvar(new Entity.Categoria()
                {
                    Codigo = root.id,
                    Nome = root.name,
                    Nivel = level,
                    Json = ""
                });

                GetCategory(id, root.id);
            });



        }

        static void GetCategory(int idPai, string codigo)
        {
            level++;
            string space = "";

            for (int i = 1; i <= level; i++)
            {
                space += "  ";
            }

            var category = _mercadoLivreRepository.Category(codigo);

            var childrens = category.children_categories;

            if (childrens.Length > 0)
            {
                foreach (var item in childrens)
                {
                    Console.WriteLine(space + item.name + $" ({item.id})");

                    int id = _repository.Salvar(new Entity.Categoria()
                    {
                        Codigo = item.id,
                        Nome = item.name,
                        IdPai = idPai,
                        Nivel = level,
                        Json = JsonConvert.SerializeObject(category)
                    });

                    GetCategory(id, item.id);
                }
            }
            level--;
        }
    }
}
