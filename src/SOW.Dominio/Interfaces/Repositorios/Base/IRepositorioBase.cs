﻿using SOW.NucleoCompartilhado.Modelos;

namespace SOW.Dominio.Interfaces.Repositorios.Base
{
    public interface IRepositorioBase<T> where T: Entidade
    {
        void Adicionar(T entidade);
        void Editar(T entidade);
        void Excluir(T entidade);
    }
}
