﻿using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstilosRepository
    {
        public List<Estilos> Listar()
        {
            using(OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public void Cadastrar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilo);
                ctx.SaveChanges();
            }
        }

        public void Atualizar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Estilos estiloBuscado = ctx.Estilos.FirstOrDefault( x => x.IdEstilo == estilo.IdEstilo );
                estiloBuscado.Nome = estilo.Nome;
                ctx.SaveChanges();
            }
        }

        public void Deletar (int id)
        {
            using(OptusContext ctx = new OptusContext())
            {
                Estilos estiloRetornado = ctx.Estilos.Find(id);
                ctx.Estilos.Remove(estiloRetornado);
                ctx.SaveChanges();
            }
        }

        public Estilos BuscarPorId(int id)
        {
            using(OptusContext ctx = new OptusContext())
            {
                Estilos estiloRetornado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
                return estiloRetornado;
            }
        }

    }
}
