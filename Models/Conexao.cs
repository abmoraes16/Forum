using System.Data.SqlClient;

namespace ProjetoForum.Models
{
    public abstract class Conexao
    {
        /// <summary>
        /// Objeto utilizado para estabelecer a conexão com o
        /// servidor de banco de dados SQLExpress
        /// </summary>
        protected SqlConnection conn = null;
        protected SqlCommand cmd = null;
        /// <summary>
        /// Objeto utilizado para executar comandos de SQL, tais como:
        /// Select; Update; Delete; Insert e outros
        /// </summary>
        /// <returns></returns>
        protected SqlDataReader reader = null;
        /// <summary>
        /// O método caminho retorna o local do banco de dados
        /// </summary>
        /// <returns></returns>
        protected static string Caminho()
        {
            return @"Data Source=.\SqlExpress;Initial Catalog=ProjetoForum;user id=sa;password=nfe@120";
        }        

    }
}