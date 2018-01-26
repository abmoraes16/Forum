using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoForum.Models
{
    public class DAOTopico:Conexao
    {
        public List<Topico> Listar(){
            List<Topico> ListaTopico = new List<Topico>();

            try{
                conn = new SqlConnection(Caminho());
                conn.Open();

                cmd = new SqlCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select * from topicoforum";
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();

                while(reader.Read()){
                    ListaTopico.Add(new Topico(){
                        Id = reader.GetInt32(0),
                        Titulo = reader.GetString(1),
                        Descricao = reader.GetString(2),
                        DataCadastro = reader.GetDateTime(3)
                    });
                }

       }catch(SqlException ex){
            throw new Exception("Erro ao tentar ler a tabela usuário ->"+ex.Message);
        }
        catch(Exception ex){
            throw new Exception("Erro inesperado ->"+ex.Message);
        }
        finally{
            conn.Close();
        }

            return ListaTopico;
    }

    public bool Cadastro(Topico Topico){
        bool resultado = false;

        try{
            conn = new SqlConnection(Caminho());
            conn.Open();

            cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"insert into topicoforum(Titulo,Descricao) values(@Titulo,@Descricao)";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@Titulo",Topico.Titulo);
            cmd.Parameters.AddWithValue("@Descricao",Topico.Descricao);
            
            int linhas = cmd.ExecuteNonQuery();

            if(linhas>0){
                resultado=true;
            }

            cmd.Parameters.Clear();
        }

        catch(SqlException ex){
            throw new Exception("Erro ao tentar cadastrar ->"+ex.Message);
        }
        catch(Exception ex){
            throw new Exception("Erro inesperado ->"+ex.Message);
        }
        finally{
            conn.Close();
        }

        return resultado;
    }

    public bool Atualizar(Topico Topico){
        bool resultado = false;

        try{
            conn = new SqlConnection(Caminho());
            cmd = new SqlCommand();

            conn.Open();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"update topicoforum set Titulo=@Titulo,Descricao=@Descricao where id=@Id";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@Titulo",Topico.Titulo);
            cmd.Parameters.AddWithValue("Descricao",Topico.Descricao);
            cmd.Parameters.AddWithValue("@Id",Topico.Id);

            int linhas = cmd.ExecuteNonQuery();

            if(linhas>0){
                resultado = true;
            }

       }catch(SqlException ex){
            throw new Exception("Erro ao tentar atualizar ->"+ex.Message);
        }
        catch(Exception ex){
            throw new Exception("Erro inesperado ->"+ex.Message);
        }
        finally{
            conn.Close();
        }

        return resultado;
    }

    public bool Excluir(int id){
        bool resultado = false;

        try{
            conn = new SqlConnection(Caminho());
            conn.Open();

            cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"delete from topicoforum where id=@Id";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@Id",id);

            int linhas = cmd.ExecuteNonQuery();            

            if(linhas>0){
                resultado = true;
            }

        }catch(SqlException ex){
            throw new Exception("Erro ao tentar excluir ->"+ex.Message);
        }
        catch(Exception ex){
            throw new Exception("Erro inesperado ->"+ex.Message);
        }
        finally{
            conn.Close();
        }

        return resultado;
    }
        
        
    }
}