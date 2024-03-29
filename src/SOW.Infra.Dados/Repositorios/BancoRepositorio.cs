﻿using System.Collections.Generic;
using System.Linq;
using SOW.Dominio.Entidades;
using SOW.Dominio.Interfaces.Repositorios;
using SOW.Infra.Dados.Contextos;
using SOW.Infra.Dados.Repositorios.Base;

namespace SOW.Infra.Dados.Repositorios
{
    public class BancoRepositorio: RepositorioBase<Banco>, IBancoRepositorio
    {
        public BancoRepositorio(EfContext efContext) 
            : base(efContext)
        {
        }

        public Banco ObterPorId(int bancoId)
        {
            return EfContext.Bancos.Find(bancoId);
        }

        public IReadOnlyList<Banco> SelecionarTodos()
        {
            return EfContext.Bancos.ToList();
        }
    }
}
