using MercadoLivreCategorias.Entity;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;

namespace MercadoLivreCategorias.Repository
{
    public class CategoriaRepository
    {
        public int Salvar(Categoria categoria)
        {
            const string insert = @"INSERT INTO [dbo].[Categoria]
                                           ([Nome]
                                           ,[Codigo]
                                           ,[IdPai]
                                           ,[Nivel]
                                           ,[Json])
                                     output INSERTED.Id VALUES
                                           (@Nome
                                           ,@Codigo
                                           ,@IdPai
                                           ,@Nivel
                                           ,@Json)";

            using (var con = new SqlConnection("Data Source=DANILO\\SQLEXPRESS;Initial Catalog=MercadoLivre;Integrated Security=True"))
            {
                con.Open();
                return con.ExecuteScalar<int>(insert, categoria);
            }
        }
    }
}
