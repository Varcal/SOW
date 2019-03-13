﻿using System.Collections.Generic;
using SOW.Dominio.Entidades;
using SOW.Dominio.Repositorios.Base;

namespace SOW.Dominio.Repositorios
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        IReadOnlyList<Usuario> SelecionarTodos();
    }
}
