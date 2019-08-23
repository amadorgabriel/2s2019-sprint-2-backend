using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Repository
{
    public class FilmeRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;Initial Catalog=T_RoteiroFilmes;User Id=sa;Pwd=132;";

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> Filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "SELECT Filmes.*, Generos.Nome FROM Filmes JOIN Generos ON Filmes.IdGenero = Generos.IdGenero";
                SqlDataReader sdr;

                SqlCommand cmd = new SqlCommand(Query, con);
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    FilmeDomain filme = new FilmeDomain
                    {
                        IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                        Titulo = sdr["Titulo"].ToString(),
                        IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                        Genero = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString(),
                        }

                    };

                    Filmes.Add(filme);
                }
            }
            return Filmes;
        }

        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "SELECT Filmes.*, Generos.Nome FROM Filmes JOIN Generos ON Filmes.IdGenero = Generos.IdGenero WHERE IdFilme = @Id; ";

                SqlDataReader sdr;

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString(),
                            }
                        };
                        return filme;
                    }
                }
            }
            return null;
        }

        public void Cadastar(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Filmes(Titulo, IdGenero) VALUES (@Titulo, @Id)";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@Id", filme.IdGenero);
                    sdr = cmd.ExecuteReader();
                }
            }
        }

        public List<FilmeDomain> BuscarFilmesPorIdGenero(int id)
        {
            List<FilmeDomain> Filmes = new List<FilmeDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "SELECT Filmes.*, Generos.Nome FROM Generos JOIN Filmes ON Generos.IdGenero = Filmes.IdGenero WHERE Generos.IdGenero = @Id; ";

                SqlDataReader sdr;

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString(),
                            }
                            
                        };
                        Filmes.Add(filme);
                    }
                }
            }
            return Filmes;
        }

        public List<FilmeDomain> BuscarFilmesPorPalavras(string busca)
        {
            List<FilmeDomain> Filmes = new List<FilmeDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = " SELECT Filmes.*, Generos.Nome FROM Filmes JOIN Generos ON Filmes.IdGenero = Generos.IdGenero WHERE Filmes.Titulo = 'Rei Leão'; ";

                SqlDataReader sdr;

                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Id", id);
                sdr = cmd.ExecuteReader();

                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Titulo = sdr["Titulo"].ToString(),
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString(),
                            }

                        };
                        Filmes.Add(filme);
                    }
                }
            }
            return Filmes;
        }

    }
}


