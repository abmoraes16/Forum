using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProjetoForum.Models
{
    public class DAOPostagem:Conexao
    {
        public List<Postagem> Listar(){
            List<Postagem> ListaPostagem = new List<Postagem>();

            try{
                conn = new SqlConnection(Caminho());
                conn.Open();

                cmd = new SqlCommand();

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select * from postagem";
                cmd.Connection = conn;

                reader = cmd.ExecuteReader();

                while(reader.Read()){
                    ListaPostagem.Add(new Postagem(){
                        Id = reader.GetInt32(0),
                        IdTopico = reader.GetInt32(1),
                        IdUsuario = reader.GetInt32(2),
                        Titulo = reader.GetString(3),
                        Mensagem = reader.GetString(4),
                        DataCadastro = reader.GetDateTime(5)
                    });
                }

       }catch(SqlException ex){
            throw new Exception("Erro ao tentar ler a tabela postagem ->"+ex.Message);
        }
        catch(Exception ex){
            throw new Exception("Erro inesperado ->"+ex.Message);
        }
        finally{
            conn.Close();
        }

            return ListaPostagem;
    }

    public bool Cadastro(Postagem Postagem){
        bool resultado = false;

        try{
            conn = new SqlConnection(Caminho());
            conn.Open();

            cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"insert into postagem(idtopico,idusuario,titulo,mensagem) values(@IdTopico,@IdUsuario,@Titulo,@Mensagem)";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@IdTopico",Postagem.IdTopico);
            cmd.Parameters.AddWithValue("@IdUsuario",Postagem.IdUsuario);
            cmd.Parameters.AddWithValue("@Titulo",Postagem.Titulo);
            cmd.Parameters.AddWithValue("@Mensagem",Postagem.Mensagem);
            
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

    public bool Atualizar(Postagem Postagem){
        bool resultado = false;

        try{
            conn = new SqlConnection(Caminho());
            cmd = new SqlCommand();

            conn.Open();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"update Postagemforum set titulo=@Titulo,mensagem=@Mensagem where id=@Id and idtopico=@IdTopico and idusuario=@IdUsuario";
            cmd.Connection = conn;

            cmd.Parameters.AddWithValue("@IdTopico",Postagem.IdTopico);
            cmd.Parameters.AddWithValue("@IdUsuario",Postagem.IdUsuario);
            cmd.Parameters.AddWithValue("@Titulo",Postagem.Titulo);
            cmd.Parameters.AddWithValue("@Mensagem",Postagem.Mensagem);
            cmd.Parameters.AddWithValue("@Id",Postagem.Id);

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
            cmd.CommandText = @"delete from postagem where id=@Id";
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